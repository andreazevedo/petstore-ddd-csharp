using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PetStore.Core.Extension;
using PetStore.Resources;

namespace PetStore.Core.Repository
{
    /// <summary>
    /// Exception on removing objects from repositories
    /// </summary>
    public class RemovePersistenceException : PersistenceException
    {
        #region Constructors

        public RemovePersistenceException() : this(GeneralResources.RemovePersistenceExceptionDefaultMessage) { }

        public RemovePersistenceException(string message) : base(message) { }

        public RemovePersistenceException(string message, Exception innerException) : base(message, innerException) { }

        protected RemovePersistenceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public RemovePersistenceException(object obj, Exception innerException) : base(GetMessage(obj), innerException) { }

        #endregion

        #region Private Methods

        private static string GetMessage(object obj)
        {
            return GeneralResources.RemovePersistenceExceptionCustomMessage.FormatWith(obj);
        }

        #endregion
    }
}
