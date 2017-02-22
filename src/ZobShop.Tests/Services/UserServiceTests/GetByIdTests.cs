using Moq;
using NUnit.Framework;
using ZobShop.Data.Contracts;
using ZobShop.Models;
using ZobShop.Services;

namespace ZobShop.Tests.Services.UserServiceTests
{
    [TestFixture]
    public class GetByIdTests
    {
        [TestCase("47a46953-1469-438b-a025-a73e3942cbb3")]
        [TestCase("cbf17e36-013a-4591-8697-5e3ac2dc7fc7")]
        [TestCase("92813baa-0db4-403f-8c1c-1c7d4dfa7f40")]
        public void TestGetById_PassValidId_ShouldCallRepositoryGetById(string id)
        {
            var repository = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(repository.Object, mockedUnitOfWork.Object);
            service.GetById(id);

            repository.Verify(r => r.GetById(id), Times.Once);
        }

        [TestCase("47a46953-1469-438b-a025-a73e3942cbb3")]
        [TestCase("cbf17e36-013a-4591-8697-5e3ac2dc7fc7")]
        [TestCase("92813baa-0db4-403f-8c1c-1c7d4dfa7f40")]
        public void TestGetById_PassValidId_ShouldReturnCorrectly(string id)
        {
            var mockedUser = new Mock<User>();

            var repository = new Mock<IRepository<User>>();
            repository.Setup(r => r.GetById(It.IsAny<object>())).Returns(mockedUser.Object);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new UserService(repository.Object, mockedUnitOfWork.Object);
            var result = service.GetById(id);

            Assert.AreSame(mockedUser.Object, result);
        }
    }
}
