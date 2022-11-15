using MediatR;
using SFM.Automation.QuickbooksImport.Domain.Models;

namespace SFM.Automation.QuickbooksImport.Application.Commands.ImportFleetioWorkOrders
{
    /// <summary>
    ///   A command to Import <see cref="FleetioWorkOrder"/> objects from Fleetio API.
    /// </summary>
    public class ImportFleetioWorkOrdersCommand : Command<Unit>
    {
    }
}