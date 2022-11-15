using System.Diagnostics.CodeAnalysis;
using MediatR;
using SFM.Automation.QuickbooksImport.Domain.Correlation;

namespace SFM.Automation.QuickbooksImport.Application.Queries
{
    /// <summary>
    ///   An abstract base query class that provides implementations of various required interfaces.
    /// </summary>
    public abstract class QueryBase : IAmCorrelatable
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="QueryBase"/> class.
        /// </summary>
        /// <param name="correlationId">A unique correlation identifier provided by the client.</param>
        protected QueryBase(CorrelationId correlationId)
        {
            CorrelationId = correlationId;
        }

        /// <summary>
        ///   Gets or sets the correlation identifier for the request.
        /// </summary>
        public CorrelationId CorrelationId { get; protected set; }
    }

    /// <summary>
    ///   An abstract base query class that provides implementations of various required interfaces.
    /// </summary>
    /// <typeparam name="TResponse">The response type returned by the query.</typeparam>
    [SuppressMessage("Maintainability Rules", "SA1402", Justification = "Related class.")]
    public abstract class QueryBase<TResponse> : QueryBase, IRequest<TResponse>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="QueryBase{TResponse}"/> class.
        /// </summary>
        /// <param name="correlationId">A unique correlation identifier provided by the client.</param>
        protected QueryBase(CorrelationId correlationId)
            : base(correlationId)
        {
        }
    }
}