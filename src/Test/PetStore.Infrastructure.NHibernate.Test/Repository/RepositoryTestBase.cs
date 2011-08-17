using NUnit.Framework;
using PetStore.Infrastructure.NHibernate.Repository.Log;
using PetStore.Infrastructure.NHibernate.Test.Helper;

namespace PetStore.Infrastructure.NHibernate.Test.Repository
{
    public class RepositoryTestBase
    {
        #region Properties

        public ErrorRepository ErrorRepository { get; private set; }

        #endregion

        #region Methods

        [SetUp]
        public void Initialize()
        {
            InMemoryDatabaseSessionFactory.CreateDatabase();

            var databaseSessionFactory = new InMemoryDatabaseSessionFactory();

            ErrorRepository = new ErrorRepository(databaseSessionFactory);
        }

        [TearDown]
        public void CleanUp()
        {
            ErrorRepository = null;

            InMemoryDatabaseSessionFactory.CloseInternal();
        }

        #endregion
    }
}
