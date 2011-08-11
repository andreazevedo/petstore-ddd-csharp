using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetStore.Resources.DomainObjects.Log;

namespace PetStore.Core.DomainObjects.Log.Validation
{
    public class ErrorValidationException : ValidationException
    {
        #region Constructors

        public ErrorValidationException(IList<string> brokenRules)
            : base(GetMainMessage(), brokenRules)
        {
        }

        #endregion

        #region Static Methods

        private static string GetMainMessage()
        {
            return ErrorResources.ErrorValidationExceptionMainMessage;
        }

        #endregion
    }
}
