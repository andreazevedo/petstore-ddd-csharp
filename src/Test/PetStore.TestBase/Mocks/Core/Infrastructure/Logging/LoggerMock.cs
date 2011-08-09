using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetStore.Core.Infrastructure.Logging;

namespace PetStore.TestBase.Mocks.Core.Infrastructure.Logging
{
    public class LoggerMock : ILogger
    {
        #region Static Properties

        private static List<string> _messages;

        public static List<string> Messages
        {
            get { return _messages ?? (_messages = new List<string>()); }
        }

        #endregion

        #region Public Methods

        public void Info(string message)
        {
            Messages.Add(message);
        }

        public void Warning(string message)
        {
            Messages.Add(message);
        }

        public void Error(string message)
        {
            Messages.Add(message);
        }

        public void Exception(Exception exception)
        {
            Messages.Add(exception.Message);
        }

        public void Exception(Exception exception, string message)
        {
            Messages.Add(message + " " + exception.Message);
        }

        #endregion
    }
}
