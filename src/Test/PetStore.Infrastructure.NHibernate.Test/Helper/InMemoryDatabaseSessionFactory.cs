using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NHibernate;
using NHibernate.ByteCode.Castle;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using PetStore.Infrastructure.NHibernate.Database;
using Environment = NHibernate.Cfg.Environment;

namespace PetStore.Infrastructure.NHibernate.Test.Helper
{
    /// <summary>
    /// SQLLite DatabaseSessionFactory
    /// </summary>
    public class InMemoryDatabaseSessionFactory : IDatabaseSessionFactory
    {
        #region Fields

        private static readonly ISessionFactory SessionFactory;
        private static readonly Configuration Configuration;
        private static ISession _session;

        #endregion

        #region Constructors

        static InMemoryDatabaseSessionFactory()
        {
            if (Configuration == null)
            {
                Configuration = new Configuration()
                    .SetProperty(Environment.ReleaseConnections, "on_close")
                    .SetProperty(Environment.Dialect, typeof(SQLiteDialect).AssemblyQualifiedName)
                    .SetProperty(Environment.ConnectionDriver, typeof(SQLite20Driver).AssemblyQualifiedName)
                    .SetProperty(Environment.ConnectionString, "data source=:memory:")
                    .SetProperty(Environment.ProxyFactoryFactoryClass,
                                 typeof(ProxyFactoryFactory).AssemblyQualifiedName)
                    .AddAssembly(Assembly.GetAssembly(typeof(UnitOfWork)));
            }

            SessionFactory = Configuration.BuildSessionFactory();
        }

        #endregion

        #region Methods

        public ISession Retrieve()
        {
            return RetrieveInternal();
        }

        public ISession OpenIndependentSession()
        {
            ISession session = SessionFactory.OpenSession(RetrieveInternal().Connection);
            session.FlushMode = FlushMode.Never;
            return session;
        }

        public void Close()
        {
            CloseInternal();
        }

        #endregion

        #region Static Methods

        public static void CreateDatabase()
        {
            new SchemaExport(Configuration).Execute(true, true, false, RetrieveInternal().Connection, Console.Out);
            Console.Out.Flush();
        }

        public static ISession RetrieveInternal()
        {
            if (_session == null)
            {
                _session = SessionFactory.OpenSession();
                _session.FlushMode = FlushMode.Never;
            }
            return _session;
        }

        public static void CloseInternal()
        {
            if (_session != null)
            {
                _session.Close();
                _session = null;
            }
        }

        #endregion
    }
}
