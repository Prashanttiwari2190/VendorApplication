using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace SFM.Automation.QuickbooksImport.Web
{
    /// <summary>
    ///   Extensions for an <see cref="IApplicationBuilder"/> object.
    /// </summary>
    internal static partial class ApplicationBuilderExtensions
    {
        internal static IApplicationBuilder UseApiVersioningMiddleware(this IApplicationBuilder app)
            => app.UseApiVersioning();
    }

    /// <summary>
    ///   Extensions for an <see cref="IServiceCollection"/> object.
    /// </summary>
    [SuppressMessage("Maintainability Rules", "SA1402", Justification = "Related Extensions")]
    internal static partial class ServiceCollectionExtensions
    {
        internal static IServiceCollection AddApiVersioningServices(this IServiceCollection services)
        {
            return services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });
        }
    }
}