using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Exceptions;
using PetStore.Core.Repository;
using PetStore.Infrastructure.NHibernate.Database;

namespace PetStore.Infrastructure.NHibernate.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Properties

        internal ISession Session { get; private set; }

        #endregion

        #region Constructors

        private Repository(ISession session)
        {
            Session = session;
        }

        protected Repository(IDatabaseSessionFactory databaseSessionFactory)
            : this(databaseSessionFactory.Retrieve())
        { }

        #endregion

        #region Methods

        public virtual void Add(TEntity obj)
        {
            try
            {
                Session.SaveOrUpdate(obj);
                Session.Flush();
            }
            catch (PropertyValueException propertyValueException)
            {
                throw new AddPersistenceException(obj, propertyValueException);
            }
            catch (GenericADOException genericAdoException)
            {
                throw new AddPersistenceException(obj, genericAdoException);
            }
        }

        public void Remove(TEntity obj)
        {
            try
            {
                Session.Delete(obj);
                Session.Flush();
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

        public virtual TEntity FindById(int id)
        {
            try
            {
                var obj = Session.Get<TEntity>(id);
                return obj;
            }
            catch (ObjectNotFoundException objectNotFoundException)
            {
                throw new FindPersistenceException(typeof(TEntity), id, objectNotFoundException);
            }
            catch (PersistentObjectException persistentObjectException)
            {
                throw new FindPersistenceException(typeof(TEntity), id, persistentObjectException);
            }
        }

        #endregion
    }
}
