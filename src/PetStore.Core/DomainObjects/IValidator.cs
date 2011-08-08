using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetStore.Core.DomainObjects
{
    /// <summary>
    /// Validates an entity
    /// </summary>
    /// <typeparam name="TEntity">Entity</typeparam>
    public interface IValidator<in TEntity>
    {
        /// <summary>
        /// Validates an entity and returns the errors list. 
        /// (Or an empty list if there is no error).
        /// </summary>
        /// <param name="obj">Entity to be validated.</param>
        /// <returns>Errors list.</returns>
        IList<string> BrokenRules(TEntity obj);
    }
}
