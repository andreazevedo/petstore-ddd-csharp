using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using PetStore.Core.Infrastructure.InversionOfControl;
using PetStore.Core.Infrastructure.UnitOfWork;
using PetStore.Core.Test.Infrastructure.InversionOfControl;

namespace PetStore.Core.Test.Infrastructure.UnitOfWork
{
    [TestFixture]
    public class UnitOfWorkManagerTest
    {
        #region Test Methods

        [Test]
        public void BeginShouldReturnCorrectResult()
        {
            IoC.Initialize(IoCTest.GetIDependencyResolverMock());

            IUnitOfWork unitOfWork = UnitOfWorkManager.Begin();

            Assert.IsNotNull(unitOfWork);
        }

        #endregion

        #region Static Methods

        public static IUnitOfWork GetUnitOfWorkMock()
        {
            Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
            return unitOfWorkMock.Object;
        }

        #endregion
    }
}
