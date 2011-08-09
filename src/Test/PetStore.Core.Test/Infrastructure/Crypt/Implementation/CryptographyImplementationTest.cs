using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PetStore.Core.Infrastructure.Crypt.Implementation;

namespace PetStore.Core.Test.Infrastructure.Crypt.Implementation
{
    [TestFixture]
    public class CryptographyImplementationTest
    {
        [Test]
        public void EncryptAndDecrypt_ShouldReturnCorrectResult()
        {
            const string value = "Téstê açentuação 123?!.";

            CryptographyImplementation crypt = new CryptographyImplementation();
            var cryptString = crypt.Encrypt(value);
            Assert.AreNotEqual(value, cryptString);

            var decryptedString = crypt.Decrypt(cryptString);

            Assert.AreEqual(value, decryptedString);
        }

        [Test]
        public void EncryptAndDecryptNumber_ShouldReturnCorrectResult()
        {
            const string value = "1";

            CryptographyImplementation crypt = new CryptographyImplementation();
            var cryptString = crypt.Encrypt(value);
            Assert.AreNotEqual(value, cryptString);

            var decryptedString = crypt.Decrypt(cryptString);

            Assert.AreEqual(value, decryptedString);
        }

        [Test]
        public void ComputeHash_ShouldReturnCorrectValue()
        {
            const string value1 = "123456";
            const string value2 = "123457";
            const string value1Again = "123456";

            CryptographyImplementation crypt = new CryptographyImplementation();
            string value1Hash = crypt.ComputeHash(value1);
            string value2Hash = crypt.ComputeHash(value2);

            Assert.AreNotEqual(value1, value1Hash);
            Assert.AreNotEqual(value2, value2Hash);
            Assert.AreNotEqual(value1Hash, value2Hash);

            string value1NewHash = crypt.ComputeHash(value1Again);

            Assert.AreEqual(value1Hash, value1NewHash);
        }
    }
}
