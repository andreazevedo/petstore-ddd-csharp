using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PetStore.Core.DomainObjects;
using PetStore.Core.DomainObjects.Log;
using PetStore.Core.Repository;

namespace PetStore.Infrastructure.NHibernate.Test.Repository.Log
{
    [TestFixture]
    public class ErrorRepositoryTest : RepositoryTestBase
    {
        #region Methods

        [Test]
        public void Add_ShouldReturnCorrectResult()
        {
            var error = GetValidDomainError();
            Assert.AreEqual(0, error.Id); // Não salvo ainda.
            ErrorRepository.Add(error);

            Assert.IsNotNull(error);
            Assert.AreNotEqual(0, error.Id); // Já salvo.
        }

        [Test]
        public void Remove_ShouldReturnCorrectResult()
        {
            var error = GetValidDomainError();
            Assert.AreEqual(0, error.Id); // Não salvo ainda.
            ErrorRepository.Add(error);

            ErrorRepository.Remove(error);
        }

        [Test]
        [ExpectedException(typeof(RemovePersistenceException))]
        public void Remove_ShouldThrowException()
        {
            Error error = GetValidDomainError();
            error.Id = 1;
            ErrorRepository.Remove(error);
        }

        [Test]
        [ExpectedException(typeof(RemovePersistenceException))]
        public void Remove_CalledTwiceShouldThrowException()
        {
            Error error = GetValidDomainError();
            ErrorRepository.Add(error);
            ErrorRepository.Remove(error);
            ErrorRepository.Remove(error);
        }

        [Test]
        public void FindById_ShouldReturnCorrectResult()
        {
            Error originalError = GetValidDomainError();
            ErrorRepository.Add(originalError);

            Error loadedError = ErrorRepository.FindById(originalError.Id);

            Assert.IsNotNull(loadedError);
            Assert.AreEqual(originalError.Id, loadedError.Id);
            Assert.AreEqual(originalError.Message, loadedError.Message);
            Assert.AreEqual(originalError.Details, loadedError.Details);
            Assert.AreEqual(originalError.AdditionalInformation, loadedError.AdditionalInformation);
            Assert.AreEqual(originalError.Handled, loadedError.Handled);
        }

        [Test]
        public void FindById_OnNonExistentShouldReturnNull()
        {
            Error error = ErrorRepository.FindById(1);
            Assert.IsNull(error);
        }

        [Test]
        public void FindById_OnRemovedObjectShouldReturnNull()
        {
            Error error = GetValidDomainError();
            ErrorRepository.Add(error);
            ErrorRepository.Remove(error);
            Error loadedError = ErrorRepository.FindById(error.Id);
            Assert.IsNull(loadedError);
        }

        [Test]
        public void GetByFilter_ShouldReturnCorrectResult()
        {
            const int pageSize = 15;

            var error1 = GetValidDomainError();
            var error2 = GetAnotherValidDomainError();
            var error3 = GetValidGenericError();
            var error4 = GetAnotherValidGenericError();

            ErrorRepository.Add(error1);
            ErrorRepository.Add(error2);
            ErrorRepository.Add(error3);
            ErrorRepository.Add(error4);

            var pagedResult = ErrorRepository.FindByFilter(null, null, 0, pageSize);
            Assert.IsNotNull(pagedResult);
            Assert.IsFalse(pagedResult.IsEmpty);
            Assert.IsTrue(pagedResult.Result.Count == 4);
            Assert.IsTrue(pagedResult.Total == 4);
            Assert.AreEqual(pageSize, pagedResult.PageSize);
        }

        [Test]
        public void GetByFilter_ShouldReturnCorrectPageInCorrectOrder()
        {
            const int pageSize = 2;

            var error1 = GetValidDomainError();
            ErrorRepository.Add(error1);
            var error2 = GetAnotherValidDomainError();
            ErrorRepository.Add(error2);
            var error3 = GetValidGenericError();
            ErrorRepository.Add(error3);
            var error4 = GetAnotherValidGenericError();
            ErrorRepository.Add(error4);

            var pagedResult = ErrorRepository.FindByFilter(null, null, 1, pageSize);
            Assert.IsNotNull(pagedResult);
            Assert.IsFalse(pagedResult.IsEmpty);
            Assert.IsTrue(pagedResult.Result.Count == 2);
            Assert.IsTrue(pagedResult.Total == 4);
            Assert.AreEqual(pageSize, pagedResult.PageSize);
            Assert.AreEqual(error2.Id, pagedResult.Result.ElementAt(0).Id);
            Assert.AreEqual(error3.Id, pagedResult.Result.ElementAt(1).Id);
        }

        [Test]
        public void GetByFilter_ByType_ShouldReturnCorrectResult()
        {
            const int pageSize = 15;

            var error1 = GetValidDomainError();
            ErrorRepository.Add(error1);
            var error2 = GetAnotherValidDomainError();
            ErrorRepository.Add(error2);
            var error3 = GetValidGenericError();
            ErrorRepository.Add(error3);
            var error4 = GetAnotherValidGenericError();
            ErrorRepository.Add(error4);

            var pagedResult = ErrorRepository.FindByFilter(typeof(ApplicationException).FullName, null, 0, pageSize);
            Assert.IsNotNull(pagedResult);
            Assert.IsFalse(pagedResult.IsEmpty);
            Assert.IsTrue(pagedResult.Result.Count == 2);
            Assert.IsTrue(pagedResult.Total == 2);
            Assert.AreEqual(pageSize, pagedResult.PageSize);
            Assert.AreEqual(error3.Id, pagedResult.Result.ElementAt(0).Id);
            Assert.AreEqual(error4.Id, pagedResult.Result.ElementAt(1).Id);
        }

