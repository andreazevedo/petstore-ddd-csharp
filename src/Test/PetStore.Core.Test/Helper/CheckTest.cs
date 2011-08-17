using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PetStore.Core.Helper;

namespace PetStore.Core.Test.Helper
{
    public class CheckTest
    {
        [TestFixture]
        public class ArgumentTest
        {
            [Test]
            public void IsNotNullOrEmpty_ShouldReturnCorrectResult()
            {
                string str = "Uma string";

                Check.Argument.IsNotNullOrEmpty(str, "argument1");
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void IsNotNullOrEmpty_ShouldThrowException()
            {
                string str = String.Empty;

                Check.Argument.IsNotNullOrEmpty(str, "argument1");
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void IsNotNullOrEmpty_ShouldThrowException2()
            {
                string str = null;

                Check.Argument.IsNotNullOrEmpty(str, "argument1");
            }

            [Test]
            public void IsNotNull_ShouldReturnCorrectResult()
            {
                object obj = new object();

                Check.Argument.IsNotNull(obj, "argument1");
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void IsNotNull_ShouldThrowException()
            {
                object obj = null;

                Check.Argument.IsNotNull(obj, "argument1");
            }

            [Test]
            public void IsInRange_ShouldReturnCorrectResult()
            {
                const int min = 0;
                const int max = 100;

                int value = 0;

                Check.Argument.IsInRange(value, "argument1", min, max);
            }

            [Test]
            public void IsInRange_ShouldReturnCorrectResult2()
            {
                const int min = 0;
                const int max = 100;

                int value = 100;

                Check.Argument.IsInRange(value, "argument1", min, max);
            }

            [Test]
            public void IsInRange_ShouldReturnCorrectResult3()
            {
                const int min = 0;
                const int max = 100;

                int value = 50;

                Check.Argument.IsInRange(value, "argument1", min, max);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void IsInRange_ShouldThrowException()
            {
                const int min = 0;
                const int max = 100;

                int value = -1;

                Check.Argument.IsInRange(value, "argument1", min, max);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void IsInRange_ShouldThrowException2()
            {
                const int min = 0;
                const int max = 100;

                int value = 101;

                Check.Argument.IsInRange(value, "argument1", min, max);
            }

            [Test]
            public void IsNotInPast_ShouldReturnCorrectResult()
            {
                DateTime dateTime = DateTime.Now.AddMinutes(1);

                Check.Argument.IsNotInPast(dateTime, "date");
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void IsNotInPast_ShouldThrowException()
            {
                DateTime dateTime = DateTime.Now.AddSeconds(-1);

                Check.Argument.IsNotInPast(dateTime, "date");
            }

            [Test]
            public void IsNotNegativeOrZero_ShouldReturnCorrectResult()
            {
                TimeSpan timeSpan = TimeSpan.FromMilliseconds(1);

                Check.Argument.IsNotNegativeOrZero(timeSpan, "timeSpan");
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void IsNotNegativeOrZero_ShouldThrowException()
            {
                TimeSpan timeSpan = TimeSpan.FromMilliseconds(0);

                Check.Argument.IsNotNegativeOrZero(timeSpan, "timeSpan");
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void IsNotNegativeOrZero_ShouldThrowException2()
            {
                TimeSpan timeSpan = TimeSpan.FromMilliseconds(-1);

                Check.Argument.IsNotNegativeOrZero(timeSpan, "timeSpan");
            }
        }
    }
}
