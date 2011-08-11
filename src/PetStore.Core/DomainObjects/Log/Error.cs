using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetStore.Core.DomainObjects.Log
{
    /// <summary>
    /// Represents an error
    /// </summary>
    public abstract class Error : IValidatable<Error>
    {
        #region Properties

        /// <summary>
        /// Error ID
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// When the error occurred
        /// </summary>
        public virtual DateTime GeneratedAt { get; set; }

        /// <summary>
        /// Error Type (represents the exception Type)
        /// </summary>
        public virtual string Type { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public virtual string Message { get; set; }

        /// <summary>
        /// Error details
        /// </summary>
        public virtual string Details { get; set; }

        /// <summary>
        /// Error additional information
        /// </summary>
        public virtual string AdditionalInformation { get; set; }

        /// <summary>
        /// Informs whether the error was handled (true) or not (false).
        /// </summary>
        public virtual bool Handled { get; set; }

        #endregion

        #region IValidatable Members

        bool IValidatable<Error>.Validate(IValidator<Error> validator, out IList<string> brokenRules)
        {
            brokenRules = validator.BrokenRules(this);
            return brokenRules.Count() == 0;
        }

        #endregion
    }
}
