using Dapper;
using SFM.Automation.QuickbooksImport.Domain.Models;
using SFM.Automation.QuickbooksImport.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SFM.Automation.QuickbooksImport.Data
{
    /// <summary>
    ///   A Sql based implementation of the <see cref="IFleetioWorkOrderRepository"/> interface.
    /// </summary>
    public class SqlFleetioWorkOrderRepository : IFleetioWorkOrderRepository
    {
        private readonly SqlConnection cnn;

        /// <summary>
        ///   Initializes a new instance of the <see cref="SqlFleetioWorkOrderRepository"/> class.
        /// </summary>
        /// <param name="cnn">The connection to the database to use.</param>
        public SqlFleetioWorkOrderRepository(IDbConnection cnn)
        {
            this.cnn = cnn as SqlConnection;
        }

        /// <inheritdoc/>
        public Task<int> InsertWorkOrder(IEnumerable<FleetioWorkOrder> workOrderData)
        {
            Task.Run(() => cnn.ExecuteAsync("TRUNCATE TABLE Fleetio_Raw_Data"));
            return Task.Run(() => cnn.ExecuteAsync("INSERT INTO Fleetio_Raw_Data (Number, PurchaseOrderNumber,Tax1Type, Tax1Value, Tax2Type, Tax2Value, TotalAmount, CreatedAt, UpdatedAt, VehicleId, VehicleName,VendorId, WorkOrderId, WorkOrderStatusName, CompletedAt, Description, Discount, DiscountPercentage,DiscountType, VendorName, IssuedAt,Accounting_date) VALUES(@Number, @PurchaseOrderNumber, @Tax1Type, @Tax1Percentage, @Tax2Type,@Tax2Percentage, @TotalAmount, @CreatedAt, @UpdatedAt, @VehicleId, @VehicleName, @VendorId, @Id,@WorkOrderStatusName, @CompletedAt, @Description, @Discount, @DiscountPercentage, @DiscountType,@VendorName, @IssuedAt, @Accounting_date); ", workOrderData));
        }
    }
}