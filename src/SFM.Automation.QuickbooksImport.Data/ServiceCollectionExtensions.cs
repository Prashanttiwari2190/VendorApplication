using System;
using System.Data;
using System.Data.SqlClient;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// using SFM.Automation.QuickbooksImport.Data.Helper;
using SFM.Automation.QuickbooksImport.Data.Models.Quickbooks;
using SFM.Automation.QuickbooksImport.Data.Services;
using SFM.Automation.QuickbooksImport.Domain.Repositories;
using SFM.Automation.QuickbooksImport.Domain.Services;

namespace SFM.Automation.QuickbooksImport.Data
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
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services

                // Fluent Migrator
                .AddFluentMigratorCore()
                    .ConfigureRunner(runner => runner
                        .AddSqlServer()
                        .WithGlobalConnectionString(configuration.GetConnectionString("SFM.Automation.QuickbooksImport"))
                        .ScanIn(typeof(AssemblyMarker).Assembly).For.EmbeddedResources()
                        .ScanIn(typeof(AssemblyMarker).Assembly).For.Migrations())
                .AddTransient<Migrator>()

                // DB Connections
                .AddTransient<IDbConnection>(OpenConnection)

                // Other
                .AddAutoMapper(typeof(AssemblyMarker))

                // Quickbooks Services
                .AddDbContext<TokensContext>(options => options.UseSqlite(configuration.GetConnectionString("DBConnectionString")))

               // .AddTransient<IServices, Helper.Services>()
               // .Configure<OAuth2Keys>(configuration.GetSection("OAuth2Keys"))

                // Repositories
                 .AddScoped<IFleetioWorkOrderRepository, SqlFleetioWorkOrderRepository>()

                 // .AddScoped<IQuickBooksBillRepository, SqlQuickBooksBillRepository>()

                 //// Services
                 // .AddScoped<IQuickbooksBillService, HttpQuickbooksBillService>()

                 // Services
                 // .AddScoped<IQuickBooksReconcileReportService, QuickBookReportService>()
                 // .AddScoped<IQuickBooksReconcileReportRepository, SqlQuickBooksReconcileReportRepository>()

                 .AddScoped<IVendorLoginRepository, SqlVendorLoginRepository>()

                // Http Clients

                .AddHttpClient<IFleetioWorkOrderService, HttpFleetioWorkOrderService>(client =>
                   {
                       client.BaseAddress = new Uri(configuration["SFM:apis:fleetio:workOrders:url"]);
                       client.DefaultRequestHeaders.Add(configuration["SFM:apis:fleetio:auth:authorization"], configuration["SFM:apis:fleetio:auth:authorizationValue"]);
                       client.DefaultRequestHeaders.Add(configuration["SFM:apis:fleetio:auth:accounttoken"], configuration["SFM:apis:fleetio:auth:accounttokenvalue"]);
                   })
            ;

            return services;
        }

        private static SqlConnection OpenConnection(IServiceProvider provider)
        {
            var connectionString = provider
                .GetRequiredService<IConfiguration>()
                .GetConnectionString(ConnectionStrings.QuickbooksImport);

            var cnn = new SqlConnection(connectionString);
            cnn.Open();

            return cnn;
        }
    }
}