using McMaster.Extensions.CommandLineUtils;
using MediatR;
using Serilog;
using SFM.Automation.QuickbooksImport.Application.Commands.ImportFleetioWorkOrders;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SFM.Automation.QuickbooksImport.Cli.WorkOrders
{
    public class InsertWorkOrders : CommandLineApplication
    {
        /// <summary>
        ///   The command used to create an WorkOrders.
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        ///   Initializes a new instance of the <see cref="InsertVehicle"/> class.
        /// </summary>
        /// <param name="mediator">The <see cref="IMediator"/> we delegate requests to.</param>

        /// <summary>
        ///   Initializes a new instance of the <see cref="InsertAssets"/> class.
        /// </summary>
        /// <param name="mediator">The <see cref="IMediator"/> we delegate requests to.</param>

        public InsertWorkOrders(IMediator mediator)
        {
            this.mediator = mediator;

            Name = "WorkOrders";
            Description = "create WorkOrders: Get the Assets data from MX Terminal.";

            int result = Task.Run(async () => await Run()).GetAwaiter().GetResult();
        }

        private async Task<int> Run()
        {
            try
            {
                var request = new ImportFleetioWorkOrdersCommand();
                var response = await mediator.Send(request, CancellationToken.None);

                Console.WriteLine($"WorkOrders were inserted successfully.");

                return 0;
            }
            catch (Exception e)
            {
                Log.Error(e, "[CLI]==> {Command}{NewLine}[CLI]<== ERROR: {Message}",
                    GetType().Name,
                    Environment.NewLine,
                    e.Message);
                return 1;
            }
        }
    }
}