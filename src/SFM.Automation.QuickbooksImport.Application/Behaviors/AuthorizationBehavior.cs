using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SFM.Automation.QuickbooksImport.Application.Authorization;
using SFM.Automation.QuickbooksImport.Application.Exceptions;

namespace SFM.Automation.QuickbooksImport.Application.Behaviors
{
    /// <summary>
    ///   A behavior used to authorize requests.
    /// </summary>
    /// <typeparam name="TRequest">The type of request.</typeparam>
    /// <typeparam name="TResponse">The type of response.</typeparam>
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        /// <summary>
        ///   The provider used to obtain authorization data for the current user.
        /// </summary>
        private readonly IAuthorizationDataProvider authorizationDataProvider;

        /// <summary>
        ///   Initializes a new instance of the <see cref="AuthorizationBehavior{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="authorizationDataProvider">The provider used to obtain authorization data for current user.</param>
        public AuthorizationBehavior(IAuthorizationDataProvider authorizationDataProvider)
        {
            this.authorizationDataProvider = authorizationDataProvider;
        }

        /// <summary>
        ///   Authorizes the current request, or throws <see cref="NotAuthorizedException"/>.
        /// </summary>
        /// <param name="request">The request to authorize.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <param name="next">The next request in the pipeline.</param>
        /// <returns>The response from the request handler.</returns>
        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            if (request is IRequireAuthorization secureRequest)
            {
                var authorizationData = await authorizationDataProvider.GetAuthorizationData();

                if (authorizationData == null)
                    throw NotAuthorizedException.BecauseNotAuthorized();

                var activityName = secureRequest.GetType().FullName;

                if (!authorizationData.IsAuthorized(activityName))
                    throw NotAuthorizedException.BecauseForbidden(authorizationData.UserId, $"{authorizationData.UserName} is not authorized for {activityName}.");

                secureRequest.AuthorizationData = authorizationData;
            }

            return await next();
        }
    }
}