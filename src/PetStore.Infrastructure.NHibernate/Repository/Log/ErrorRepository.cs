using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Criterion.Lambda;
using NHibernate.Exceptions;
using PetStore.Core.DomainObjects.Log;
using PetStore.Core.Extension;
using PetStore.Core.Helper;
using PetStore.Core.Repository;
using PetStore.Core.Repository.Log;
using PetStore.Infrastructure.NHibernate.Database;

namespace PetStore.Infrastructure.NHibernate.Repository.Log
{
    public class ErrorRepository : IErrorRepository
    {
        #region Constructors

        public ErrorRepository(IDatabaseSessionFactory databaseSessionFactory)
        {
            DatabaseSessionFactory = databaseSessionFactory;
        }

        #endregion

        #region Properties

        internal IDatabaseSessionFactory DatabaseSessionFactory { get; private set; }

        #endregion

        #region Methods

        public void Add(Error obj)
        {
            try
            {
                ISession session = DatabaseSessionFactory.OpenIndependentSession();
                try
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(obj);
                        session.Flush();
                        transaction.Commit();
                    }
                }
                finally
                {
                    session.Close();
                }
            }
            catch (GenericADOException genericAdoException)
            {
                throw new AddPersistenceException(obj, genericAdoException);
            }
        }

        public void Remove(Error obj)
        {
            try
            {
                ISession session = DatabaseSessionFactory.OpenIndependentSession();
                try
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(obj);
                        session.Flush();
                        transaction.Commit();
                    }

                }
                finally
                {
                    session.Close();

                }
            }
            catch (ObjectNotFoundException objectNotFoundException)
            {
                throw new RemovePersistenceException(obj, objectNotFoundException);
            }
            catch (StaleStateException staleStateException)
            {
                throw new RemovePersistenceException(obj, staleStateException);
            }
            catch (TransientObjectException transientObjectException)
            {
                throw new RemovePersistenceException(obj, transientObjectException);
            }
        }

        public Error FindById(int id)
        {
            try
            {
                ISession session = DatabaseSessionFactory.OpenIndependentSession();
                try
                {
                    var obj = session.Get<Error>(id);
                    //return ProxyHandler.Unproxy(session, obj);
                    return obj;
                }
                finally
                {
                    session.Close();
                }
            }
            catch (ObjectNotFoundException objectNotFoundException)
            {
                throw new FindPersistenceException(typeof(Error), id, objectNotFoundException);
            }
            catch (PersistentObjectException persistentObjectException)
            {
                throw new FindPersistenceException(typeof(Error), id, persistentObjectException);
            }
        }

        public PagedResult<Error> FindByFilter(string type, bool? handled, int start, int max)
        {
            ISession session = DatabaseSessionFactory.OpenIndependentSession();
            try
            {
                IQueryOver<Error, Error> criteria = GetCriteria(session, type, handled);

                var result = criteria
                        .OrderBy(e => e.GeneratedAt).Desc()
                        .Skip(start)
                        .Take(max)
                        .List();

                var total = CountByFilter(type, handled);

                return new PagedResult<Error>(result, total, max);

            }
            finally
            {
                session.Close();
            }
        }

        public PagedResult<Error> FindByFilter(string type, bool? handled, int start, int max, string orderBy = "GeneratedAt", bool asc = false)
        {
            ISession session = DatabaseSessionFactory.OpenIndependentSession();
            try
            {
                IQueryOver<Error, Error> criteria = GetCriteria(session, type, handled);

                var order = criteria.OrderBy(Projections.Property(orderBy));
                criteria = asc ? order.Asc() : order.Desc();
                var result = criteria
                    .Skip(start)
                    .Take(max)
                    .List();

                var total = CountByFilter(type, handled);

                return new PagedResult<Error>(result, total, max);

            }
            finally
            {
                session.Close();
            }
        }

        public int CountByFilter(string type, bool? handled)
        {
            ISession session = DatabaseSessionFactory.OpenIndependentSession();
            try
            {
                IQueryOver<Error, Error> criteria = GetCriteria(session, type, handled);

                return criteria.RowCount();

            }
            finally
            {
                session.Close();
            }
        }

        #endregion

        #region Private Methods

        private static IQueryOver<Error, Error> GetCriteria(ISession session, string type, bool? handled)
        {
            var criteria = session.QueryOver<Error>();

            if (!String.IsNullOrEmpty(type))
            {
                criteria = criteria.WhereRestrictionOn(e => e.Type).IsLike("%{0}%".FormatWith(type));
            }
            if (handled.HasValue)
            {
                criteria = criteria.Where(e => e.Handled == handled.Value);
            }
            return criteria;
        }

        #endregion
    }
}
