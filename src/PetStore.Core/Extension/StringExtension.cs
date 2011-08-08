using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetStore.Core.Helper;

namespace PetStore.Core.Extension
{
    /// <summary>
    /// String extesion methods
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Formats a string. Similar to String.Format()
        /// </summary>
        /// <param name="target">string to format</param>
        /// <param name="args">Arguments to replace in the string.</param>
        /// <returns>Formatted string.</returns>
        public static string FormatWith(this string target, params object[] args)
        {
            Check.Argument.IsNotNullOrEmpty(target, "target");
            return String.Format(target, args);
        }

        /// <summary>
        /// Verifies whether the string is a valid e-mail address.
        /// </summary>
        /// <param name="target">String containing a value that could be an e-mail address.</param>
        /// <returns>True if the value is a valid e-mail. Otherwise, false.</returns>
        public static bool IsEmail(this string target)
        {
            return DataValidator.IsEmail(target);
        }
    }
}
