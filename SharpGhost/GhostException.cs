using System;

namespace SharpGhost
{
    /// <summary>
    /// Custom Ghost API errors and exceptions
    /// </summary>
    public class GhostException : Exception
    {
        /// <summary>
        /// Gets or sets the Ghost error message
        /// </summary>
        public string GhostErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the Ghost error type
        /// </summary>
        public string GhostErrorType { get; set; }

        /// <summary> 
        /// Initializes a new instance of the <see cref="GhostException"/> class. 
        /// </summary> 
        public GhostException() : base() { }

        /// <summary> 
        /// Initializes a new instance of the <see cref="GhostException"/> class. 
        /// </summary> 
        /// <param name="message">The message that describes the error.</param> 
        public GhostException(string message) : base(message) { }

        /// <summary> 
        /// Initializes a new instance of the <see cref="GhostException"/> class. 
        /// </summary> 
        /// <param name="message">The error message that explains the reason for the exception.</param> 
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param> 
        public GhostException(string message, Exception innerException) : base(message, innerException) { }
    }
}
