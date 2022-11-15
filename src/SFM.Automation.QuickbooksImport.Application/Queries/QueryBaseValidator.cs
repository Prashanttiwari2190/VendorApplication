using Edf.Services.Billing.Application.Validation;
using FluentValidation;

namespace SFM.Automation.QuickbooksImport.Application.Queries
{
    /// <summary>
    ///   Base validator for <see cref="QueryBase{TResponse}"/> objects.
    /// </summary>
    /// <typeparam name="TQuery">An type of <see cref="QueryBase"/>.</typeparam>
    public class QueryBaseValidator<TQuery> : AbstractValidator<TQuery>
        where TQuery : QueryBase
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="QueryBaseValidator{TQuery}"/> class.
        /// </summary>
        public QueryBaseValidator()
        {
            RuleFor(x => x.CorrelationId).NotNull().SetValidator(new CorrelationIdValidator());
        }
    }
}