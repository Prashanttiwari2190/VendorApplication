using System.Collections.Generic;
using System.Threading.Tasks;
using SFM.Automation.QuickbooksImport.Domain.Models;

namespace SFM.Automation.QuickbooksImport.Domain.Repositories
{
    /// <summary>
    ///   A repository for managing <see cref="VendorLogin"/> objects.
    /// </summary>
    public interface IVendorLoginRepository
    {
        /// <summary>
        ///   Inserts a list of <see cref="VendorLogin"/> objects into the repository.
        /// </summary>
        /// <param name="userName">userName.</param>
        /// <param name="password">password.</param>
        /// <returns>Returns a Task.</returns>
        Task<VendorLogin> VendorLogin(string userName, string password);
    }
}