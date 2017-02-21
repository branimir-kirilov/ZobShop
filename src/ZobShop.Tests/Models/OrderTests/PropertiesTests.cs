using System.Collections.ObjectModel;
using NUnit.Framework;
using ZobShop.Models;

namespace ZobShop.Tests.Models.OrderTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void TestIsCompleted_ShouldWorkCorrectly(bool isCompleted)
        {
            var order = new Order { IsCompleted = isCompleted };

            Assert.AreEqual(isCompleted, order.IsCompleted);
        }

        [Test]
        public void TestProducts_ShouldWorkCorrectly()
        {
            var products = new Collection<ProductOrder>();

            var order = new Order { Products = products };

            CollectionAssert.AreEqual(products, order.Products);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(130)]
        public void TestOrderId_ShouldWorkCorrectly(int id)
        {
            var order = new Order { OrderId = id };

            Assert.AreEqual(id, order.OrderId);
        }
    }
}
