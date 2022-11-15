using AutoMapper;
using Newtonsoft.Json;
using SFM.Automation.QuickbooksImport.Data.Models.Fleetio;
using SFM.Automation.QuickbooksImport.Domain.Models;
using SFM.Automation.QuickbooksImport.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SFM.Automation.QuickbooksImport.Data.Services
{
    /// <summary>
    ///   An HTTP implementation of the <see cref="IFleetioWorkOrderService"/> interface.
    /// </summary>
    public class HttpFleetioWorkOrderService : IFleetioWorkOrderService
    {
        private readonly HttpClient client;
        private readonly IMapper mapper;

        /// <summary>
        ///   Initializes a new instance of the <see cref="HttpFleetioWorkOrderService"/> class.
        /// </summary>
        /// <param name="client">A pre-configured <see cref="HttpClient"/> used to access the Fleetio API.</param>
        /// <param name="mapper">An Automapper <see cref="IMapper"/> instance.</param>
        public HttpFleetioWorkOrderService(HttpClient client, IMapper mapper)
        {
            this.client = client;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<FleetioWorkOrder>> GetAllWorkOrders()
        {
            var value = new List<WorkOrder>();
            var workOrderList = default(IEnumerable<WorkOrder>);

            var olderdate = new DateTime(2021, 02, 28);
            var currentdate = DateTime.UtcNow;
            var currentPage = 0;

            // Logic for pagination on the HTTP call.
            do
            {
                currentPage = 0;
                olderdate = olderdate.AddDays(1);
                {
                    do
                    {
                        {
                            // var result = await client.GetAsync($"?q[custom_field_accounting_date_eq ]={new
                            // DateTime(2021, 03, 11).ToUniversalTime():yyyy-MM-dd}&q[custom_field_accounting_date_lteq]={DateTime.UtcNow:yyyy-MM-dd}&page="
                            // + currentPage + string.Empty);
                            currentPage++;
                            var result = await client.GetAsync($"?q[custom_field_accounting_date_eq]={olderdate.ToUniversalTime():yyyy-MM-dd}&page=" + currentPage + string.Empty);

                            if (result.IsSuccessStatusCode)
                            {
                                var content = result.Content.ReadAsStringAsync();

                                workOrderList = JsonConvert.DeserializeObject<IEnumerable<WorkOrder>>(content.Result);

                                value.AddRange(workOrderList);

                                // if (workOrderList.Count() == 100) { continue; }

                                // break;
                            }
                        }
                    }
                    while (workOrderList.Any())
                    ;
                }
            }
            while (olderdate <= currentdate);

            return value.Select(i => mapper.Map<WorkOrder, FleetioWorkOrder>(i));
        }
    }
}