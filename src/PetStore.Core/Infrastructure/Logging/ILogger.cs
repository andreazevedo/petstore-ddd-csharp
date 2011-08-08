using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetStore.Core.Infrastructure.Logging
{
    /// <summary>
    /// Logs events
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log an information
        /// </summary>
        /// <param name="message">Information message</param>
        void Info(string message);

        /// <summary>
        /// Log a warning
        /// </summary>
        /// <param name="message">Warning message</param>
        void Warning(string message);

        /// <summary>
        /// Log an error
        /// </summary>
        /// <param name="message">Error message</param>
        void Error(string message);

        /// <summary>
        /// Log an exception
        /// </summary>
        /// <param name="exception">Exception</param>
        void Exception(Exception exception);

        /// <summary>
        /// Log a error message followed by an exception
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="message">Error message</param>
        void Exception(Exception exception, string message);
    }
}
