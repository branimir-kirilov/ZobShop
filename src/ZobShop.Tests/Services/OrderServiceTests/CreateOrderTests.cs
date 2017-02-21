using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using ZobShop.Data.Contracts;
using ZobShop.Factories;
using ZobShop.Models;
using ZobShop.Services;

namespace ZobShop.Tests.Services.OrderServiceTests
{
    [TestFixture]
    public class CreateOrderTests
    {
        [TestCase("Pesho", "Pesho str", "123456789", 21)]
        public void TestCreateOrder_ShouldCallFactoryCreateOrderCorrectly(string name,
            string address,
            string phoneNumber,
            decimal total)
        {
            var mockedOrder = new Mock<Order>();

            var mockedFactory = new Mock<IOrderFactory>();
            mockedFactory.Setup(
                    f => f.CreateOrder(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>()))
                .Returns(mockedOrder.Object);

            var mockedRepository = new Mock<IRepository<Order>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new OrderService(mockedFactory.Object, mockedRepository.Object, mockedUnitOfWork.Object);

            var products = new List<ProductOrder>();

            service.CreateOrder(name, address, phoneNumber, total, products);

            mockedFactory.Verify(f => f.CreateOrder(name, address, phoneNumber, total), Times.Once);
        }

        [TestCase("Pesho", "Pesho str", "123456789", 21)]
        public void TestCreateOrder_ShouldCallRepositoryAddCorrectly(string name,
            string address,
            string phoneNumber,
            decimal total)
        {
            var mockedOrder = new Mock<Order>();

            var mockedFactory = new Mock<IOrderFactory>();
            mockedFactory.Setup(
                    f => f.CreateOrder(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>()))
                .Returns(mockedOrder.Object);

            var mockedRepository = new Mock<IRepository<Order>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new OrderService(mockedFactory.Object, mockedRepository.Object, mockedUnitOfWork.Object);

            var products = new List<ProductOrder>();

            service.CreateOrder(name, address, phoneNumber, total, products);

            mockedRepository.Verify(r => r.Add(mockedOrder.Object), Times.Once);
        }

        [TestCase("Pesho", "Pesho str", "123456789", 21)]
        public void TestCreateOrder_ShouldCallUnitOfWorkCommitCorrectly(string name,
            string address,
            string phoneNumber,
            decimal total)
        {
            var mockedOrder = new Mock<Order>();

            var mockedFactory = new Mock<IOrderFactory>();
            mockedFactory.Setup(
                    f => f.CreateOrder(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>()))
                .Returns(mockedOrder.Object);

            var mockedRepository = new Mock<IRepository<Order>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new OrderService(mockedFactory.Object, mockedRepository.Object, mockedUnitOfWork.Object);

            var products = new List<ProductOrder>();

            service.CreateOrder(name, address, phoneNumber, total, products);

            mockedUnitOfWork.Verify(u => u.Commit(), Times.Once);
        }

        [TestCase("Pesho", "Pesho str", "123456789", 21)]
        public void TestCreateOrder_ShouldReturnResultCorrectly(string name,
            string address,
            string phoneNumber,
            decimal total)
        {
            var mockedOrder = new Mock<Order>();

            var mockedFactory = new Mock<IOrderFactory>();
            mockedFactory.Setup(
                    f => f.CreateOrder(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>()))
                .Returns(mockedOrder.Object);

            var mockedRepository = new Mock<IRepository<Order>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new OrderService(mockedFactory.Object, mockedRepository.Object, mockedUnitOfWork.Object);

            var products = new List<ProductOrder>();

            var result = service.CreateOrder(name, address, phoneNumber, total, products);

            Assert.AreSame(mockedOrder.Object, result);
        }
    }
}
