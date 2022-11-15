using McMaster.Extensions.CommandLineUtils;
using MediatR;
using System.Threading;

namespace SFM.Automation.QuickbooksImport.Cli.RootCommands
{
    /// <summary>
    ///   The root Create command.
    /// </summary>
    internal class Insert : CommandLineApplication
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="Insert"/> class.
        /// </summary>
        /// <param name="mediator">The <see cref="IMediator"/> we delegate requests to.</param>
        internal Insert(IMediator mediator)
        {
            Name = "insert";
            Description = "canary insert [resource] [options]: Creates a [resource] given a set of [options].";
            HelpOption("-?|-h|--help");
            Option("-q|--quiet", "Runs the command in quiet mode, meaning it will execute and end. Errors will be written to standard error.", CommandOptionType.NoValue);

            AddSubcommand(new WorkOrders.InsertWorkOrders(mediator));

            //Thread.Sleep(30000);
            //AddSubcommand(new Users.InsertUsers(mediator));
            //AddSubcommand(new Vehicle.InsertVehicle(mediator));

            //Thread.Sleep(30000);

            //AddSubcommand(new Vendor.InsertVendor(mediator));
            //AddSubcommand(new VehicleAssigment.InsertVehicleAssigment(mediator));
            //AddSubcommand(new InsertServiceReminders.InsertServiceReminders(mediator));

            //Thread.Sleep(30000);
            //AddSubcommand(new WorkOrders.InsertWorkOrders(mediator));
            //AddSubcommand(new InsertVehicleReminder.InsertVehicleReminder(mediator));
            //AddSubcommand(new InsertContactReminder.InsertContactReminder(mediator));

            //Thread.Sleep(30000);
            //AddSubcommand(new ServiceHistory.InsertServiceHistory(mediator));

            //Thread.Sleep(30000);
            //AddSubcommand(new Fuel.InsertFuel(mediator));
            //AddSubcommand(new InsertServiceTask.InsertServiceTask(mediator));

            OnExecute(() =>
            {
                ShowHelp();
                return 1;
            });
        }
    }
}