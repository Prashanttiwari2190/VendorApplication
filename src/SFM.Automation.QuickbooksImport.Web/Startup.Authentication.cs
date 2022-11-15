using System;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SFM.Automation.QuickbooksImport.Web.Configuration;

namespace SFM.Automation.QuickbooksImport.Web
{
    /// <summary>
    ///   Extensions for and <see cref="IApplicationBuilder"/> object.
    /// </summary>
    internal static partial class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder app, bool authnEnabled = true)
        {
            if (authnEnabled)
                app.UseAuthentication();

            return app;
        }
    }

    /// <summary>
    ///   Extensions for and <see cref="IServiceCollection"/> object.
    /// </summary>
    [SuppressMessage("Maintainability Rules", "SA1402", Justification = "Related Configuration and Startup Extensions")]
    internal static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration
                .GetSection(AuthenticationConfiguration.SectionName)
                .Get<AuthenticationConfiguration>();

            if (config.Enabled == false)
            {
                // WARNING: Authentication is disabled!
                Console.WriteLine("The application has disabled authentication!");

                // This MUST be registered as a transient to prevent a bug with the AuthenticationTokenPassinghttpMessageHandler
                services.AddTransient(provider => config.UseFake
                    ? new SFM.Automation.QuickbooksImport.Application.Authentication.AuthenticationToken(config.FakeUserId, config.FakeUserName)
                    : SFM.Automation.QuickbooksImport.Application.Authentication.AuthenticationToken.Anonymous);

                return services;
            }

            // Add and configure the JWT Bearer token authentication scheme.
            services

                // .AddTransient<IProvideJwtIssuerSigningKey, JwtTokenKeyProvider>()

                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    // options.RequireHttpsMetadata = false;

                    options.SaveToken = true;
                    options.Audience = config.Audience;

                    // options.Authority = config.Authority;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidAudience = config.Audience,
                        ValidateIssuer = true,
                        ValidIssuer = config.Authority,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.FromMinutes(5),
                        NameClaimType = config.UpnClaim, // This claim is used to set the Identity.Name property of the current principal.
                    };
                    options.Events = new JwtBearerEvents
                    {
                        /*
                        OnMessageReceived = async context =>
                        {
                            var keyProvider = context.HttpContext.RequestServices.GetRequiredService<IProvideJwtIssuerSigningKey>();

                            context.Options.TokenValidationParameters.IssuerSigningKey = await keyProvider.GetSigningKey();
                        },
                        */
                        OnAuthenticationFailed = authFailed =>
                        {
                            Console.WriteLine(authFailed.Exception.ToString(), "JWT token validation failed!");
                            return Task.CompletedTask;
                        },
                    };
                });

            // Add our custom AuthenticationToken to the container. IT MUST be registered as a transient to prevent a
            // bug with the AuthenticationTokenPassingHttpMessageHandler
            services
                .AddTransient(provider =>
                {
                    var httpContext = provider
                        .GetRequiredService<IHttpContextAccessor>()
                        .HttpContext;

                    var tokenValue = httpContext
                        ?.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token")
                        .ConfigureAwait(false)
                        .GetAwaiter()
                        .GetResult();

                    if (string.IsNullOrEmpty(tokenValue))
                    {
                        Console.WriteLine("The Bearer token was not found in the request header. The current user will be treated as Anonymous.");
                        return SFM.Automation.QuickbooksImport.Application.Authentication.AuthenticationToken.Anonymous;
                    }

                    var token = new JwtSecurityToken(tokenValue);

                    var userId = token.Claims
                        .FirstOrDefault(claim => claim.Type.Equals(config.UpnClaim, StringComparison.OrdinalIgnoreCase))
                        ?.Value;

                    if (string.IsNullOrEmpty(userId))
                    {
                        Console.WriteLine("The UserId could not be determined because the 'upn' claim was not found. The current user will be treated as Anonymous.");
                        return SFM.Automation.QuickbooksImport.Application.Authentication.AuthenticationToken.Anonymous;
                    }

                    var userName = token.Claims
                        .FirstOrDefault(claim => claim.Type.Equals(config.NameClaim, StringComparison.OrdinalIgnoreCase))
                        ?.Value;

                    return new SFM.Automation.QuickbooksImport.Application.Authentication.AuthenticationToken(userId, userName, tokenValue);
                });

            return services;
        }
    }
}