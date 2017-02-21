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
    public class AddProductTests
    {
        [TestCase(1, 2)]
        [TestCase(12, 13)]
        public void TestAddProduct_EmptyLine_ShouldCallServiceGetById(int id, int quantity)
        {
            var mockedService = new Mock<IProductService>();
            var mockedFactory = new Mock<ICartLineFactory>();
            var mockedOrderFactory = new Mock<IOrderFactory>();
            var mockedOrderService = new Mock<IOrderService>();

            var cart = new ShoppingCart(mockedFactory.Object, mockedService.Object, mockedOrderService.Object, mockedOrderFactory.Object);

            cart.AddItem(id, quantity);

            mockedService.Verify(x => x.GetById(id), Times.Once);
        }

        [TestCase(1, 2)]
        [TestCase(12, 13)]
        public void TestAddProduct_ServiceGetByIdDoesNotReturnProduct_ShouldNotCallFactoryCreateProduct(int id, int quantity)
        {
            var mockedService = new Mock<IProductService>();
            mockedService.Setup(x => x.GetById(It.IsAny<int>())).Returns((Product)null);

            var mockedFactory = new Mock<ICartLineFactory>();
            var mockedOrderFactory = new Mock<IOrderFactory>();
            var mockedOrderService = new Mock<IOrderService>();

            var cart = new ShoppingCart(mockedFactory.Object, mockedService.Object, mockedOrderService.Object, mockedOrderFactory.Object);

            cart.AddItem(id, quantity);

            mockedFactory.Verify(x => x.CreateCartLine(It.IsAny<Product>(), It.IsAny<int>()), Times.Never);
        }

        [TestCase(1, 2)]
        [TestCase(12, 13)]
        public void TestAddProduct_ServiceGetByIdDoesReturnProduct_ShouldCallFactoryCreateProduct(int id, int quantity)
        {
            var mockedProduct = new Mock<Product>();

            var mockedService = new Mock<IProductService>();
            mockedService.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedProduct.Object);

            var mockedFactory = new Mock<ICartLineFactory>();
            var mockedOrderFactory = new Mock<IOrderFactory>();
            var mockedOrderService = new Mock<IOrderService>();

            var cart = new ShoppingCart(mockedFactory.Object, mockedService.Object, mockedOrderService.Object, mockedOrderFactory.Object);

            cart.AddItem(id, quantity);

            mockedFactory.Verify(x => x.CreateCartLine(mockedProduct.Object, quantity), Times.Once);
        }

        [TestCase(1, 2)]
        [TestCase(12, 13)]
        public void TestAddProduct_ServiceGetByIdDoesReturnProduct_ShouldAddMockedLineToLines(int id, int quantity)
        {
            var mockedProduct = new Mock<Product>();

            var mockedService = new Mock<IProductService>();
            mockedService.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedProduct.Object);

            var mockedLine = new Mock<ICartLine>();
            var mockedFactory = new Mock<ICartLineFactory>();
            mockedFactory.Setup(x => x.CreateCartLine(It.IsAny<Product>(), It.IsAny<int>()))
                .Returns(mockedLine.Object);

            var mockedOrderFactory = new Mock<IOrderFactory>();
            var mockedOrderService = new Mock<IOrderService>();

            var cart = new ShoppingCart(mockedFactory.Object, mockedService.Object, mockedOrderService.Object, mockedOrderFactory.Object);

            cart.AddItem(id, quantity);

            Assert.IsTrue(cart.CartLines.Contains(mockedLine.Object));
        }

        [TestCase(1, 2, 15)]
        [TestCase(12, 13, 33)]
        public void TestAddProduct_LinesContainsProduct_ShouldAddQuantityToLine(int id, int quantity, int quantityToAdd)
        {
            var product = new Product { ProductId = id };

            var mockedService = new Mock<IProductService>();

            var mockedLine = new Mock<ICartLine>();
            mockedLine.Setup(l => l.Product).Returns(product);
            mockedLine.Setup(l => l.Quantity).Returns(quantity);

            var mockedFactory = new Mock<ICartLineFactory>();
            mockedFactory.Setup(x => x.CreateCartLine(It.IsAny<Product>(), It.IsAny<int>()))
                .Returns(mockedLine.Object);

            var mockedOrderFactory = new Mock<IOrderFactory>();
            var mockedOrderService = new Mock<IOrderService>();

            var cart = new ShoppingCart(mockedFactory.Object, mockedService.Object, mockedOrderService.Object, mockedOrderFactory.Object);
            cart.CartLines.Add(mockedLine.Object);

            cart.AddItem(id, quantityToAdd);

            mockedLine.Verify(l => l.Quantity, Times.Once);
        }
    }
}
