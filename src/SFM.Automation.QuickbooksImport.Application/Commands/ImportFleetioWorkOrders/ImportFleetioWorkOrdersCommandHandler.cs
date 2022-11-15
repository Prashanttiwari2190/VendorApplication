using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SFM.Automation.QuickbooksImport.Domain.Models;
using SFM.Automation.QuickbooksImport.Domain.Repositories;
using SFM.Automation.QuickbooksImport.Domain.Services;

namespace SFM.Automation.QuickbooksImport.Application.Commands.ImportFleetioWorkOrders
{
    /// <summary>
    ///   The handler for the <see cref="ImportFleetioWorkOrdersCommand"/>.
    /// </summary>
    public class ImportFleetioWorkOrdersCommandHandler : IRequestHandler<ImportFleetioWorkOrdersCommand, Unit>
    {
        private readonly IFleetioWorkOrderRepository workOrderRepository;
        private readonly IFleetioWorkOrderService workOrderService;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ImportFleetioWorkOrdersCommandHandler"/> class.
        /// </summary>
        /// <param name="workOrderService">The service responsible for querying <see cref="FleetioWorkOrder"/> objcets.</param>
        /// <param name="workOrderRepository">
        ///   The repository responsible for saving <see cref="IFleetioWorkOrderRepository"/> objects.
        /// </param>
        public ImportFleetioWorkOrdersCommandHandler(IFleetioWorkOrderService workOrderService, IFleetioWorkOrderRepository workOrderRepository)
        {
            this.workOrderService = workOrderService;
            this.workOrderRepository = workOrderRepository;
        }

        /// <summary>
        ///   The handler for the <see cref="ImportFleetioWorkOrdersCommand"/>.
        /// </summary>
        /// <param name="request">The <see cref="ImportFleetioWorkOrdersCommand"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        public async Task<Unit> Handle(ImportFleetioWorkOrdersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var workOrders = await workOrderService.GetAllWorkOrders();

                await workOrderRepository.InsertWorkOrder(workOrders);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}