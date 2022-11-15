using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFM.Automation.QuickbooksImport.Data.Models.Fleetio
{
    /// <summary>
    ///   A Group model coming from Fleetio.
    /// </summary>
    public class AccountCustomFields
    {
        /// <summary>
        ///   Gets or sets the id.
        /// </summary>
        [JsonProperty("accounting_date")]
        public string Accounting_date { get; set; }
    }
}