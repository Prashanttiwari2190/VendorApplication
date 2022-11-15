using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Xunit;

namespace SMF.Automation.QuickbooksImport.Data.IntegrationTests.Prerequisites.DbTestBaseTests
{
    /// <summary>
    ///   A test for the <see cref="DbTestBase"/> constructor method.
    /// </summary>
    public class ConstructorShould : DbTestBase
    {
        /// <summary>
        ///   A test to ensure that the Migrations run successfully.
        /// </summary>
        /// <returns>A <see cref="Task"/>.</returns>
        [Fact]
        public async Task RunMigrations()
        {
            // Arrange Handled by Base Constructor

            // Act Handled by Base Constructor

            // Assert
            var builder = new SqlConnectionStringBuilder(ConnectionString);
            var result = await Connection.ExecuteScalarAsync<bool>($"SELECT (EXISTS (SELECT 1 FROM pg_database WHERE datname = '{builder.Database}'))");

            result.Should().Be(true);
        }
    }
}