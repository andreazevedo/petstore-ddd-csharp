using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetStore.Core.Infrastructure.InversionOfControl
{
    /// <summary>
    /// Responsible for resolving dependencies
    /// </summary>
    public interface IDependencyResolver
    {
        /// <summary>
        /// Resolve a dependency.
        /// </summary>
        /// <typeparam name="T">Type to resolve.</typeparam>
        /// <returns>Instance of the specified type.</returns>
        T Resolve<T>();

        /// <summary>
        /// Resolve a dependency.
        /// </summary>
        /// <typeparam name="T">Type to resolve.</typeparam>
        /// <param name="type">Type to resolve.</param>
        /// <returns>Instance of the specified type.</returns>
        T Resolve<T>(Type type);
    }
}
