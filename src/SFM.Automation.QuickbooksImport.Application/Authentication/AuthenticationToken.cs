using System;

namespace SFM.Automation.QuickbooksImport.Application.Authentication
{
    /// <summary>
    ///   A token providing details of the user making the request.
    /// </summary>
    public class AuthenticationToken : IEquatable<AuthenticationToken>
    {
        /// <summary>
        ///   Represents an anonymous user.
        /// </summary>
        public static readonly AuthenticationToken Anonymous = new AuthenticationToken("Anonymous", null);

        /// <summary>
        ///   A Fake that can be used when authentication is disabled.
        /// </summary>
        public static readonly AuthenticationToken Fake = new AuthenticationToken("sysadmin@edftrading.com", null);

        /// <summary>
        ///   Initializes a new instance of the <see cref="AuthenticationToken"/> class.
        /// </summary>
        /// <param name="userId">The immutable user id, typically their email.</param>
        /// <param name="userName">The name of the user.</param>
        /// <param name="jwt">The raw JWT authentication token.</param>
        public AuthenticationToken(string userId, string userName, string jwt = null)
        {
            UserId = string.IsNullOrEmpty(userId) ? Anonymous.UserId : userId;
            UserName = string.IsNullOrEmpty(userName) ? UserId : userName;
            Jwt = jwt;
        }

        /// <summary>
        ///   Gets a value indicating whether the user is anonymous.
        /// </summary>
        public bool IsAnonymous => string.IsNullOrEmpty(UserId) || Equals(Anonymous);

        /// <summary>
        ///   Gets a value indicating whether the user is authenticated.
        /// </summary>
        public bool IsAuthenticated => !IsAnonymous;

        /// <summary>
        ///   Gets the encoded jwt identity token for the current user.
        /// </summary>
        public string Jwt { get; }

        /// <summary>
        ///   Gets the immutable id of the logged in user.
        /// </summary>
        public string UserId { get; }

        /// <summary>
        ///   Gets the name of the user.
        /// </summary>
        public string UserName { get; }

        /// <summary>
        ///   Gets a value indicating whether this object is equivalent to another.
        /// </summary>
        /// <param name="other">The object to compare with this object.</param>
        /// <returns>True if the two objects are equivalent; otherwise, false.</returns>
        public bool Equals(AuthenticationToken other)
        {
            if (other == null)
                return false;

            return UserId.Equals(other.UserId, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        ///   Gets a value indicating whether this object is equivalent to another.
        /// </summary>
        /// <param name="other">The object to compare with this object.</param>
        /// <returns>True if the two objects are equivalent; otherwise, false.</returns>
        public override bool Equals(object other)
        {
            return Equals(other as AuthenticationToken);
        }

        /// <summary>
        ///   Gets a quasi-unique hash code for the object.
        /// </summary>
        /// <returns>A quasi-unique hash code.</returns>
        public override int GetHashCode()
        {
            return UserId.ToLowerInvariant().GetHashCode();
        }
    }
}