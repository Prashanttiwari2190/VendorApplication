using McMaster.Extensions.CommandLineUtils;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SFM.Automation.QuickbooksImport.Application;
using SFM.Automation.QuickbooksImport.Data;
using System;
using System.IO;
using System.Linq;

namespace SFM.Automation.QuickbooksImport.Cli
{
    internal class Program : CommandLineApplication
    {
        public Program(IMediator mediator)
        {
            Description = $"SFM DW Console APP";
            HelpOption("-?|-h|--help");
            Option("-q|--quiet", "Runs the command in quiet mode, meaning it will execute and end. Errors will be written to standard error.", CommandOptionType.NoValue);

            AddSubcommand(new RootCommands.Insert(mediator));
        }

        private static void Main(string[] args)
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json", optional: true)

                    .Build();

                //Log.Logger = new LoggerConfiguration()
                //    .Enrich.FromLogContext()
                //    .WriteTo.Console()
                //    .CreateLogger();

                //var metrics = new MetricsBuilder()
                //    .Report.ToConsole()
                //    .Build();

                var serviceProvider = new ServiceCollection()
                    .AddSingleton<IConfiguration>(configuration)
                    //.AddSingleton<IMetrics>(metrics)
                    .AddOptions()
                    .AddApplicationServices(configuration)
                    .AddDataServices(configuration)
                    .BuildServiceProvider();

                // Put the database update into a scope to ensure that all resources will be disposed.
                using (var scope = serviceProvider.CreateScope())
                {
                    // Instantiate the runner
                    scope.ServiceProvider.GetRequiredService<Migrator>().RunMigrations();
                }

                var mediator = serviceProvider
                    .GetRequiredService<IMediator>();

                new Program(mediator).Execute(args);
            }
            catch (Exception e)
            {
                Log.Error(e, "[CLI]==> {Args}{NewLine}[CLI]<== ERROR: {Message}",
                    string.Join(' ', args?.Where(arg => !string.IsNullOrWhiteSpace(arg))),
                    Environment.NewLine,
                    e.Message);
            }
            finally
            {
                if (!new CommandOption("-q|--quiet", CommandOptionType.NoValue).HasValue())
                {
                    Console.WriteLine();
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                }
                //Log.CloseAndFlush();
            }
        }
    }
}