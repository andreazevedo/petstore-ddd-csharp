using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetStore.Core.Repository
{
    /// <summary>
    /// Generic repository interface
    /// </summary>
    /// <typeparam name="TEntity">Entity (agregation root).</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Add (or update) an entity to the repository
        /// </summary>
        /// <param name="obj">Object to be added/updated.</param>
        /// <exception cref="AddPersistenceException">Exception thrown when there is a problem on adding the object to the repository.</exception>
        void Add(TEntity obj);

        /// <summary>
        /// Remove an entity from the repository
        /// </summary>
        /// <param name="obj">Object to be removed.</param>
        /// <exception cref="RemovePersistenceException">Exception thrown when there is a problem on removing an entity from the repository.</exception>
        void Remove(TEntity obj);

        /// <summary>
        /// Retrieves an entity.
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Entity</returns>
        /// <exception cref="FindPersistenceException">Exception thrown when there is a problem on retrieving an entity from the repository.</exception>
        TEntity FindById(int id);
    }
}
