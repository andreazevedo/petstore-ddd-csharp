using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using PetStore.Core.Helper;
using PetStore.Core.Infrastructure.Logging;

namespace PetStore.Infrastructure.Foundation.Logging
{
    public class EventViewerLogger : ILogger
    {
        #region Fields

        private static object _sync = new object();

        #endregion

        #region Properties

        public string Source { get; set; }
        public string Log { get; set; }

        #endregion

        #region Constructors

        public EventViewerLogger()
        {
            Source = "TimeSpender";
            Log = "Application";
        }

        #endregion

        #region ILogger Members

        public void Info(string message)
        {
            Write(message, EventLogEntryType.Information);
        }

        public void Warning(string message)
        {
            Write(message, EventLogEntryType.Warning);
        }

        public void Success(string message)
        {
            Write(message, EventLogEntryType.SuccessAudit);
        }

        public void Error(string message)
        {
            Write(message, EventLogEntryType.Error);
        }

        public void Exception(Exception exception)
        {
            Write(ExceptionManager.GetExceptionAsString(exception), EventLogEntryType.Error);
        }

        public void Exception(Exception exception, string message)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(message);
            stringBuilder.AppendLine();
            stringBuilder.Append(ExceptionManager.GetExceptionAsString(exception));
            Write(stringBuilder.ToString(), EventLogEntryType.Error);
        }

        #endregion

        #region Private Methods



        private void Write(string message, EventLogEntryType entryType)
        {
            try
            {
                lock (_sync)
                {
                    if (!EventLog.SourceExists(Source))
                    {
                        EventLog.CreateEventSource(Source, Log);
                    }
                }

                EventLog.WriteEntry(Source, message, entryType);
            }
            catch (Exception)
            {
            }
        }

        #endregion
    }
}
