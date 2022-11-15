using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using FluentAssertions;
using Xunit;

namespace SMF.Automation.QuickbooksImport.Data.IntegrationTests.Prerequisites.DbTestBaseTests
{
    /// <summary>
    ///   Tests for DbTestBase.Dispose method.
    /// </summary>
    public class DisposeShould : DbTestBase
    {
        /// <summary>
        ///   A test to ensure that the Integration Test Db is properly dropped at the end of the test.
        /// </summary>
        /// <returns>A <see cref="Task"/>.</returns>
        [Fact]
        public async Task DropDatabase()
        {
            // Arrange
            var builder = new SqlConnectionStringBuilder(ConnectionString);
            var databaseName = builder.InitialCatalog;

            builder.InitialCatalog = "postgres";

            // Act
            bool result;

            Dispose();

            using (var cnn = new SqlConnection(builder.ToString()))
            {
                cnn.Open();
                result = await cnn.ExecuteScalarAsync<bool>($"SELECT (EXISTS (SELECT 1 FROM pg_database WHERE datname = '{databaseName}'))");
            }

            // Assert
            result.Should().Be(false);
        }
    }
}