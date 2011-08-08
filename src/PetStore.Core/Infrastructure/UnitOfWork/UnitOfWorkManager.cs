using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetStore.Core.Infrastructure.InversionOfControl;

namespace PetStore.Core.Infrastructure.UnitOfWork
{
    /// <summary>
    /// Create units of work.
    /// </summary>
    public static class UnitOfWorkManager
    {
        /// <summary>
        /// Starts a unit of work
        /// </summary>
        /// <returns>UnitOfWork</returns>
        public static IUnitOfWork Begin()
        {
            return IoC.Resolve<IUnitOfWork>();
        }
    } 
}
