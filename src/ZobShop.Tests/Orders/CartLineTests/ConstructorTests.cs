using Moq;
using NUnit.Framework;
using ZobShop.Models;
using ZobShop.Orders;

namespace ZobShop.Tests.Orders.CartLineTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [TestCase(1)]
        [TestCase(12)]
        public void TestConstructor_PassValidParameters_ShouldSetupProductCorrectly(int quantity)
        {
            var mockedProduct = new Mock<Product>();

            var line = new CartLine(mockedProduct.Object, quantity);

            Assert.AreEqual(mockedProduct.Object, line.Product);
        }

        [TestCase(1)]
        [TestCase(12)]
        public void TestConstructor_PassValidParameters_ShouldSetupQuantityCorrectly(int quantity)
        {
            var mockedProduct = new Mock<Product>();

            var line = new CartLine(mockedProduct.Object, quantity);

            Assert.AreEqual(quantity, line.Quantity);
        }
    }
}
