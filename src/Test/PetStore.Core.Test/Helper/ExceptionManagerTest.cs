using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PetStore.Core.Helper;

namespace PetStore.Core.Test.Helper
{
    [TestFixture]
    public class ExceptionManagerTest
    {
        [Test]
        public void GetExceptionAsStringShouldReturnCorrectResult()
        {
            ApplicationException innerException2 = new ApplicationException("2");
            ApplicationException innerException1 = new ApplicationException("1", innerException2);
            ApplicationException exception = new ApplicationException("0", innerException1);

            string exceptionAsString = ExceptionManager.GetExceptionAsString(exception);
            exceptionAsString = exceptionAsString.ToUpper();
            Assert.IsFalse(String.IsNullOrEmpty(exceptionAsString));
            Assert.IsTrue(exceptionAsString.Contains("EXCEPTION"));
            Assert.IsTrue(exceptionAsString.Contains("INNER EXCEPTION 1"));
            Assert.IsTrue(exceptionAsString.Contains("INNER EXCEPTION 2"));
            Assert.IsFalse(exceptionAsString.Contains("INNER EXCEPTION 3"));
        }
    }
}
