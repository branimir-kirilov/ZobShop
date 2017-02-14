using System.Linq;
using Moq;
using NUnit.Framework;
using ZobShop.Orders;
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

            var cart = new ShoppingCart(mockedFactory.Object, mockedService.Object);

            cart.RemoveItem(productId);

            Assert.IsFalse(cart.CartLines.Any());
        }
    }
}