        [Test]
        public void GetByFilter_ByHandledTrue_ShouldReturnCorrectResult()
        {
            const int pageSize = 15;

            var error1 = GetValidDomainError();
            ErrorRepository.Add(error1);
            var error2 = GetAnotherValidDomainError();
            ErrorRepository.Add(error2);
            var error3 = GetValidGenericError();
            ErrorRepository.Add(error3);
            var error4 = GetAnotherValidGenericError();
            ErrorRepository.Add(error4);
            var error5 = GetNotHandledException();
            ErrorRepository.Add(error5);

            var pagedResult = ErrorRepository.FindByFilter(null, true, 0, pageSize);
            Assert.IsNotNull(pagedResult);
            Assert.IsFalse(pagedResult.IsEmpty);
            Assert.IsTrue(pagedResult.Result.Count == 4);
            Assert.IsTrue(pagedResult.Total == 4);
            Assert.AreEqual(pageSize, pagedResult.PageSize);
            foreach (var error in pagedResult.Result)
            {
                Assert.IsTrue(error.Handled);
            }
        }

        [Test]
        public void GetByFilter_ByHandledFalse_ShouldReturnCorrectResult()
        {
            const int pageSize = 15;

            var error1 = GetValidDomainError();
            ErrorRepository.Add(error1);
            var error2 = GetAnotherValidDomainError();
            ErrorRepository.Add(error2);
            var error3 = GetValidGenericError();
            ErrorRepository.Add(error3);
            var error4 = GetAnotherValidGenericError();
            ErrorRepository.Add(error4);
            var error5 = GetNotHandledException();
            ErrorRepository.Add(error5);

            var pagedResult = ErrorRepository.FindByFilter(null, false, 0, pageSize);
            Assert.IsNotNull(pagedResult);
            Assert.IsFalse(pagedResult.IsEmpty);
            Assert.IsTrue(pagedResult.Result.Count == 1);
            Assert.IsTrue(pagedResult.Total == 1);
            Assert.AreEqual(pageSize, pagedResult.PageSize);
            foreach (var error in pagedResult.Result)
            {
                Assert.IsFalse(error.Handled);
            }
        }

        [Test]
        public void GetByFilter_ByHandledNull_ShouldReturnCorrectResult()
        {
            const int pageSize = 15;

            var error1 = GetValidDomainError();
            ErrorRepository.Add(error1);
            var error2 = GetAnotherValidDomainError();
            ErrorRepository.Add(error2);
            var error3 = GetValidGenericError();
            ErrorRepository.Add(error3);
            var error4 = GetAnotherValidGenericError();
            ErrorRepository.Add(error4);
            var error5 = GetNotHandledException();
            ErrorRepository.Add(error5);

            var pagedResult = ErrorRepository.FindByFilter(null, null, 0, pageSize);
            Assert.IsNotNull(pagedResult);
            Assert.IsFalse(pagedResult.IsEmpty);
            Assert.IsTrue(pagedResult.Result.Count == 5);
            Assert.IsTrue(pagedResult.Total == 5);
            Assert.AreEqual(pageSize, pagedResult.PageSize);
        }

        [Test]
        public void GetByFilter_WithOrder_ShouldReturnCorrectResult()
        {
            const int pageSize = 15;

            var error1 = GetValidDomainError();
            var error2 = GetAnotherValidDomainError();
            var error3 = GetValidGenericError();
            var error4 = GetAnotherValidGenericError();

            ErrorRepository.Add(error1);
            ErrorRepository.Add(error2);
            ErrorRepository.Add(error3);
            ErrorRepository.Add(error4);

            var pagedResult = ErrorRepository.FindByFilter(null, null, 0, pageSize, "Message", true);
            Assert.IsNotNull(pagedResult);
            Assert.IsFalse(pagedResult.IsEmpty);
            Assert.IsTrue(pagedResult.Result.Count == 4);
            Assert.IsTrue(pagedResult.Total == 4);
            Assert.AreEqual(pageSize, pagedResult.PageSize);
            Assert.AreEqual(error2.Message, pagedResult.Result.ElementAt(0).Message);
            Assert.AreEqual(error1.Message, pagedResult.Result.ElementAt(1).Message);
            Assert.AreEqual(error3.Message, pagedResult.Result.ElementAt(2).Message);
            Assert.AreEqual(error4.Message, pagedResult.Result.ElementAt(3).Message);
        }

        #endregion

        #region Static Methods

        public static Error GetValidDomainError()
        {
            ValidationException validationException = new ValidationException("Erro de validação!");
            return DomainObjectsFactory.Log.CreateError(validationException);
        }

        public static Error GetAnotherValidDomainError()
        {
            AddPersistenceException addPersistenceException = new AddPersistenceException("Erro ao salvar o objeto!");
            return DomainObjectsFactory.Log.CreateError(addPersistenceException);
        }

        public static Error GetValidGenericError()
        {
            ApplicationException applicationException = new ApplicationException("Erro genérico!");
            return DomainObjectsFactory.Log.CreateError(applicationException);
        }

        public static Error GetAnotherValidGenericError()
        {
            ApplicationException applicationException = new ApplicationException("Outro erro genérico!");
            return DomainObjectsFactory.Log.CreateError(applicationException);
        }

        public static Error GetNotHandledException()
        {
            ApplicationException applicationException = new ApplicationException("Erro genérico, dessa vez não tratado!");
            return DomainObjectsFactory.Log.CreateError(applicationException, false);
        }

        #endregion
    }
}
