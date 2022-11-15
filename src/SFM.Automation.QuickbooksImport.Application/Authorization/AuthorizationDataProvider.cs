using System.Net.Http;
using System.Threading.Tasks;
using SFM.Automation.QuickbooksImport.Application.Authentication;

namespace SFM.Automation.QuickbooksImport.Application.Authorization
{
    /// <summary>
    ///   An application service that wraps the authorization api.
    /// </summary>
    public class AuthorizationDataProvider : IAuthorizationDataProvider
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="AuthorizationDataProvider"/> class.
        /// </summary>
        /// <param name="authenticationToken">The authentication token for the current user.</param>
        /// <param name="client">The http client configured with the authorization service endpoint.</param>
        public AuthorizationDataProvider(
            AuthenticationToken authenticationToken,
            HttpClient client)
        {
            AuthenticationToken = authenticationToken;
            Client = client;
        }

        /// <summary>
        ///   Gets the authentication token for the current user.
        /// </summary>
        protected AuthenticationToken AuthenticationToken { get; }

        /// <summary>
        ///   Gets the http client configured with the authorization service endpoint.
        /// </summary>
        protected HttpClient Client { get; }

        /// <summary>
        ///   Gets the <see cref="AuthorizationData"/> applicable for the current application, tenant, and user.
        /// </summary>
        /// <returns>Returns <see cref="AuthorizationData"/>.</returns>
        public Task<AuthorizationData> GetAuthorizationData()
        {
            if (AuthenticationToken.IsAnonymous)
                return null;

            return Task.FromResult(new AuthorizationData(AuthenticationToken.UserId, AuthenticationToken.UserName, new string[] { }));
        }
    }
}