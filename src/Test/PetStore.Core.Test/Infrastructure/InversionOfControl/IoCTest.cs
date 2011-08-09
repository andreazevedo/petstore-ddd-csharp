using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;
using PetStore.Core.Infrastructure.InversionOfControl;
using PetStore.Core.Infrastructure.Logging;
using PetStore.Core.Infrastructure.UnitOfWork;
using PetStore.Core.Test.Infrastructure.Logging;
using PetStore.Core.Test.Infrastructure.UnitOfWork;

namespace PetStore.Core.Test.Infrastructure.InversionOfControl
{
    [TestFixture]
    public class IoCTest
    {
        #region Test Methods

        [Test]
        public void InitializeShouldNotThrowException()
        {
            IDependencyResolver dependencyResolverMock = GetIDependencyResolverMock();
            IoC.Initialize(dependencyResolverMock);
        }

        [Test]
        public void ResolveShouldReturnCorrectResult()
        {
            IDependencyResolver dependencyResolverMock = GetIDependencyResolverMock();
            IoC.Initialize(dependencyResolverMock);
            ILogger logger = IoC.Resolve<ILogger>();
            Assert.IsNotNull(logger);
        }
        #endregion

        #region Static Methods

        public static IDependencyResolver GetIDependencyResolverMock()
        {
            Mock<IDependencyResolver> dependencyResolver = new Mock<IDependencyResolver>();

            dependencyResolver.Setup(d => d.Resolve<ILogger>()).Returns(LoggerTest.GetILogMock());
            dependencyResolver.Setup(d => d.Resolve<IUnitOfWork>()).Returns(UnitOfWorkManagerTest.GetUnitOfWorkMock());

            return dependencyResolver.Object;
        }

        #endregion
    }
}
