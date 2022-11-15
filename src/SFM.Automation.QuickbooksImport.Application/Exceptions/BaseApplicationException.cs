using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace SFM.Automation.QuickbooksImport.Application.Exceptions
{
    /// <summary>
    ///   The base exception class of the application layer.
    /// </summary>
    [Serializable]
    public abstract class BaseApplicationException : Exception
    {
        [NonSerialized]
        private const string DefaultMessage = "An unexpected exception occurred.";

        [NonSerialized]
        private const int DefaultStatusCode = 500;

        [NonSerialized]
        private static readonly string ClientMessageKey = $"{typeof(BaseApplicationException).FullName}.{nameof(ClientMessage)}";

        [NonSerialized]
        private static readonly string StatusCodeKey = $"{typeof(BaseApplicationException).FullName}.{nameof(StatusCode)}";

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseApplicationException"/> class.
        /// </summary>
        protected BaseApplicationException()
            : this(DefaultStatusCode, DefaultMessage, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseApplicationException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains why the exception occurred.</param>
        protected BaseApplicationException(string message)
            : this(DefaultStatusCode, message ?? DefaultMessage, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseApplicationException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains why the exception occurred.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        protected BaseApplicationException(string message, Exception innerException)
            : this(DefaultStatusCode, message ?? DefaultMessage, innerException)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseApplicationException"/> class.
        /// </summary>
        /// <param name="statusCode">A status code used to further define the exception.</param>
        protected BaseApplicationException(int statusCode)
            : base(DefaultMessage)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseApplicationException"/> class.
        /// </summary>
        /// <param name="statusCode">A status code used to further define the exception.</param>
        /// <param name="message">The error message that explains why the exception occurred.</param>
        protected BaseApplicationException(int statusCode, string message)
            : base(message ?? DefaultMessage)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseApplicationException"/> class.
        /// </summary>
        /// <param name="statusCode">A status code used to further define the exception.</param>
        /// <param name="message">The error message that explains why the exception occurred.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        protected BaseApplicationException(int statusCode, string message, Exception innerException)
            : base(message ?? DefaultMessage, innerException)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BaseApplicationException"/> class.
        /// </summary>
        /// <param name="info">Holds the serialized object data.</param>
        /// <param name="context">Contains contextual information about the serialization.</param>
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        protected BaseApplicationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        ///   Gets or sets the message returned to the client.
        /// </summary>
        public string ClientMessage
        {
            get => Data.Contains(ClientMessageKey) ? Data[ClientMessageKey].ToString() : Message;
            protected set => Data[ClientMessageKey] = value;
        }

        /// <summary>
        ///   Gets or sets the exception status code.
        /// </summary>
        public int StatusCode
        {
            get => Data.Contains(StatusCodeKey) ? (int)Data[StatusCodeKey] : DefaultStatusCode;
            protected internal set => Data[StatusCodeKey] = value;
        }
    }
}