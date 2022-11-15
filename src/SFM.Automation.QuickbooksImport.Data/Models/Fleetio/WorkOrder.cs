using Newtonsoft.Json;

namespace SFM.Automation.QuickbooksImport.Data.Models.Fleetio
{
    /// <summary>
    ///   A Work Order model from the Fleetio Api.
    /// </summary>
    public class WorkOrder
    {
        /// <summary>
        ///   Gets or sets the CompletedAt.
        /// </summary>
        [JsonProperty("completed_at")]
        public string CompletedAt { get; set; }

        /// <summary>
        ///   Gets or sets the Created_at.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        ///   Gets or sets the CustomFields.
        /// </summary>
        [JsonProperty("custom_fields")]
        public AccountCustomFields CustomFields { get; set; }

        /// <summary>
        ///   Gets or sets the Description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        ///   Gets or sets the Discount.
        /// </summary>
        [JsonProperty("discount")]
        public float Discount { get; set; }

        /// <summary>
        ///   Gets or sets the DiscountPercentage.
        /// </summary>
        [JsonProperty("discount_percentage")]
        public string DiscountPercentage { get; set; }

        /// <summary>
        ///   Gets or sets the DiscountType.
        /// </summary>
        [JsonProperty("discount_type")]
        public string DiscountType { get; set; }

        /// <summary>
        ///   Gets or sets the Id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///   Gets or sets the Issued_At.
        /// </summary>
        [JsonProperty("issued_at")]
        public string IssuedAt { get; set; }

        /// <summary>
        ///   Gets or sets the Number.
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <summary>
        ///   Gets or sets the purchase_order_number.
        /// </summary>
        [JsonProperty("purchase_order_number")]
        public string Purchase_Order_Number { get; set; }

        /// <summary>
        ///   Gets or sets the Tax1.
        /// </summary>
        [JsonProperty("tax_1")]
        public string Tax1 { get; set; }

        /// <summary>
        ///   Gets or sets the Tax1percentage.
        /// </summary>
        [JsonProperty("tax_1_percentage")]
        public string Tax1Percentage { get; set; }

        /// <summary>
        ///   Gets or sets the Tax1Type.
        /// </summary>
        [JsonProperty("tax_1_type")]
        public string Tax1Type { get; set; }

        /// <summary>
        ///   Gets or sets the Tax2.
        /// </summary>
        [JsonProperty("tax_2")]
        public string Tax2 { get; set; }

        /// <summary>
        ///   Gets or sets the Tax2percentage.
        /// </summary>
        [JsonProperty("tax_2_percentage")]
        public string Tax2Percentage { get; set; }

        /// <summary>
        ///   Gets or sets the Tax2Type.
        /// </summary>
        [JsonProperty("tax_2_type")]
        public string Tax2Type { get; set; }

        /// <summary>
        ///   Gets or sets the Total_Amount.
        /// </summary>
        [JsonProperty("total_amount")]
        public string Total_Amount { get; set; }

        /// <summary>
        ///   Gets or sets the Updated_at.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        /// <summary>
        ///   Gets or sets the VehicleKY.
        /// </summary>
        [JsonProperty("vehicle_id")]
        public string VehicleId { get; set; }

        /// <summary>
        ///   Gets or sets the VehicleName.
        /// </summary>
        [JsonProperty("vehicle_name")]
        public string VehicleName { get; set; }

        /// <summary>
        ///   Gets or sets the VendorKY.
        /// </summary>
        [JsonProperty("vendor_id")]
        public string VendorId { get; set; }

        /// <summary>
        ///   Gets or sets the VendorName.
        /// </summary>
        [JsonProperty("vendor_name")]
        public string VendorName { get; set; }

        /// <summary>
        ///   Gets or sets the WorkOrderId.
        /// </summary>
        public int WorkOrderId { get; set; }

        /// <summary>
        ///   Gets or sets the WorkOrderId.
        /// </summary>
        [JsonProperty("work_order_status_name")]
        public string WorkOrderStatusName { get; set; }
    }
}