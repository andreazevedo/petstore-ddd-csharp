using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PetStore.Resources
{
    /// <summary>
    /// Resources files helper
    /// </summary>
    public class ResourcesHelper
    {
        /// <summary>
        /// Returns the value of a resources key.
        /// </summary>
        /// <param name="resourceManagerProvider">Resource Type</param>
        /// <param name="resourceKey">Key</param>
        /// <returns>If found, returns the value. Otherwise, returns back the key name.</returns>
        public static string LookupResource(Type resourceManagerProvider, string resourceKey)
        {
            var property = resourceManagerProvider.GetProperty(resourceKey, BindingFlags.Static | BindingFlags.Public);
            if (property != null && property.PropertyType == typeof(string))
            {
                return (string)property.GetValue(null, null);
            }
            return resourceKey;
        }
    }
}
