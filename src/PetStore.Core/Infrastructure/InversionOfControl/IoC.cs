using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetStore.Core.Infrastructure.InversionOfControl
{
    /// <summary>
    /// Resolve dependencies
    /// Note: Before using this class, it is necessary to initialize it. i.e.: Call Initilize();
    /// </summary>
    public static class IoC
    {
        #region Fields

        private static IDependencyResolver _dependencyResolver;

        #endregion

        #region Methods

        /// <summary>
        /// Initialize this inversion of control class.
        /// </summary>
        /// <param name="dependencyResolver">Object used to resolve dependencies.</param>
        public static void Initialize(IDependencyResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }

        /// <summary>
        /// Resolve a dependency.
        /// </summary>
        /// <typeparam name="T">Type to resolve.</typeparam>
        /// <returns>Instance of the specified type.</returns>
        public static T Resolve<T>()
        {
            return _dependencyResolver.Resolve<T>();
        }

        /// <summary>
        /// Resolve a dependency.
        /// </summary>
        /// <typeparam name="T">Type to resolve.</typeparam>
        /// <param name="type">Type to resolve.</param>
        /// <returns>Instance of the specified type.</returns>
        public static T Resolve<T>(Type type)
        {
            return _dependencyResolver.Resolve<T>(type);
        }

        /// <summary>
        /// Resolve a dependency.
        /// </summary>
        /// <param name="type">Type to resolve.</param>
        /// <returns>Instance of the specified type.</returns>
        public static object Resolve(Type type)
        {
            return Resolve<object>(type);
        }

        #endregion

    }
}
