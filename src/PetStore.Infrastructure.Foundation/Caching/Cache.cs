using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using PetStore.Core.Helper;
using PetStore.Core.Infrastructure.Caching;

namespace PetStore.Infrastructure.Foundation.Caching
{
    public class Cache : ICache
    {
        #region Fields

        private readonly ObjectCache _objectCache;

        #endregion

        #region Constructors

        public Cache()
        {
            _objectCache = MemoryCache.Default;
        }

        #endregion

        #region ICache Members

        public long Count
        {
            get { return _objectCache.GetCount(); }
        }

        public void Clear()
        {
            var items = _objectCache.ToArray();
            foreach (var keyValuePair in items)
            {
                _objectCache.Remove(keyValuePair.Key);
            }
        }

        public bool Contains(string key)
        {
            Check.Argument.IsNotNullOrEmpty(key, "key");

            return _objectCache.Contains(key);
        }

        public T Get<T>(string key)
        {
            Check.Argument.IsNotNullOrEmpty(key, "key");

            return (T)_objectCache.Get(key);
        }

        public bool TryGet<T>(string key, out T value)
        {
            Check.Argument.IsNotNullOrEmpty(key, "key");

            value = default(T);

            if (_objectCache.Contains(key))
            {
                object existingValue = _objectCache.Get(key);
                if (existingValue != null)
                {
                    value = (T)existingValue;
                    return true;
                }
            }
            return false;
        }

        public void Set<T>(string key, T value)
        {
            Check.Argument.IsNotNullOrEmpty(key, "key");

            _objectCache.Set(key, value, DateTimeOffset.MaxValue);
        }

        public void Set<T>(string key, T value, DateTime absoluteExpiration)
        {
            Check.Argument.IsNotNullOrEmpty(key, "key");
            Check.Argument.IsNotInPast(absoluteExpiration, "absoluteExpiration");

            _objectCache.Set(key, value, new DateTimeOffset(absoluteExpiration));
        }

        public void Set<T>(string key, T value, TimeSpan slidingExpiration)
        {
            Check.Argument.IsNotNullOrEmpty(key, "key");
            Check.Argument.IsNotNegativeOrZero(slidingExpiration, "slidingExpiration");

            _objectCache.Set(key, value, new DateTimeOffset(DateTime.Now.Add(slidingExpiration)));
        }

        public void Remove(string key)
        {
            Check.Argument.IsNotNullOrEmpty(key, "key");

            if (_objectCache.Contains(key))
            {
                _objectCache.Remove(key);
            }
        }

        #endregion
    }
}
