using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace SFM.Automation.QuickbooksImport.Data
{
    /// <summary>
    ///   A static helper class for dealing with connection strings.
    /// </summary>
    public static class ConnectionStrings
    {
        /// <summary>
        ///   Defines the name of the Soar Retail database.
        /// </summary>
        public const string QuickbooksImport = "SFM.Automation.QuickbooksImport";

        /// <summary>
        ///   This method used by the data migrations.
        /// </summary>
        /// <param name="configuration">An <see cref="IConfiguration"/> object containing the application configuration.</param>
        /// <returns>Returns the name of the default database.</returns>
        public static string GetDatabaseName(this IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(QuickbooksImport);
            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

            return connectionStringBuilder.InitialCatalog;
        }

        /// <summary>
        ///   This method used by the data migrations.
        /// </summary>
        /// <param name="configuration">An <see cref="IConfiguration"/> object containing the application configuration.</param>
        /// <returns>Returns the connection string for the master database.</returns>
        public static string GetDatabaseServerConnectionString(this IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(QuickbooksImport);
            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString) { InitialCatalog = "master" };

            return connectionStringBuilder.ToString();
        }
    }
}