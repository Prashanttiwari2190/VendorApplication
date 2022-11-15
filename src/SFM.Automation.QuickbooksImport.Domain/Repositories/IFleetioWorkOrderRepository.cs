using System.Collections.Generic;
using System.Threading.Tasks;
using SFM.Automation.QuickbooksImport.Domain.Models;

namespace SFM.Automation.QuickbooksImport.Domain.Repositories
{
    /// <summary>
    ///   A repository for managing <see cref="FleetioWorkOrder"/> objects.
    /// </summary>
    public interface IFleetioWorkOrderRepository
    {
        /// <summary>
        ///   Inserts a list of <see cref="FleetioWorkOrder"/> objects into the repository.
        /// </summary>
        /// <param name="workOrders">A list of <see cref="FleetioWorkOrder"/> objects to insert.</param>
        /// <returns>Returns a Task.</returns>
        Task<int> InsertWorkOrder(IEnumerable<FleetioWorkOrder> workOrders);
    }
}