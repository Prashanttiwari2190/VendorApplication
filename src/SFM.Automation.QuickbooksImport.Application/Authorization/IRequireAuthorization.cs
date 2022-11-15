namespace SFM.Automation.QuickbooksImport.Application.Authorization
{
    /// <summary>
    ///   The interface that defines a contract for commands and queries that must be authorized (i.e. those for which
    ///   the current user must have an Activity grant).
    /// </summary>
    public interface IRequireAuthorization
    {
        /// <summary>
        ///   Gets or sets the <see cref="AuthorizationData"/> for the request.
        /// </summary>
        AuthorizationData AuthorizationData { get; set; }
    }
}