using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using PetStore.Core.Helper;
using PetStore.Core.Infrastructure.InversionOfControl;

namespace PetStore.Core.Infrastructure.Logging
{
    /// <summary>
    /// Logs events
    /// </summary>
    public static class Logger
    {
        #region Public Methods

        /// <summary>
        /// Log an information
        /// </summary>
        /// <param name="message">Information message</param>
        public static void Info(string message)
        {
            Check.Argument.IsNotNullOrEmpty(message, "message");

            InternalLogger.Info(message);
        }

        /// <summary>
        /// Log a warning
        /// </summary>
        /// <param name="message">Warning message</param>
        public static void Warning(string message)
        {
            Check.Argument.IsNotNullOrEmpty(message, "message");

            InternalLogger.Warning(message);
        }

        /// <summary>
        /// Log an error
        /// </summary>
        /// <param name="message">Error message</param>
        public static void Error(string message)
        {
            Check.Argument.IsNotNullOrEmpty(message, "message");

            InternalLogger.Error(message);
        }

        /// <summary>
        /// Log an exception
        /// </summary>
        /// <param name="exception">Exception</param>
        public static void Exception(Exception exception)
        {
            Check.Argument.IsNotNull(exception, "exception");

            InternalLogger.Exception(exception);
        }

        /// <summary>
        /// Log a error message followed by an exception
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="message">Error message</param>
        public static void Exception(Exception exception, string message)
        {
            Check.Argument.IsNotNull(exception, "exception");
            Check.Argument.IsNotNullOrEmpty(message, "message");

            InternalLogger.Exception(exception, message);
        }

        #endregion

        #region Private Methods

        private static ILogger InternalLogger
        {
            [DebuggerStepThrough]
            get
            {
                return IoC.Resolve<ILogger>();
            }
        }

        #endregion
    }
}
