using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using PetStore.Core.Helper;

namespace PetStore.Core.Infrastructure.Crypt.Implementation
{
    public class CryptographyImplementation : ICryptography
    {
        #region Fields

        private const string Password = "p3TsT0R3klAFKLHksd987435";
        private const string Salt = "PasldfjwooSt0re1";

        #endregion

        public string Encrypt(string value)
        {
            Check.Argument.IsNotNullOrEmpty(value, "value");

            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, Encoding.UTF8.GetBytes(Salt));
            byte[] data = EncryptStringToBytes(value, rfc2898DeriveBytes.GetBytes(32), rfc2898DeriveBytes.GetBytes(16));
            return Convert.ToBase64String(data);
        }

        public string Decrypt(string encryptedValue)
        {
            Check.Argument.IsNotNullOrEmpty(encryptedValue, "encryptedValue");

            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, Encoding.UTF8.GetBytes(Salt));
            byte[] data = Convert.FromBase64String(encryptedValue);
            return DecryptStringFromBytes(data, rfc2898DeriveBytes.GetBytes(32), rfc2898DeriveBytes.GetBytes(16));
        }

        public string ComputeHash(string value)
        {
            Check.Argument.IsNotNullOrEmpty(value, "value");

            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, Encoding.UTF8.GetBytes(Salt));
            HMACSHA1 hash = new HMACSHA1(rfc2898DeriveBytes.GetBytes(16));
            byte[] data = Encoding.UTF8.GetBytes(value);
            byte[] dataHash = hash.ComputeHash(data);
            return Convert.ToBase64String(dataHash);
        }

        public string ComputeHash(byte[] value)
        {
            Check.Argument.IsNotNullOrEmpty(value, "value");

            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, Encoding.UTF8.GetBytes(Salt));
            HMACSHA1 hash = new HMACSHA1(rfc2898DeriveBytes.GetBytes(16));
            byte[] dataHash = hash.ComputeHash(value);
            return Convert.ToBase64String(dataHash);
        }

        #region Private Methods

        private static byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
        {
            // Check arguments.
            Check.Argument.IsNotNullOrEmpty(plainText, "plainText");
            Check.Argument.IsNotNullOrEmpty(key, "key");
            Check.Argument.IsNotNullOrEmpty(iv, "iv");

            // Declare the stream used to encrypt to an in memory
            // array of bytes.
            MemoryStream msEncrypt = null;

            // Declare the RijndaelManaged object
            // used to encrypt the data.
            RijndaelManaged aesAlg = null;

            try
            {
                // Create a RijndaelManaged object
                // with the specified key and IV.
                aesAlg = new RijndaelManaged();
                aesAlg.Key = key;
                aesAlg.IV = iv;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                msEncrypt = new MemoryStream();
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {

                        //Write all data to the stream.
                        swEncrypt.Write(plainText);
                    }
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            // Return the encrypted bytes from the memory stream.
            return msEncrypt.ToArray();
        }

        private static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments.
            Check.Argument.IsNotNullOrEmpty(cipherText, "cipherText");
            Check.Argument.IsNotNullOrEmpty(key, "key");
            Check.Argument.IsNotNullOrEmpty(iv, "iv");

            // Declare the RijndaelManaged object
            // used to decrypt the data.
            RijndaelManaged aesAlg = null;

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            try
            {
                // Create a RijndaelManaged object
                // with the specified key and IV.
                aesAlg = new RijndaelManaged();
                aesAlg.Key = key;
                aesAlg.IV = iv;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            return plaintext;
        }

        #endregion
    }
}
