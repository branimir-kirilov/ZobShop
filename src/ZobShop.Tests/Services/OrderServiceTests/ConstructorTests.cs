using System;
using Moq;
using NUnit.Framework;
using ZobShop.Data.Contracts;
using ZobShop.Factories;
using ZobShop.Models;
using ZobShop.Services;
using ZobShop.Services.Contracts;

namespace ZobShop.Tests.Services.OrderServiceTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassFactoryNull_ShouldThrowArgumentNullException()
        {
            var mockedRepository = new Mock<IRepository<Order>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentNullException>(() =>
            new OrderService(null, mockedRepository.Object, mockedUnitOfWork.Object));
        }

        [Test]
        public void TestConstructor_PassRepositoryNull_ShouldThrowArgumentNullException()
        {
            var mockedFactory = new Mock<IOrderFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentNullException>(() =>
            new OrderService(mockedFactory.Object, null, mockedUnitOfWork.Object));
        }

        [Test]
        public void TestConstructor_PassUnitOfWorkNull_ShouldThrowArgumentNullException()
        {
            var mockedFactory = new Mock<IOrderFactory>();
            var mockedRepository = new Mock<IRepository<Order>>();

            Assert.Throws<ArgumentNullException>(() =>
            new OrderService(mockedFactory.Object, mockedRepository.Object, null));
        }

        [Test]
        public void TestConstructor_PassEverything_ShouldInitializeCorrectly()
        {
            var mockedFactory = new Mock<IOrderFactory>();
            var mockedRepository = new Mock<IRepository<Order>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new OrderService(mockedFactory.Object, mockedRepository.Object, mockedUnitOfWork.Object);

            Assert.IsNotNull(service);
        }

        [Test]
        public void TestConstructor_PassEverything_ShouldBeInstanceOfIOrderService()
        {
            var mockedFactory = new Mock<IOrderFactory>();
            var mockedRepository = new Mock<IRepository<Order>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new OrderService(mockedFactory.Object, mockedRepository.Object, mockedUnitOfWork.Object);

            Assert.IsInstanceOf<IOrderService>(service);
        }
    }
}
