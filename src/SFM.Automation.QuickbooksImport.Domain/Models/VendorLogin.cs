namespace SFM.Automation.QuickbooksImport.Domain.Models
{
    /// <summary>
    ///   A Work Order.
    /// </summary>
    public class VendorLogin
    {
        /// <summary>
        ///   Gets or sets the id.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///   Gets or sets the VehicleName.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///   Gets or sets the VendorKY.
        /// </summary>
        public string VendorId { get; set; }

        /// <summary>
        ///   Gets or sets the VendorName.
        /// </summary>
        public string VendorName { get; set; }
    }
}