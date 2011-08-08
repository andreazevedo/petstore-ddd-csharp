using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetStore.Core.Infrastructure.Caching
{
    /// <summary>
    /// Manages cache
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// Returns the number of cached items.
        /// </summary>
        long Count
        {
            get;
        }

        /// <summary>
        /// Clear the cache.
        /// </summary>
        void Clear();

        /// <summary>
        /// Verifies whether there is a cached item with the informed key.
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>True if the object exists. Otherwise, false.</returns>
        bool Contains(string key);

        /// <summary>
        /// Returns a cached object.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="key">Key</param>
        /// <returns>Cached object.</returns>
        T Get<T>(string key);

        /// <summary>
        /// Returns a cached object if it exists
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="key">Key</param>
        /// <param name="value">Object</param>
        /// <returns>True if the object was returned. Otherwise, false.</returns>
        bool TryGet<T>(string key, out T value);

        /// <summary>
        /// Add (or update) an object in the cache.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">Key</param>
        /// <param name="value">Object to be cached</param>
        void Set<T>(string key, T value);

        /// <summary>
        /// Add (or update) an object in the cache.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">Key</param>
        /// <param name="value">Object to be cached</param>
        /// <param name="absoluteExpiration">Expiration date</param>
        void Set<T>(string key, T value, DateTime absoluteExpiration);

        /// <summary>
        /// Add (or update) an object in the cache.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">Key</param>
        /// <param name="value">Object to be cached.</param>
        /// <param name="slidingExpiration">Tempo de validade</param>
        void Set<T>(string key, T value, TimeSpan slidingExpiration);

        /// <summary>
        /// Remove and object from the cache.
        /// </summary>
        /// <param name="key">Key.</param>
        void Remove(string key);
    }
}
