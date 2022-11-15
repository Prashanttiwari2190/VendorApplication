using System;
using FluentValidation;
using SFM.Automation.QuickbooksImport.Domain.Correlation;

namespace Edf.Services.Billing.Application.Validation
{
    /// <summary>
    ///   Validator for <see cref="CorrelationId"/> objects.
    /// </summary>
    public class CorrelationIdValidator : AbstractValidator<CorrelationId>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="CorrelationIdValidator"/> class.
        /// </summary>
        public CorrelationIdValidator()
        {
            RuleFor(i => i.Value).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}