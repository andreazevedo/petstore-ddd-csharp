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
    /// Exception on adding objects to repositories
    /// </summary>
    public class AddPersistenceException : PersistenceException
    {
        #region Constructors

        public AddPersistenceException() : this(GeneralResources.AddPersistenceExceptionDefaultMessage) { }

        public AddPersistenceException(string message) : base(message) { }

        public AddPersistenceException(string message, Exception innerException) : base(message, innerException) { }

        protected AddPersistenceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public AddPersistenceException(object obj, Exception innerException) : base(GetMessage(obj), innerException) { }

        #endregion

        #region Private Methods

        private static string GetMessage(object obj)
        {
            return GeneralResources.AddPersistenceExceptionCustomMessage.FormatWith(obj);
        }

        #endregion
    }
}
