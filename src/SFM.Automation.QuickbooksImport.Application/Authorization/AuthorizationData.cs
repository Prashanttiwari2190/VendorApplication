using System;
using System.Collections.Generic;
using System.Linq;

namespace SFM.Automation.QuickbooksImport.Application.Authorization
{
    /// <summary>
    ///   A class that holds authorization data for the current request.
    /// </summary>
    public class AuthorizationData
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="AuthorizationData"/> class.
        /// </summary>
        /// <param name="userId">An immutable identifier for the user, typically their email.</param>
        /// <param name="userName">The name of the user.</param>
        /// <param name="roles">The roles bestowed to the user for the current request.</param>
        public AuthorizationData(
            string userId,
            string userName,
            IEnumerable<string> roles)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException($"The '{nameof(userId)}' parameter is required.", nameof(userId));

            UserId = userId;
            UserName = string.IsNullOrEmpty(userName) ? userId : userName;
            Roles = roles ?? Enumerable.Empty<string>();
        }

        /// <summary>
        ///   Gets the roles bestowed to the user.
        /// </summary>
        public IEnumerable<string> Roles { get; }

        /// <summary>
        ///   Gets the immutable user id, typically their email.
        /// </summary>
        public string UserId { get; }

        /// <summary>
        ///   Gets the name of the user.
        /// </summary>
        public string UserName { get; }

        /// <summary>
        ///   Gets a value indicating whether the grant has been bestowed to the user.
        /// </summary>
        /// <param name="type">The grant type.</param>
        /// <returns>True if the grant is in effect; otherwise, false.</returns>
        public bool HasRole(string type)
            => Roles
                .Any(role => role == "*" || role.Equals(type, StringComparison.OrdinalIgnoreCase));

        /// <summary>
        ///   Gets a value indicating whether the user is authorized to perform the specified activity.
        /// </summary>
        /// <param name="activityName">The name of the activity.</param>
        /// <returns>True if the user is authorized to perform the activity; otherwise, false.</returns>
        public bool IsAuthorized(string activityName)
            => HasRole(activityName);

        /// <summary>
        ///   Returns the current user information as a string.
        /// </summary>
        /// <returns>The current user information as a string.</returns>
        public override string ToString()
        {
            if (string.IsNullOrEmpty(UserName) || UserName == UserId)
                return UserId;

            return $"{UserName} ({UserId})";
        }
    }
}