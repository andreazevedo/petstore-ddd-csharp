using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetStore.Core.DomainObjects
{
    /// <summary>
    /// Must be implemented by entities that would be validated.
    /// </summary>
    /// <typeparam name="TEntity">Entity</typeparam>
    public interface IValidatable<out TEntity>
    {
        /// <summary>
        /// Validates the entity
        /// </summary>
        /// <param name="validator">Validator responsible for validating the given entity (ref: TEntity).</param>
        /// <param name="brokenRules">Errors list.</param>
        /// <returns>True if the entity is valid. Otherwise, false.</returns>
        bool Validate(IValidator<TEntity> validator, out IList<string> brokenRules);
    }
}
