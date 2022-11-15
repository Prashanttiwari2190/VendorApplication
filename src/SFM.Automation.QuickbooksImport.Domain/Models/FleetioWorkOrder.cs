namespace SFM.Automation.QuickbooksImport.Domain.Models
{
    /// <summary>
    ///   A Work Order.
    /// </summary>
    public class FleetioWorkOrder
    {
        /// <summary>
        ///   Gets or sets the id.
        /// </summary>
        public string Accounting_date { get; set; }

        /// <summary>
        ///   Gets or sets the CompletedAt.
        /// </summary>
        public string CompletedAt { get; set; }

        /// <summary>
        ///   Gets or sets the Created_at.
        /// </summary>
        public string CreatedAt { get; set; }

        /// <summary>
        ///   Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///   Gets or sets the Discount.
        /// </summary>
        public float Discount { get; set; }

        /// <summary>
        ///   Gets or sets the DiscountPercentage.
        /// </summary>
        public string DiscountPercentage { get; set; }

        /// <summary>
        ///   Gets or sets the DiscountType.
        /// </summary>
        public string DiscountType { get; set; }

        /// <summary>
        ///   Gets or sets the WorkOrderKY.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///   Gets or sets the Issued_At.
        /// </summary>
        public string IssuedAt { get; set; }

        /// <summary>
        ///   Gets or sets the Number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        ///   Gets or sets the Purchase Order Number.
        /// </summary>
        public string PurchaseOrderNumber { get; set; }

        /// <summary>
        ///   Gets or sets the Tax1.
        /// </summary>
        public string Tax1 { get; set; }

        /// <summary>
        ///   Gets or sets the Tax1percentage.
        /// </summary>
        public string Tax1Percentage { get; set; }

        /// <summary>
        ///   Gets or sets the Tax1Type.
        /// </summary>
        public string Tax1Type { get; set; }

        /// <summary>
        ///   Gets or sets the Tax2.
        /// </summary>
        public string Tax2 { get; set; }

        /// <summary>
        ///   Gets or sets the Tax2percentage.
        /// </summary>
        public string Tax2Percentage { get; set; }

        /// <summary>
        ///   Gets or sets the Tax2Type.
        /// </summary>
        public string Tax2Type { get; set; }

        /// <summary>
        ///   Gets or sets the Total_Amount.
        /// </summary>
        public string TotalAmount { get; set; }

        /// <summary>
        ///   Gets or sets the Updated_at.
        /// </summary>
        public string UpdatedAt { get; set; }

        /// <summary>
        ///   Gets or sets the VehicleKY.
        /// </summary>
        public string VehicleId { get; set; }

        /// <summary>
        ///   Gets or sets the VehicleName.
        /// </summary>
        public string VehicleName { get; set; }

        /// <summary>
        ///   Gets or sets the VendorKY.
        /// </summary>
        public string VendorId { get; set; }

        /// <summary>
        ///   Gets or sets the VendorName.
        /// </summary>
        public string VendorName { get; set; }

        /// <summary>
        ///   Gets or sets the WorkOrderId.
        /// </summary>
        public int WorkOrderId { get; set; }

        /// <summary>
        ///   Gets or sets the WorkOrderStatusName.
        /// </summary>
        public string WorkOrderStatusName { get; set; }
    }
}