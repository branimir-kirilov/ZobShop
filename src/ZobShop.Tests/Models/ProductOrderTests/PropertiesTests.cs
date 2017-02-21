using Moq;
using NUnit.Framework;
using ZobShop.Models;

namespace ZobShop.Tests.Models.ProductOrderTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [TestCase(1)]
        [TestCase(12)]
        public void TestProductOrderId_ShouldWorkCorrectly(int id)
        {
            var mockedProduct = new Mock<Product>();

            var productOrder = new ProductOrder(mockedProduct.Object, 0);
            productOrder.ProductOrderId = id;

            Assert.AreEqual(id, productOrder.ProductOrderId);
        }

        [TestCase(1)]
        [TestCase(12)]
        public void TestProductId_ShouldWorkCorrectly(int id)
        {
            var mockedProduct = new Mock<Product>();

            var productOrder = new ProductOrder(mockedProduct.Object, 0);
            productOrder.ProductId = id;

            Assert.AreEqual(id, productOrder.ProductId);
        }
    }
}
