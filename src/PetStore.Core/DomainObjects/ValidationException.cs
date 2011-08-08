using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PetStore.Resources;

namespace PetStore.Core.DomainObjects
{
    /// <summary>
    /// Exception that represents an error on an entity's validation.
    /// </summary>
    public class ValidationException : DomainException
    {
        #region Constructors

        public ValidationException()
            : this(GeneralResources.ValidationExceptionDefaultMessage)
        {
        }

        public ValidationException(string message)
            : base(message)
        {
        }

        public ValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public ValidationException(string mainMessage, IList<string> brokenRules)
            : this(CreateBrokenRulesMessage(mainMessage, brokenRules))
        {
            BrokenRules = brokenRules;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Validation rules that were broken.
        /// </summary>
        public IList<string> BrokenRules { get; private set; }

        #endregion

        #region Private Methods

        private static string CreateBrokenRulesMessage(string mainMessage, IEnumerable<string> brokenRules)
        {
            StringBuilder sbMessage = new StringBuilder();
            sbMessage.Append(mainMessage);
            foreach (var brokenRule in brokenRules)
            {
                sbMessage.Append(" ");
                sbMessage.Append(brokenRule);
            }

            return sbMessage.ToString();
        }

        #endregion
    }
}
