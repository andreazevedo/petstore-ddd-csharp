using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace PetStore.Infrastructure.NHibernate.Database
{
    /// <summary>
    /// NHibernate sessions manager
    /// </summary>
    public interface IDatabaseSessionFactory
    {
        /// <summary>
        /// Open a NHibernate Session
        /// </summary>
        /// <returns>NHibernate Session.</returns>
        ISession Retrieve();

        /// <summary>
        /// Opens an independent NHibernate Session.
        /// WARNING: Sessions opened independently must be manually closed!
        /// </summary>
        /// <returns>Session</returns>
        ISession OpenIndependentSession();

        /// <summary>
        /// Closes the NHibernate Session.
        /// </summary>
        void Close();
    }
}
