using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PetStore.Resources;

namespace PetStore.Core.Repository
{
    /// <summary>
    /// Generic persistence exception.
    /// </summary>
    public abstract class PersistenceException : DomainException
    {
        #region Constructors

        protected PersistenceException()
            : this(GeneralResources.PersistenceExceptionDefaultMessage)
        {
        }

        protected PersistenceException(string message)
            : base(message)
        {
        }

        protected PersistenceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected PersistenceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion
    }
}
