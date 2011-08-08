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
    /// Exception on retrieving objects from repositories
    /// </summary>
    public class FindPersistenceException : PersistenceException
    {
        #region Constructors

        public FindPersistenceException() : this(GeneralResources.FindPersistenceExceptionDefaultMessage) { }

        public FindPersistenceException(string message) : base(message) { }

        public FindPersistenceException(string message, Exception innerException) : base(message, innerException) { }

        protected FindPersistenceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public FindPersistenceException(Type entityType, long objectId, Exception innerException) : base(GetMessage(entityType, objectId), innerException) { }

        #endregion

        #region Private Methods

        private static string GetMessage(Type entityType, long objectId)
        {
            return GeneralResources.FindPersistenceExceptionCustomMessage.FormatWith(objectId, entityType);
        }

        #endregion
    }
}
