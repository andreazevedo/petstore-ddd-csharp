using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetStore.Core.Infrastructure.UnitOfWork
{
    /// <summary>
    /// Handles atomic units of work.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits the execution.
        /// </summary>
        void Commit();
    }
}
