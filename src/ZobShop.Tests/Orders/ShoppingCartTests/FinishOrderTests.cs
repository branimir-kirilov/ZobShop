using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using ZobShop.Factories;
using ZobShop.Models;
using ZobShop.Orders;
using ZobShop.Orders.Contracts;
using ZobShop.Orders.Factories;
using ZobShop.Services.Contracts;

namespace ZobShop.Tests.Orders.ShoppingCartTests
{
    [TestFixture]
    public class FinishOrderTests
    {
        [TestCase("Pesho", "Pesho str", "123456789", 3, 45)]
        public void TestFinishOrder_ShouldCallOrderServiceCreateOrderCorrectly(string name, string address,
            string phoneNumber, int quantity, decimal price)
        {
            var mockedService = new Mock<IProductService>();
            var mockedFactory = new Mock<ICartLineFactory>();
            var mockedOrderFactory = new Mock<IOrderFactory>();
            var mockedOrderService = new Mock<IOrderService>();

            var product = new Product { Price = price };

            var mockedLine = new Mock<ICartLine>();
            mockedLine.Setup(l => l.Product).Returns(product);
            mockedLine.Setup(l => l.Quantity).Returns(quantity);

            var cart = new ShoppingCart(mockedFactory.Object, mockedService.Object, mockedOrderService.Object, mockedOrderFactory.Object);
            cart.CartLines.Add(mockedLine.Object);

            cart.FinishOrder(name, address, phoneNumber);

            var expectedTotal = product.Price * quantity;

            mockedOrderService.Verify(s =>
            s.CreateOrder(name, address, phoneNumber, expectedTotal, It.IsAny<ICollection<ProductOrder>>()), Times.Once);
        }

        [TestCase("Pesho", "Pesho str", "123456789", 3, 45)]
        public void TestFinishOrder_ServiceReturnsNull_ShouldNotEmptyCartLines(string name, string address,
          string phoneNumber, int quantity, decimal price)
        {
            var mockedService = new Mock<IProductService>();
            var mockedFactory = new Mock<ICartLineFactory>();
            var mockedOrderFactory = new Mock<IOrderFactory>();
            var mockedOrderService = new Mock<IOrderService>();

            var product = new Product { Price = price };

            var mockedLine = new Mock<ICartLine>();
            mockedLine.Setup(l => l.Product).Returns(product);
            mockedLine.Setup(l => l.Quantity).Returns(quantity);

            var cart = new ShoppingCart(mockedFactory.Object, mockedService.Object, mockedOrderService.Object, mockedOrderFactory.Object);
            cart.CartLines.Add(mockedLine.Object);

            cart.FinishOrder(name, address, phoneNumber);

            CollectionAssert.IsNotEmpty(cart.CartLines);
        }

        [TestCase("Pesho", "Pesho str", "123456789", 3, 45)]
        public void TestFinishOrder_ServiceReturnsOrder_ShouldNotEmptyCartLines(string name, string address,
          string phoneNumber, int quantity, decimal price)
        {
            var mockedService = new Mock<IProductService>();
            var mockedFactory = new Mock<ICartLineFactory>();
            var mockedOrderFactory = new Mock<IOrderFactory>();

            var mockedOrder = new Mock<Order>();

            var mockedOrderService = new Mock<IOrderService>();
            mockedOrderService.Setup(s => s.CreateOrder(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    It.IsAny<decimal>(), It.IsAny<ICollection<ProductOrder>>()))
                .Returns(mockedOrder.Object);

            var product = new Product { Price = price };

            var mockedLine = new Mock<ICartLine>();
            mockedLine.Setup(l => l.Product).Returns(product);
            mockedLine.Setup(l => l.Quantity).Returns(quantity);

            var cart = new ShoppingCart(mockedFactory.Object, mockedService.Object, mockedOrderService.Object, mockedOrderFactory.Object);
            cart.CartLines.Add(mockedLine.Object);

            cart.FinishOrder(name, address, phoneNumber);

            CollectionAssert.IsEmpty(cart.CartLines);
        }
    }
}
