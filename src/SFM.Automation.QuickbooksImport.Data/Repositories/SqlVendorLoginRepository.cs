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
    ///   A Sql based implementation of the <see cref="IVendorLoginRepository"/> interface.
    /// </summary>
    public class SqlVendorLoginRepository : IVendorLoginRepository
    {
        private readonly SqlConnection cnn;

        /// <summary>
        ///   Initializes a new instance of the <see cref="SqlVendorLoginRepository"/> class.
        /// </summary>
        /// <param name="cnn">The connection to the database to use.</param>
        public SqlVendorLoginRepository(IDbConnection cnn)
        {
            this.cnn = cnn as SqlConnection;
        }

        /// <inheritdoc/>
        public async Task<VendorLogin> VendorLogin(string userName, string password)
        {
            var vendorLoginObj = new VendorLogin();
            vendorLoginObj.UserName = userName;
            vendorLoginObj.Password = password;
            var vendorLogin = await cnn.QueryAsync<VendorLogin>("Select * FROM [VendorLogin] AS VL WHERE VL.UserName = @userName AND VL.Password = @password", vendorLoginObj);
            return vendorLogin.FirstOrDefault();
        }
    }
}