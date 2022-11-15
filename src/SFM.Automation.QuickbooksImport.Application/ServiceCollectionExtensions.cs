using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SFM.Automation.QuickbooksImport.Application.Behaviors;

namespace SFM.Automation.QuickbooksImport.Application
{
    /// <summary>
    ///   Extension methods for <see cref="IServiceCollection"/> used to register dependencies with the IoC container.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///   Registers all the application layer dependencies with the IoC container.
        /// </summary>
        /// <param name="services">The container service collection.</param>
        /// <param name="configuration">The application configuration.</param>
        /// <returns>The populated <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddMediatRServices(configuration)
                .AddFluentValidation()
                ;

            return services;
        }

        private static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            /* NOTE:
             * The AssemblyScanner we use below will find the validators. However, it only finds them if the
             * validator classes are public. That sucks because ideally we sould make the validators internal
             * classes. We "could" write our own assembly scanner, but for now just use what we have.
             */
            FluentValidation.AssemblyScanner
                .FindValidatorsInAssemblyContaining<AssemblyMarker>()
                .ForEach(result => services.AddTransient(result.InterfaceType, result.ValidatorType));

            return services;
        }

        private static IServiceCollection AddMediatRServices(this IServiceCollection services, IConfiguration configuration)
        {
            /* NOTE: The MetricsBehavior MUST be registered before the ValidateBehavior. Otherwise,
             * validation errors will not be captured in the metric. The logging behavior should
             * likewise be registered before the metrics behavior, so that any errors arising from
             * collecting metrics or validation get logged. As a general rule, always put the logging
             * behavior first in the list of pipeline components.
             * */
            services
                .AddMediatR(typeof(AssemblyMarker))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidateBehavior<,>))

                // .AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>))

                ;

            return services;
        }
    }
}