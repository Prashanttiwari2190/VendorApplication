using Newtonsoft.Json;
using SFM.Automation.QuickbooksImport.Application.Authorization;
using SFM.Automation.QuickbooksImport.Domain.Correlation;

namespace SFM.Automation.QuickbooksImport.Application.Queries
{
    /// <summary>
    ///   A query that requires authorization.
    /// </summary>
    /// <typeparam name="TResponse">The response type returned by the query.</typeparam>
    public abstract class SecureQueryBase<TResponse> : QueryBase<TResponse>, IRequireAuthorization
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="SecureQueryBase{TResponse}"/> class.
        /// </summary>
        /// <param name="correlationId">A unique correlation identifier provided by the client.</param>
        protected SecureQueryBase(CorrelationId correlationId)
            : base(correlationId)
        {
        }

        /// <inheritdoc/>
        [JsonIgnore]
        public AuthorizationData AuthorizationData { get; set; }
    }
}