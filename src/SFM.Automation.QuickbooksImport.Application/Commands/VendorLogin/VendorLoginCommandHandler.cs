using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SFM.Automation.QuickbooksImport.Application.Commands.VendorLogin;
using SFM.Automation.QuickbooksImport.Domain.Models;
using SFM.Automation.QuickbooksImport.Domain.Repositories;
using SFM.Automation.QuickbooksImport.Domain.Services;

namespace SFM.Automation.QuickbooksImport.Application.Commands.VendorWorkOrder
{
    /// <summary>
    ///   The handler for the <see cref="VendorLoginCommand"/>.
    /// </summary>
    public class VendorLoginCommandHandler : IRequestHandler<VendorLoginCommand, string>
    {
        private readonly IVendorLoginRepository vendorLoginRepository;

        /// <summary>
        ///   Initializes a new instance of the <see cref="VendorLoginCommandHandler"/> class.
        /// </summary>
        /// <param name="vendorLoginRepository">
        ///   The repository responsible for saving <see cref="IVendorLoginRepository"/> objects.
        /// </param>
        public VendorLoginCommandHandler(IVendorLoginRepository vendorLoginRepository)
        {
            this.vendorLoginRepository = vendorLoginRepository;
        }

        /// <summary>
        ///   The handler for the <see cref="VendorLoginCommand"/>.
        /// </summary>
        /// <param name="request">The <see cref="VendorLoginCommand"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>Returns a <see cref="Task"/>.</returns>
        public async Task<string> Handle(VendorLoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // add bills data into database from quickbooks.
                var vendorLogin = await vendorLoginRepository.VendorLogin(request.Username, request.Password);

                return vendorLogin.VendorName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}