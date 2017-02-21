using System.Linq;
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
    public class RemoveItemTests
    {
        [TestCase(1)]
        [TestCase(1278)]
        [TestCase(15)]
        public void TestRemoveItem_EmptyCollection_ShouldNotDoAnything(int productId)
        {
            var mockedService = new Mock<IProductService>();
            var mockedFactory = new Mock<ICartLineFactory>();
            var mockedOrderFactory = new Mock<IOrderFactory>();
            var mockedOrderService = new Mock<IOrderService>();

            var cart = new ShoppingCart(mockedFactory.Object, mockedService.Object, mockedOrderService.Object, mockedOrderFactory.Object);


            cart.RemoveItem(productId);

            Assert.IsFalse(cart.CartLines.Any());
        }

        [TestCase(1)]
        [TestCase(1278)]
        [TestCase(15)]
        public void TestRemoveItem_CollectionContainsItem_ShouldRemoveCorrectly(int productId)
        {
            var mockedService = new Mock<IProductService>();
            var mockedFactory = new Mock<ICartLineFactory>();
            var mockedOrderFactory = new Mock<IOrderFactory>();
            var mockedOrderService = new Mock<IOrderService>();

            var product = new Product { ProductId = productId };

            var mockedLine = new Mock<ICartLine>();
            mockedLine.Setup(l => l.Product).Returns(product);

            var cart = new ShoppingCart(mockedFactory.Object, mockedService.Object, mockedOrderService.Object, mockedOrderFactory.Object);
            cart.CartLines.Add(mockedLine.Object);

            cart.RemoveItem(productId);

            CollectionAssert.DoesNotContain(cart.CartLines, mockedLine.Object);
        }
    }
}
