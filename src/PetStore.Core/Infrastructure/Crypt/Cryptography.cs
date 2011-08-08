using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetStore.Core.Helper;
using PetStore.Core.Infrastructure.InversionOfControl;

namespace PetStore.Core.Infrastructure.Crypt
{
    public static class Cryptography
    {
        #region Public Members

        public static string Encrypt(string value)
        {
            Check.Argument.IsNotNullOrEmpty(value, "value");

            return InternalCryptography.Encrypt(value);
        }

        public static string Decrypt(string encryptedValue)
        {
            Check.Argument.IsNotNullOrEmpty(encryptedValue, "encryptedValue");

            return InternalCryptography.Decrypt(encryptedValue);
        }

        public static string ComputeHash(string value)
        {
            return InternalCryptography.ComputeHash(value);
        }

        public static string ComputeHash(byte[] value)
        {
            return InternalCryptography.ComputeHash(value);
        }

        #endregion

        #region Private Members

        private static ICryptography InternalCryptography
        {
            get
            {
                return IoC.Resolve<ICryptography>();
            }
        }

        #endregion
    }
}
