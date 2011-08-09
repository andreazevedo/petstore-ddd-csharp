using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PetStore.Core.Helper;

namespace PetStore.Core.Test.Helper
{
    [TestFixture]
    public class CheckTest
    {
        [TestFixture]
        public class ArgumentTest
        {
            [Test]
            public void IsNotNullOrEmptyShouldReturnCorrectResult()
            {
                string str = "Uma string";

                Check.Argument.IsNotNullOrEmpty(str, "argument1");
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void IsNotNullOrEmptyShouldThrowException()
            {
                string str = String.Empty;

                Check.Argument.IsNotNullOrEmpty(str, "argument1");
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void IsNotNullOrEmptyShouldThrowException2()
            {
                string str = null;

                Check.Argument.IsNotNullOrEmpty(str, "argument1");
            }

            [Test]
            public void IsNotNullShouldReturnCorrectResult()
            {
                object obj = new object();

                Check.Argument.IsNotNull(obj, "argument1");
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void IsNotNullShouldThrowException()
            {
                object obj = null;

                Check.Argument.IsNotNull(obj, "argument1");
            }

            [Test]
            public void IsInRangeShouldReturnCorrectResult()
            {
                const int min = 0;
                const int max = 100;

                int value = 0;

                Check.Argument.IsInRange(value, "argument1", min, max);
            }

            [Test]
            public void IsInRangeShouldReturnCorrectResult2()
            {
                const int min = 0;
                const int max = 100;

                int value = 100;

                Check.Argument.IsInRange(value, "argument1", min, max);
            }

            [Test]
            public void IsInRangeShouldReturnCorrectResult3()
            {
                const int min = 0;
                const int max = 100;

                int value = 50;

                Check.Argument.IsInRange(value, "argument1", min, max);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void IsInRangeShouldThrowException()
            {
                const int min = 0;
                const int max = 100;

                int value = -1;

                Check.Argument.IsInRange(value, "argument1", min, max);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void IsInRangeShouldThrowException2()
            {
                const int min = 0;
                const int max = 100;

                int value = 101;

                Check.Argument.IsInRange(value, "argument1", min, max);
            }

            [Test]
            public void IsNotInPastShouldReturnCorrectResult()
            {
                DateTime dateTime = DateTime.Now.AddMinutes(1);

                Check.Argument.IsNotInPast(dateTime, "date");
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void IsNotInPastShouldThrowException()
            {
                DateTime dateTime = DateTime.Now.AddSeconds(-1);

                Check.Argument.IsNotInPast(dateTime, "date");
            }

            [Test]
            public void IsNotNegativeOrZeroShouldReturnCorrectResult()
            {
                TimeSpan timeSpan = TimeSpan.FromMilliseconds(1);

                Check.Argument.IsNotNegativeOrZero(timeSpan, "timeSpan");
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void IsNotNegativeOrZeroShouldThrowException()
            {
                TimeSpan timeSpan = TimeSpan.FromMilliseconds(0);

                Check.Argument.IsNotNegativeOrZero(timeSpan, "timeSpan");
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void IsNotNegativeOrZeroShouldThrowException2()
            {
                TimeSpan timeSpan = TimeSpan.FromMilliseconds(-1);

                Check.Argument.IsNotNegativeOrZero(timeSpan, "timeSpan");
            }
        }
    }
}
