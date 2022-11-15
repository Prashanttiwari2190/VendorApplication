using System;
using Microsoft.Extensions.Configuration;

namespace SMF.Automation.QuickbooksImport.Data.IntegrationTests
{
    internal class TestHelper
    {
        /// <summary>
        ///   Gets an <seealso cref="IConfigurationRoot"/> object containing the configuration settings for the
        ///   integration tests.
        /// </summary>
        /// <param name="outputPath">The path of to the testsettings.json file.</param>
        /// <returns>
        ///   Returns an <seealso cref="IConfigurationRoot"/> object containing the configuration settings for the
        ///   integration tests.
        /// </returns>
        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("testsettings.json", optional: true)
                .AddJsonFile($"testsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                .AddEnvironmentVariables("EDF_Services_Billing_")
                .Build();
        }
    }
}