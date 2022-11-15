using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SFM.Automation.QuickbooksImport.Data.Models.Fleetio;

namespace SFM.Automation.QuickbooksImport.Data
{
    /// <summary>
    ///   A service used to locate WorkOrder information from fleetio.
    /// </summary>
    public interface IWorkOrderService
    {
        /// <summary>
        ///   Gets a list of <see cref="WorkOrder"/> objects.
        /// </summary>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        Task<IEnumerable<WorkOrder>> GetAllWorkOrders();
    }
}