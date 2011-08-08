using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PetStore.Core.Helper
{
    /// <summary>
    /// Validates data
    /// </summary>
    public static class DataValidator
    {
        #region Constants

        public const string EmailRegex = @"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$";

        #endregion

        #region Static Fields

        private static readonly Regex EmailExpression = new Regex(EmailRegex, RegexOptions.Singleline | RegexOptions.Compiled);

        #endregion

        #region Static Methods

        /// <summary>
        /// Verifies whether the string is a valid e-mail address.
        /// </summary>
        /// <param name="maybeEmail">String containing a value that could be an e-mail address.</param>
        /// <returns>True if the value is a valid e-mail. Otherwise, false.</returns>
        public static bool IsEmail(string maybeEmail)
        {
            return !String.IsNullOrEmpty(maybeEmail) && EmailExpression.IsMatch(maybeEmail);
        }

        #endregion
    }
}
