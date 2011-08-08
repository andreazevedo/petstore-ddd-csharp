using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using PetStore.Core.Helper;
using PetStore.Core.Infrastructure.InversionOfControl;

namespace PetStore.Core.Infrastructure.Caching
{
    public static class Cache
    {
        #region Private Members

        private static ICache InternalCache
        {
            [DebuggerStepThrough]
            get
            {
                return IoC.Resolve<ICache>();
            }
        }

        #endregion

        #region Public Members

        public static long Count
        {
            [DebuggerStepThrough]
            get
            {
                return InternalCache.Count;
            }
        }

        [DebuggerStepThrough]
        public static void Clear()
        {
            InternalCache.Clear();
        }

        [DebuggerStepThrough]
        public static bool Contains(string key)
        {
            Check.Argument.IsNotNullOrEmpty(key, "key");

            return InternalCache.Contains(key);
        }

        [DebuggerStepThrough]
        public static T Get<T>(string key)
        {
            Check.Argument.IsNotNullOrEmpty(key, "key");

            return InternalCache.Get<T>(key);
        }

        [DebuggerStepThrough]
        public static bool TryGet<T>(string key, out T value)
        {
            Check.Argument.IsNotNullOrEmpty(key, "key");

            return InternalCache.TryGet(key, out value);
        }

        [DebuggerStepThrough]
        public static void Set<T>(string key, T value)
        {
            Check.Argument.IsNotNullOrEmpty(key, "key");

            InternalCache.Set(key, value);
        }

        [DebuggerStepThrough]
        public static void Set<T>(string key, T value, DateTime absoluteExpiration)
        {
            Check.Argument.IsNotNullOrEmpty(key, "key");
            Check.Argument.IsNotInPast(absoluteExpiration, "absoluteExpiration");

            InternalCache.Set(key, value, absoluteExpiration);
        }

        [DebuggerStepThrough]
        public static void Set<T>(string key, T value, TimeSpan slidingExpiration)
        {
            Check.Argument.IsNotNullOrEmpty(key, "key");
            Check.Argument.IsNotNegativeOrZero(slidingExpiration, "absoluteExpiration");

            InternalCache.Set(key, value, slidingExpiration);
        }

        [DebuggerStepThrough]
        public static void Remove(string key)
        {
            Check.Argument.IsNotNullOrEmpty(key, "key");

            InternalCache.Remove(key);
        }

        #endregion
    }
}
