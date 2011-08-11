using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using PetStore.Core.Infrastructure.InversionOfControl;
using PetStore.Core.Services.Log;

namespace PetStore.Core.Helper
{
    /// <summary>
    /// Responsible for registering exception information
    /// </summary>
    public static class ExceptionManager
    {
        #region Public Methods

        /// <summary>
        /// Logs an exception
        /// </summary>
        /// <param name="exception">Exception</param>
        public static void LogException(Exception exception)
        {
            Check.Argument.IsNotNull(exception, "exception");

            LogException(exception, true, string.Empty);
        }

        /// <summary>
        /// Logs an Exception
        /// </summary>
        /// <param name="exception">Excetion</param>
        /// <param name="handled">Informs whether the exception was handled.</param>
        /// <param name="additionalInformation">Additional information about the error.</param>
        public static void LogException(Exception exception, bool handled, string additionalInformation)
        {
            Check.Argument.IsNotNull(exception, "exception");

            GetErrorService().RegisterException(exception, handled, additionalInformation);
        }

        /// <summary>
        /// Gets an excetpion as a string. Includes all inner exception details in the string
        /// </summary>
        /// <param name="ex">Exception.</param>
        /// <returns>String with all information about the exception.</returns>
        public static string GetExceptionAsString(Exception ex)
        {
            Check.Argument.IsNotNull(ex, "exception");

            try
            {
                StringBuilder sbMessage = new StringBuilder();
                sbMessage.Append("EXCEPTION\n");

                sbMessage.AppendLine("Type:");
                sbMessage.AppendLine(ex.GetType().FullName);
                sbMessage.AppendLine();

                if (!String.IsNullOrEmpty(ex.Message))
                {
                    sbMessage.AppendLine("Message:");
                    sbMessage.AppendLine(ex.Message);
                    sbMessage.AppendLine();
                }

                if (!String.IsNullOrEmpty(ex.StackTrace))
                {
                    sbMessage.AppendLine("Stack Trace:");
                    sbMessage.AppendLine(ex.StackTrace);
                    sbMessage.AppendLine();
                }

                if (ex.InnerException != null)
                {
                    sbMessage.AppendLine();
                    sbMessage.AppendLine();
                    sbMessage.Append(GetMessageFromInnerException(ex.InnerException, 1));
                }

                return sbMessage.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        #endregion

        #region Private Methods

        private static string GetMessageFromInnerException(Exception ex, int number)
        {
            StringBuilder sbMessage = new StringBuilder();
            sbMessage.Append(String.Format("INNER EXCEPTION {0}\n", number));

            sbMessage.AppendLine("Type:");
            sbMessage.AppendLine(ex.GetType().FullName);
            sbMessage.AppendLine();

            if (!String.IsNullOrEmpty(ex.Message))
            {
                sbMessage.AppendLine("Message:");
                sbMessage.AppendLine(ex.Message);
                sbMessage.AppendLine();
            }

            if (!String.IsNullOrEmpty(ex.StackTrace))
            {
                sbMessage.AppendLine("Stack Trace:");
                sbMessage.AppendLine(ex.StackTrace);
                sbMessage.AppendLine();
            }

            if (ex.InnerException != null)
            {
                sbMessage.AppendLine();
                sbMessage.Append(GetMessageFromInnerException(ex.InnerException, number + 1));
            }

            return sbMessage.ToString();
        }

        [DebuggerStepThrough]
        private static ErrorService GetErrorService()
        {
            return IoC.Resolve<ErrorService>();
        }

        #endregion
    }
}
