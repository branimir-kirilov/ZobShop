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
            Assert.Throws<ArgumentNullException>(
                () => new UserService(null));
        }

        [Test]
        public void TestConstructor_PassCorrectRepository_ShouldNotThrow()
        {
            var repository = new Mock<IRepository<User>>();

            Assert.DoesNotThrow(() => new UserService(repository.Object));
        }
    }
}
