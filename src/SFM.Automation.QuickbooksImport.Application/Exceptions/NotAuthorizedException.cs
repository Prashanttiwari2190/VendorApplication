using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace SFM.Automation.QuickbooksImport.Application.Exceptions
{
    /// <summary>
    ///   The exception that is thrown when a user is not authorized to perform an operation.
    /// </summary>
    [Serializable]
    public class NotAuthorizedException : BaseApplicationException
    {
        [NonSerialized]
        private static readonly string UserIdKey = $"{typeof(NotAuthorizedException).FullName}.{nameof(UserId)}";

        /// <summary>
        ///   Initializes a new instance of the <see cref="NotAuthorizedException"/> class.
        /// </summary>
        /// <param name="statusCode">The status code of the exception, which should be 401 or 403.</param>
        /// <param name="userId">The immutable user id.</param>
        /// <param name="message">The message that explains why the exception occurred.</param>
        /// <param name="inner">The exception that is the cause of the current exception.</param>
        protected internal NotAuthorizedException(int statusCode, string userId, string message, Exception inner = null)
            : base(statusCode, message, inner)
        {
            UserId = userId;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="NotAuthorizedException"/> class.
        /// </summary>
        /// <param name="info">Holds the serialized object data.</param>
        /// <param name="context">Contains contextual information about the serialization.</param>
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        protected NotAuthorizedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        ///   Gets or sets the user that was not authorized.
        /// </summary>
        public string UserId
        {
            get => Data.Contains(UserIdKey) ? (string)Data[UserIdKey] : string.Empty;
            protected set => Data[UserIdKey] = value;
        }

        /// <summary>
        ///   A factory method used to create an <see cref="NotAuthorizedException"/> with a 403 status code.
        /// </summary>
        /// <param name="userId">The user that was not authorized.</param>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The exception that is the cause of this exception.</param>
        /// <returns>Returns a <see cref="NotAuthorizedException"/>.</returns>
        public static NotAuthorizedException BecauseForbidden(string userId, string message = null, Exception inner = null)
        {
            return new NotAuthorizedException(403, userId, message ?? "Access has been denied.", inner);
        }

        /// <summary>
        ///   A factory method used to create an <see cref="NotAuthorizedException"/> with a 401 status code.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="inner">The exception that is the cause of this exception.</param>
        /// <returns>Returns a <see cref="NotAuthorizedException"/>.</returns>
        public static NotAuthorizedException BecauseNotAuthorized(string message = null, Exception inner = null)
        {
            return new NotAuthorizedException(401, "Anonymous", message ?? $"Anonymous access is not allowed.", inner);
        }
    }
}