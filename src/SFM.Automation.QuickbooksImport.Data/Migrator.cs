using System;
using System.Data.SqlClient;

using Dapper;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SFM.Automation.QuickbooksImport.Data
{
    /// <summary>
    ///   The class that is responsible for running data migrations.
    /// </summary>
    public class Migrator
    {
        private IConfiguration configuration;
        private ILogger<Migrator> logger;
        private IMigrationRunner migrationRunner;

        /// <summary>
        ///   Initializes a new instance of the <see cref="Migrator"/> class.
        /// </summary>
        /// <param name="configuration">The application configuration settings.</param>
        /// <param name="logger">The <see cref="ILogger"/> to use for logging.</param>
        /// <param name="migrationRunner">The migration runner.</param>
        public Migrator(
            IConfiguration configuration,
            ILogger<Migrator> logger,
            IMigrationRunner migrationRunner)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.migrationRunner = migrationRunner;
        }

        /// <summary>
        ///   Runs all new migrations.
        /// </summary>
        public void RunMigrations()
        {
            try
            {
                CreateDatabase();
                migrationRunner.MigrateUp();
            }
            catch (Exception e)
            {
                logger.LogError(e, "ERROR running data migrations!");
                throw;
            }
        }

        private static bool DatabaseExists(SqlConnection connection, string databaseName)
        {
            const string sql = @"SELECT name FROM master.sys.databases WHERE name = @databaseName;";

            var database = connection.QuerySingleOrDefault(sql, new { databaseName });

            return database != null;
        }

        private void CreateDatabase()
        {
            var databaseName = configuration.GetDatabaseName();
            var serverConnectionString = configuration.GetDatabaseServerConnectionString();

            using (var connection = new SqlConnection(serverConnectionString))
            {
                connection.Open();

                var databaseExists = DatabaseExists(connection, databaseName);

                if (databaseExists)
                    return;

                connection.Execute($@"CREATE DATABASE [{databaseName}];");
            }
        }
    }
}