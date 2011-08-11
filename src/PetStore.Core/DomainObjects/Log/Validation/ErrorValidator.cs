using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetStore.Core.Extension;
using PetStore.Resources.DomainObjects.Log;

namespace PetStore.Core.DomainObjects.Log.Validation
{
    /// <summary>
    /// Validates an error object
    /// </summary>
    public class ErrorValidator : IValidator<Error>
    {
        #region Constants

        public const int TypeMaxSize = 500;

        #endregion

        #region Methods

        public IList<string> BrokenRules(Error obj)
        {
            IList<string> brokenRules = new List<string>();

            if (String.IsNullOrWhiteSpace(obj.Type))
                brokenRules.Add(ErrorResources.ErrorTypeIsRequired);
            else if (obj.Type.Length > TypeMaxSize)
                brokenRules.Add(ErrorResources.ErrorTypeTooBig.FormatWith(TypeMaxSize));

            if (String.IsNullOrWhiteSpace(obj.Message))
                brokenRules.Add(ErrorResources.ErrorMessageIsRequired);

            return brokenRules;
        }

        #endregion
    }
}
