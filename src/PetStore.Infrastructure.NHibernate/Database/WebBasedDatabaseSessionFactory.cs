using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NHibernate;
using NHibernate.Cfg;

namespace PetStore.Infrastructure.NHibernate.Database
{
    /// <summary>
    /// Database session factory for WEB apps. 
    /// Based on Request Context.
    /// </summary>
    public class WebBasedDatabaseSessionFactory : IDatabaseSessionFactory
    {
        #region Fields

        private const string CurrentSessionKey = "nhibernate.current_session";
        private static ISessionFactory _sessionFactory;
        private static object _sessionFactorySync = new object();

        #endregion

        #region Properties

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    lock (_sessionFactorySync)
                    {
                        if (_sessionFactory == null)
                        {
                            _sessionFactory = new Configuration().Configure().BuildSessionFactory();
                        }
                    }

                }
                return _sessionFactory;
            }
        }

        #endregion

        #region Constructors

        static WebBasedDatabaseSessionFactory()
        {
            SetupProfiler();
        }

        #endregion

        #region IDatabaseSessionFactory Members

        public ISession Retrieve()
        {
            HttpContext context = HttpContext.Current;
            ISession currentSession = context.Items[CurrentSessionKey] as ISession;

            if (currentSession == null)
            {
                currentSession = SessionFactory.OpenSession();
                currentSession.FlushMode = FlushMode.Never;
                context.Items[CurrentSessionKey] = currentSession;
            }

            return currentSession;
        }

        public ISession OpenIndependentSession()
        {
            ISession session = SessionFactory.OpenSession();
            session.FlushMode = FlushMode.Never;
            return session;
        }

        public void Close()
        {
            HttpContext context = HttpContext.Current;
            ISession currentSession = context.Items[CurrentSessionKey] as ISession;

            if (currentSession == null)
            {
                return;
            }

            currentSession.Close();
            context.Items.Remove(CurrentSessionKey);
        }

        #endregion

        #region Private Methods

        private static void SetupProfiler()
        {
#if DEBUG
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
#endif
        }

        #endregion
    }
}
