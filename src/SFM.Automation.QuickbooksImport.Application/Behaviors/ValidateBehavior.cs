using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SFM.Automation.QuickbooksImport.Application.Exceptions;

namespace SFM.Automation.QuickbooksImport.Application.Behaviors
{
    /// <summary>
    ///   A behavior used to validate requests.
    /// </summary>
    /// <typeparam name="TRequest">The type of request.</typeparam>
    /// <typeparam name="TResponse">The type of response.</typeparam>
    internal class ValidateBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        /// <summary>
        ///   The collection of validators for the request.
        /// </summary>
        private readonly IEnumerable<IValidator<TRequest>> validators;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ValidateBehavior{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="validators">The collection of validators for the request.</param>
        public ValidateBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        /// <summary>
        ///   Validates the current request, or throws <see cref="InvalidCommandOrQueryException"/>.
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
            var failures = validators
                .Select(validator => validator.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null);

            if (failures.Any())
            {
                throw new InvalidCommandOrQueryException(
                    $"Validation failed for {TypeNameHelper.GetTypeDisplayName(typeof(TRequest), false)}.",
                    failures.Select(x => x.ErrorMessage),
                    new ValidationException(failures.ToList()));
            }

            return await next();
        }
    }
}