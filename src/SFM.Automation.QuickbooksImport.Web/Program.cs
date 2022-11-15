using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SFM.Automation.QuickbooksImport.Data;
using SFM.Automation.QuickbooksImport.Data.Models.Quickbooks;

namespace SFM.Automation.QuickbooksImport.Web
{
    public class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<TokensContext>();

                    if (!((RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>()).Exists())
                        context.Database.Migrate();

                    // Run fluent migrator
                    scope.ServiceProvider.GetRequiredService<Migrator>().RunMigrations();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            host.Run();
        }
    }
}