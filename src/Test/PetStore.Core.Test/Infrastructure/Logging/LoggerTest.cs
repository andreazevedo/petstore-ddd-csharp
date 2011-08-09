using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PetStore.Core.Infrastructure.InversionOfControl;
using PetStore.Core.Infrastructure.Logging;
using PetStore.Core.Test.Infrastructure.InversionOfControl;
using PetStore.TestBase.Mocks.Core.Infrastructure.Logging;

namespace PetStore.Core.Test.Infrastructure.Logging
{
    [TestFixture]
    public class LoggerTest
    {
        #region Test Methods

        [Test]
        public void InfoShouldReturnCorrectResult()
        {
            const string msg = "Info Message 1";
            IoC.Initialize(IoCTest.GetIDependencyResolverMock());
            int numOfLoggedMessagesBefore = LoggerMock.Messages.Count;
            Logger.Info(msg);
            int numOfLoggedMessagesAfter = LoggerMock.Messages.Count;
            Assert.AreEqual(numOfLoggedMessagesBefore + 1, numOfLoggedMessagesAfter);
            Assert.AreEqual(msg, LoggerMock.Messages.Last());
        }

        [Test]
        public void WaringShouldReturnCorrectResult()
        {
            const string msg = "Warning Message 1";
            IoC.Initialize(IoCTest.GetIDependencyResolverMock());
            int numOfLoggedMessagesBefore = LoggerMock.Messages.Count;
            Logger.Warning(msg);
            int numOfLoggedMessagesAfter = LoggerMock.Messages.Count;
            Assert.AreEqual(numOfLoggedMessagesBefore + 1, numOfLoggedMessagesAfter);
            Assert.AreEqual(msg, LoggerMock.Messages.Last());
        }

        [Test]
        public void ErrorShouldReturnCorrectResult()
        {
            const string msg = "Error Message 1";
            IoC.Initialize(IoCTest.GetIDependencyResolverMock());
            int numOfLoggedMessagesBefore = LoggerMock.Messages.Count;
            Logger.Error(msg);
            int numOfLoggedMessagesAfter = LoggerMock.Messages.Count;
            Assert.AreEqual(numOfLoggedMessagesBefore + 1, numOfLoggedMessagesAfter);
            Assert.AreEqual(msg, LoggerMock.Messages.Last());
        }

        [Test]
        public void ExceptionShouldReturnCorrectResult()
        {
            const string msg = "Exception Message 1";
            ApplicationException applicationException = new ApplicationException(msg);
            IoC.Initialize(IoCTest.GetIDependencyResolverMock());
            int numOfLoggedMessagesBefore = LoggerMock.Messages.Count;
            Logger.Exception(applicationException);
            int numOfLoggedMessagesAfter = LoggerMock.Messages.Count;
            Assert.AreEqual(numOfLoggedMessagesBefore + 1, numOfLoggedMessagesAfter);
            Assert.AreEqual(msg, LoggerMock.Messages.Last());
        }

        #endregion

        #region Static Methods

        public static ILogger GetILogMock()
        {
            return new LoggerMock();
        }

        #endregion
    }
}
