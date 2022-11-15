using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using SFM.Automation.QuickbooksImport.Domain.Correlation;

namespace SFM.Automation.QuickbooksImport.Application.Behaviors
{
    /// <summary>
    ///   A behavior used to log requests and any exceptions that occur.
    /// </summary>
    /// <typeparam name="TRequest">The type of request.</typeparam>
    /// <typeparam name="TResponse">The type of response.</typeparam>
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> logger;

        /// <summary>
        ///   Initializes a new instance of the <see cref="LoggingBehavior{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="logger">The diagnostic logger to use.</param>
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        ///   Logs the current request, as well as any exception that may occur.
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
            var dictionary = new Dictionary<string, object>
            {
                { "CorrelationId", (request as IAmCorrelatable)?.CorrelationId.Value ?? Guid.Empty },
            };

            using (logger.BeginScope(dictionary))
            {
                try
                {
                    logger.LogTrace(
                        "[APPL]==> {Request}",
                        TypeNameHelper.GetTypeDisplayName(typeof(TRequest), false));

                    var response = await next();

                    if (response != null)
                    {
                        var temp = TypeNameHelper.BuiltInTypeNames.ContainsKey(typeof(TResponse)) || response is Guid
                                ? response.ToString()
                                : TypeNameHelper.GetTypeDisplayName(typeof(TResponse), false);

                        logger.LogDebug(
                            "[APPL]==> {Request}\n[APPL]<== OK: {Response}",
                            TypeNameHelper.GetTypeDisplayName(typeof(TRequest), false),
                            temp);
                    }
                    else
                    {
                        logger.LogDebug(
                            "[APPL]==> {Request}\n[APPL]<== OK",
                            TypeNameHelper.GetTypeDisplayName(typeof(TRequest), false));
                    }

                    return response;
                }
                catch (AggregateException e)
                {
                    logger.LogError(
                        e.InnerException.Demystify(),
                        "[APPL]==> {Request}\n[APPL]<== ERROR {StatusCode}: {Message}",
                        TypeNameHelper.GetTypeDisplayName(typeof(TRequest), false),
                        GetStatusCode(e.InnerException),
                        e.InnerException.Message);

                    throw;
                }
                catch (Exception e)
                {
                    logger.LogError(
                        e.Demystify(),
                        "[APPL]==> {Request}\n[APPL]<== ERROR {StatusCode}: {Message}",
                        TypeNameHelper.GetTypeDisplayName(typeof(TRequest), false),
                        GetStatusCode(e),
                        e.Message);

                    throw;
                }
            }
        }

        private int GetStatusCode(Exception e)
        {
            int? result = e.GetType().GetProperty("StatusCode")?.GetValue(e) as int?;

            return result ?? 500;
        }
    }
}