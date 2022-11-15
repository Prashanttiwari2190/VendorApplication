using System;

namespace SFM.Automation.QuickbooksImport.Domain.Correlation
{
    /// <summary>
    ///   An injectable correlation id, provided by the client as an http header and registered in the container by the
    ///   hosting process.
    /// </summary>
    /// <remarks>Classes can inject the <see cref="CorrelationId"/> class to obtain the value.</remarks>
    public class CorrelationId
    {
        /// <summary>
        ///   The correlation id header name.
        /// </summary>
        public const string HttpHeaderName = "sfm-correlation-id";

        /// <summary>
        ///   Initializes a new instance of the <see cref="CorrelationId"/> class.
        /// </summary>
        /// <param name="value">The value of the correlation id.</param>
        public CorrelationId(Guid value)
        {
            Value = value;
        }

        /// <summary>
        ///   Gets the value of the correlation identifier.
        /// </summary>
        public Guid Value { get; }

        /// <summary>
        ///   Returns a string representation of the object.
        /// </summary>
        /// <returns>A string representation of the object.</returns>
        public override string ToString() => Value.ToString();
    }
}