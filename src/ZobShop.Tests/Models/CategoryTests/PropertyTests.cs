using System.Collections.Generic;
using NUnit.Framework;
using ZobShop.Models;

namespace ZobShop.Tests.Models.CategoryTests
{
    [TestFixture]
    public class PropertyTests
    {
        [Test]
        public void TestProductProperty_ShouldWorkCorrectly()
        {
            var category = new Category();
            var products = new List<Product>();

            category.Products = products;

            Assert.AreSame(products, category.Products);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(452)]
        public void TestCategoryIdProperty_ShouldWorkCorrectly(int id)
        {
            var category = new Category();
            category.CategoryId = id;

            Assert.AreEqual(id, category.CategoryId);
        }
    }
}
