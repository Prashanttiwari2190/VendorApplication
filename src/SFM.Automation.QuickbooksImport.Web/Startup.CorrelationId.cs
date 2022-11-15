using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SFM.Automation.QuickbooksImport.Domain.Correlation;

namespace SFM.Automation.QuickbooksImport.Web
{
    /// <summary>
    ///   Extensions for an <see cref="IServiceCollection"/> object.
    /// </summary>
    internal static partial class ServiceCollectionExtensions
    {
        /// <summary>
        ///   Adds the <see cref="CorrelationId"/> class to the container so it can be injected.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to extend.</param>
        /// <returns>Returns the <paramref name="services"/> instance.</returns>
        public static IServiceCollection AddCorrelationId(this IServiceCollection services)
        {
            // This MUST be registered as transient to prevent a bug in the CorrelationIdTokenPassingMessageHandler
            return services.AddTransient(GetCorrelationId);
        }

        /// <summary>
        ///   Creates an injectable <see cref="CorrelationId"/> by grabbing the value out of the 'gsfs-correlation-id'
        ///   HTTP header.
        /// </summary>
        private static CorrelationId GetCorrelationId(IServiceProvider serviceProvider)
        {
            var httpContext = serviceProvider
                .GetRequiredService<IHttpContextAccessor>()
                .HttpContext;

            var headerValue = httpContext?.Request.Headers
                .FirstOrDefault(x => x.Key.Equals(CorrelationId.HttpHeaderName, StringComparison.InvariantCultureIgnoreCase)).Value;

            return Guid.TryParse(headerValue, out var value)
                ? new CorrelationId(value)
                : new CorrelationId(Guid.NewGuid());
        }
    }
}