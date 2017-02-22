using System;
using Moq;
using NUnit.Framework;
using ZobShop.Data.Contracts;
using ZobShop.Models;
using ZobShop.Services;

namespace ZobShop.Tests.Services.UserServiceTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassRepositoryNull_ShouldThrowArgumentNullException()
        {
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentNullException>(
                () => new UserService(null, mockedUnitOfWork.Object));
        }

        [Test]
        public void TestConstructor_PassUnitOfWorkNull_ShouldThrowArgumentNullException()
        {
            var repository = new Mock<IRepository<User>>();

            Assert.Throws<ArgumentNullException>(
                () => new UserService(repository.Object, null));
        }

        [Test]
        public void TestConstructor_PassCorrectRepository_ShouldNotThrow()
        {
            var repository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.DoesNotThrow(() => new UserService(repository.Object, mockedUnitOfWork.Object));
        }
    }
}
