using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PetStore.Resources;

namespace PetStore.Core
{
    /// <summary>
    /// Represents a generic domain exception.
    /// (Excpetion related to the application business).
    /// </summary>
    public abstract class DomainException : ApplicationException
    {
        #region Constructors

        protected DomainException()
            : this(GeneralResources.DomainExceptionDefaultMessage)
        {
        }

        protected DomainException(string message)
            : base(message)
        {
        }

        protected DomainException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DomainException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion
    }
}
