using System.Linq;
using Moq;
using NUnit.Framework;
using ZobShop.Orders;
using ZobShop.Orders.Contracts;
using ZobShop.Orders.Factories;
using ZobShop.Services.Contracts;

namespace ZobShop.Tests.Orders.ShoppingCartTests
{
    [TestFixture]
    public class ClearCartTests
    {
        [Test]
        public void TestClearCart_ShouldClearCorrectly()
        {
            var mockedService = new Mock<IProductService>();
            var mockedFactory = new Mock<ICartLineFactory>();

            var cart = new ShoppingCart(mockedFactory.Object, mockedService.Object);

            var mockedCartLine = new Mock<ICartLine>();
            cart.CartLines.Add(mockedCartLine.Object);

            var hasAny = cart.CartLines.Any();

            cart.ClearCart();

            var afterClear = cart.CartLines.Any();

            Assert.AreNotEqual(hasAny, afterClear);
        }
    }
}
