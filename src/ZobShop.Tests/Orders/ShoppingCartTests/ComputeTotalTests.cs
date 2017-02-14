using Moq;
using NUnit.Framework;
using ZobShop.Orders;
using ZobShop.Orders.Factories;
using ZobShop.Services.Contracts;

namespace ZobShop.Tests.Orders.ShoppingCartTests
{
    [TestFixture]
    public class ComputeTotalTests
    {
        [Test]
        public void TestComputeTotal_EmptyCart_ShouldReturnZero()
        {
            var zero = 0m;

            var mockedService = new Mock<IProductService>();
            var mockedFactory = new Mock<ICartLineFactory>();

            var cart = new ShoppingCart(mockedFactory.Object, mockedService.Object);

            var result = cart.ComputeTotal();

            Assert.AreEqual(zero, result);
        }
    }
}
