using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PetStore.Core.Helper;

namespace PetStore.Core.Test.Helper
{
    [TestFixture]
    public class DataValidatorTest
    {
        [Test]
        public void IsEmail_ShouldReturnCorrectTrue()
        {
            const string validEmail = "andre.azevedo@gmail.com";

            bool result = DataValidator.IsEmail(validEmail);

            Assert.IsTrue(result);
        }
        [Test]
        public void IsEmail_ShouldReturnCorrectFalse()
        {
            const string invalidEmail = "andre.azevedo";

            bool result = DataValidator.IsEmail(invalidEmail);

            Assert.IsFalse(result);
        }
    }
}
