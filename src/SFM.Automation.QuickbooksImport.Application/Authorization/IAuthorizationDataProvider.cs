using System.Threading.Tasks;

namespace SFM.Automation.QuickbooksImport.Application.Authorization
{
    /// <summary>
    ///   The interface that defines a contract for obtaining authorization data for the current user.
    /// </summary>
    public interface IAuthorizationDataProvider
    {
        /// <summary>
        ///   Gets the authorization data for the current user.
        /// </summary>
        /// <returns>Returns <see cref="AuthorizationData"/>.</returns>
        Task<AuthorizationData> GetAuthorizationData();
    }
}