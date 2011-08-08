using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetStore.Core.Infrastructure.Crypt
{
    /// <summary>
    /// Encryption
    /// </summary>
    public interface ICryptography
    {
        /// <summary>
        /// Encrypt a string.
        /// </summary>
        /// <param name="value">Value to encrypt.</param>
        /// <returns>Encrypted value.</returns>
        string Encrypt(string value);

        /// <summary>
        /// Decrypt a string.
        /// </summary>
        /// <param name="encryptedValue">Encrypted value.</param>
        /// <returns>Decrypted value.</returns>
        string Decrypt(string encryptedValue);

        /// <summary>
        /// Generates a hash of a value.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Hash</returns>
        string ComputeHash(string value);

        /// <summary>
        /// Generates a hash of a binary value.
        /// </summary>
        /// <param name="value">Byte array</param>
        /// <returns>Hash</returns>
        string ComputeHash(byte[] value);
    }
}
