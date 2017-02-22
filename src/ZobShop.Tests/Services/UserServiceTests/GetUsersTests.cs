using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using ZobShop.Data.Contracts;
using ZobShop.Models;
using ZobShop.Services;

namespace ZobShop.Tests.Services.UserServiceTests
{
    [TestFixture]
    public class GetUsersTests
    {
        [Test]
        public void TestGetUsers_ShouldCallRepositoryEntities()
        {
            var repository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(repository.Object, mockedUnitOfWork.Object);

            service.GetUsers();

            repository.Verify(x => x.Entities, Times.Once);
        }

        [Test]
        public void TestGetUsers_ShouldReturnCorrectly()
        {
            var firstMockedUser = new Mock<User>();
            var secondMockedUser = new Mock<User>();
            var thirdMockedUser = new Mock<User>();

            var collection = new List<User>
            {
                firstMockedUser.Object,
                secondMockedUser.Object,
                thirdMockedUser.Object
           };

            var repository = new Mock<IRepository<User>>();
            repository.Setup(x => x.Entities).Returns(collection);
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(repository.Object, mockedUnitOfWork.Object);

            var result = service.GetUsers();

            Assert.AreEqual(collection, result);
        }
    }
}
