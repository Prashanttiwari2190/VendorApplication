using Newtonsoft.Json;

namespace SFM.Automation.QuickbooksImport.Data.Models.Quickbooks
{
    public class WorkOrder
    {
        /// <summary>
        ///   Gets or sets the Bill_Amount.
        /// </summary>
        [JsonProperty("bill_amount")]
        public string BillAmount { get; set; }

        /// <summary>
        ///   Gets or sets the Bill_date.
        /// </summary>
        [JsonProperty("bill_date")]
        public string BillDate { get; set; }

        /// <summary>
        ///   Gets or sets the Bill_No.
        /// </summary>
        [JsonProperty("bill_no")]
        public string BillNo { get; set; }

        /// <summary>
        ///   Gets or sets the Category.
        /// </summary>
        [JsonProperty("category")]
        public string Category { get; set; }

        /// <summary>
        ///   Gets or sets the Category_Description.
        /// </summary>
        [JsonProperty("category_description")]
        public string CategoryDescription { get; set; }

        /// <summary>
        ///   Gets or sets the Customer.
        /// </summary>
        [JsonProperty("customer")]
        public string Customer { get; set; }

        /// <summary>
        ///   Gets or sets the Due_date.
        /// </summary>
        [JsonProperty("due_date")]
        public string DueDate { get; set; }

        /// <summary>
        ///   Gets or sets the Id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        ///   Gets or sets the Terms.
        /// </summary>
        [JsonProperty("terms")]
        public string Terms { get; set; }

        /// <summary>
        ///   Gets or sets the Customer.
        /// </summary>
        [JsonProperty("txn_date")]
        public string TxnDate { get; set; }

        /// <summary>
        ///   Gets or sets the Vendor.
        /// </summary>
        [JsonProperty("vendor")]
        public string Vendor { get; set; }

        /// <summary>
        ///   Gets or sets the Vendor_Mailing_Address.
        /// </summary>
        [JsonProperty("vendor_mailing_address")]
        public string VendorMailingAddress { get; set; }
    }
}