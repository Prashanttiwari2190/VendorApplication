using SFM.Automation.QuickbooksImport.Data.DataContext;
using System.Data.SqlClient;

namespace SFM.Automation.QuickbooksImport.Data
{
    /// <summary>
    ///   A connection for the specified <typeparamref name="TDataContext"/>.
    /// </summary>
    /// <typeparam name="TDataContext">The <see cref="IDataContext"/> to use for the connection.</typeparam>
    public interface ISqlConnection<TDataContext>
        where TDataContext : IDataContext
    {
        /// <summary>
        ///   Gets the <see cref="SqlConnection"/> that the repository will use.
        /// </summary>
        SqlConnection Value { get; }
    }
}