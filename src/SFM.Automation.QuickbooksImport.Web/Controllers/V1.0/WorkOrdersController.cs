using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SFM.Automation.QuickbooksImport.Domain.Correlation;

namespace SFM.Automation.QuickbooksImport.Web.Controllers.V1
{
    /// <summary>
    ///   Handles requests pertaining to invoices.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Invoice")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/{tenantId}/work-orders")]
    public class WorkOrdersController : Controller
    {
        private readonly CorrelationId correlationId;
        private readonly ILogger<WorkOrdersController> logger;
        private readonly IMediator mediator;

        /// <summary>
        ///   Initializes a new instance of the <see cref="WorkOrdersController"/> class.
        /// </summary>
        /// <param name="mediator">The <see cref="IMediator"/> resposible for delegating requests.</param>
        /// <param name="correlationId">The <see cref="CorrelationId"/> associated with the request.</param>
        /// <param name="logger">The <see cref="ILogger"/> used for logging.</param>
        public WorkOrdersController(IMediator mediator, CorrelationId correlationId, ILogger<WorkOrdersController> logger)
        {
            this.mediator = mediator;
            this.correlationId = correlationId;
            this.logger = logger;
        }
    }
}