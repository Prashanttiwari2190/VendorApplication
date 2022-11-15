using System;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SFM.Automation.QuickbooksImport.Data;

namespace SMF.Automation.QuickbooksImport.Data.IntegrationTests
{
    /// <summary>
    ///   A base class that should be used for Database related tests to setup the database.
    /// </summary>
    public abstract class DbTestBase : IDisposable
    {
        private bool isDisposed;

        /// <summary>
        ///   Initializes a new instance of the <see cref="DbTestBase"/> class.
        /// </summary>
        protected DbTestBase()
        : this(false)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="DbTestBase"/> class.
        /// </summary>
        /// <param name="includeApplicationServices">Indicates if the application services should be included.</param>
        protected DbTestBase(bool includeApplicationServices)
        {
            var fi = new FileInfo(Assembly.GetExecutingAssembly().Location);
            Configuration = TestHelper.GetIConfigurationRoot(fi.Directory.FullName);

            var builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString());

            builder.InitialCatalog = Guid.NewGuid().ToString();

            ConnectionString = builder.ToString();
            Configuration[$"connectionStrings:{ConnectionStrings.QuickbooksImport}"] = ConnectionString;

            var services = new ServiceCollection()
                .AddSingleton(Configuration)
                .AddDataServices(Configuration);

            ServiceProvider = services.BuildServiceProvider();

            var migrator = ServiceProvider.GetService<Migrator>();
            migrator.RunMigrations();

            Connection = CreateOpenConnection();
        }

        /// <summary>
        ///   Gets the Configuration settings to use for the test.
        /// </summary>
        protected IConfiguration Configuration { get; private set; }

        /// <summary>
        ///   Gets the <see cref="SqlConnection"/> associated with the current test.
        /// </summary>
        protected SqlConnection Connection { get; private set; }

        /// <summary>
        ///   Gets the connection string to the test database.
        /// </summary>
        protected string ConnectionString { get; private set; }

        /// <summary>
        ///   Gets the <see cref="IServiceProvider"/>.
        /// </summary>
        protected IServiceProvider ServiceProvider { get; }

        /// <summary>
        ///   Disposes the <seealso cref="DbTestBase"/> object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///   Creates a new, open <see cref="NpgsqlConnection"/> instance.
        /// </summary>
        /// <returns>Returns an instance of an open <see cref="NpgsqlConnection"/> object.</returns>
        protected SqlConnection CreateOpenConnection()
        {
            var cnn = new SqlConnection(Configuration.GetConnectionString());
            cnn.Open();

            return cnn;
        }

        /// <summary>
        ///   Disposes the <seealso cref="DbTestBase"/> object.
        /// </summary>
        /// <param name="disposing">A boolean value indicating if the object is disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed)
                return;

            if (disposing)
            {
                Connection.Dispose();
                Migrator.DropDatabase(Configuration);
            }

            isDisposed = true;
        }
    }
}