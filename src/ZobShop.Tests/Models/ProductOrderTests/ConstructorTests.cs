using Moq;
using NUnit.Framework;
using ZobShop.Models;

namespace ZobShop.Tests.Models.ProductOrderTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [TestCase(1)]
        [TestCase(12)]
        public void TestConstructor_ShouldInitializeCorrectly(int quantity)
        {
            var mockedProduct = new Mock<Product>();

            var productOrder = new ProductOrder(mockedProduct.Object, quantity);

            Assert.IsNotNull(productOrder);
        }

        [TestCase(1)]
        [TestCase(12)]
        public void TestConstructor_ShouldSetProductCorrectly(int quantity)
        {
            var mockedProduct = new Mock<Product>();

            var productOrder = new ProductOrder(mockedProduct.Object, quantity);

            Assert.AreSame(mockedProduct.Object, productOrder.Product);
        }

        [TestCase(1)]
        [TestCase(12)]
        public void TestConstructor_ShouldSetQuantityCorrectly(int quantity)
        {
            var mockedProduct = new Mock<Product>();

            var productOrder = new ProductOrder(mockedProduct.Object, quantity);

            Assert.AreEqual(quantity, productOrder.Quantity);
        }
    }
}
