using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetStore.Core.Infrastructure.Crypt;

namespace PetStore.TestBase.Mocks.Core.Infrastructure.Crypt
{
    public class CryptographyMock : ICryptography
    {
        public string Encrypt(string value)
        {
            return value;
        }

        public string Decrypt(string encryptedValue)
        {
            return encryptedValue;
        }

        public string ComputeHash(string value)
        {
            return value;
        }

        public string ComputeHash(byte[] value)
        {
            return value.ToString();
        }
    }
}
