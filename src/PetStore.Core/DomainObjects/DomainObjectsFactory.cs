using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetStore.Core.DomainObjects.Log;
using PetStore.Core.Helper;

namespace PetStore.Core.DomainObjects
{
    /// <summary>
    /// Entity creator.
    /// </summary>
    public static class DomainObjectsFactory
    {
        #region Log

        public static class Log
        {
            /// <summary>
            /// Creates an system error from an exception
            /// </summary>
            /// <param name="exception">Exception</param>
            /// <param name="additionalInformation">Additional information about this error (if any).</param>
            /// <param name="handled">Informs whether the exception was properly handled.</param>
            /// <returns>Error object.</returns>
            public static Error CreateError(Exception exception, bool handled = true, string additionalInformation = null)
            {
                Check.Argument.IsNotNull(exception, "exception");

                Error error;
                if (exception is DomainException)
                {
                    error = new DomainError();
                }
                else
                {
                    error = new GenericError();
                }

                error.GeneratedAt = DateTime.Now;
                error.Type = exception.GetType().FullName;
                error.Message = exception.Message;
                error.Details = ExceptionManager.GetExceptionAsString(exception);
                error.AdditionalInformation = additionalInformation;
                error.Handled = handled;

                return error;
            }
        }

        #endregion
    }
}
