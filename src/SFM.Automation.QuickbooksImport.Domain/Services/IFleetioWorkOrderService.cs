using System.Collections.Generic;
using System.Threading.Tasks;
using SFM.Automation.QuickbooksImport.Domain.Models;

namespace SFM.Automation.QuickbooksImport.Domain.Services
{
    /// <summary>
    ///   A service used to locate <see cref="FleetioWorkOrder"/> information from fleetio.
    /// </summary>
    public interface IFleetioWorkOrderService
    {
        /// <summary>
        ///   Gets a list of <see cref="FleetioWorkOrder"/> objects.
        /// </summary>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        Task<IEnumerable<FleetioWorkOrder>> GetAllWorkOrders();
    }
}