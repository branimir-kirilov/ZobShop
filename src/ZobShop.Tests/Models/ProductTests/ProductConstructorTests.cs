using Moq;
using NUnit.Framework;
using ZobShop.Models;

namespace ZobShop.Tests.Models.ProductTests
{
    [TestFixture]
    public class ProductConstructorTests
    {
        [Test]
        public void Constructor_ShouldBeInstanceOfProduct()
        {
            var product = new Product();

            Assert.IsInstanceOf<Product>(product);
        }

        [Test]
        public void Constructor_Should_InitializeProduct()
        {
            var product = new Product();

            Assert.IsNotNull(product);
        }

        [TestCase("TestProduct", 10, 5.00, 2.00, "TestMaker", ".jpg")]
        public void Constructor_Should_SetNameCorrectly(string name,
            int quantity,
            decimal price,
            double volume,
            string maker,
            string imageMimeType)
        {
            var category = new Mock<Category>();

            var buffer = new byte[2];
            var product = new Product(name, category.Object, quantity, price, volume, maker, imageMimeType, buffer);

            Assert.AreEqual(product.Name, name);
        }

        [TestCase("TestProduct", 10, 5.00, 2.00, "TestMaker", ".jpg")]
        public void Constructor_Should_SetQuantityCorrectly(string name,
            int quantity,
            decimal price,
            double volume,
            string maker,
            string imageMimeType)
        {
            var category = new Mock<Category>();

            var buffer = new byte[2];
            var product = new Product(name, category.Object, quantity, price, volume, maker, imageMimeType, buffer);

            Assert.AreEqual(product.Name, name);
        }

        [TestCase("TestProduct", 10, 5.00, 2.00, "TestMaker", ".jpg")]
        public void Constructor_Should_SetPriceCorrectly(string name,
         int quantity,
            decimal price,
            double volume,
            string maker,
            string imageMimeType)
        {
            var category = new Mock<Category>();

            var buffer = new byte[2];
            var product = new Product(name, category.Object, quantity, price, volume, maker, imageMimeType, buffer);

            Assert.AreEqual(product.Name, name);
        }

        [TestCase("TestProduct", 10, 5.00, 2.00, "TestMaker", ".jpg")]
        public void Constructor_Should_SetVolumeCorrectly(string name,
          int quantity,
            decimal price,
            double volume,
            string maker,
            string imageMimeType)
        {
            var category = new Mock<Category>();

            var buffer = new byte[2];
            var product = new Product(name, category.Object, quantity, price, volume, maker, imageMimeType, buffer);

            Assert.AreEqual(product.Name, name);
        }

        [TestCase("TestProduct", 10, 5.00, 2.00, "TestMaker", ".jpg")]
        public void Constructor_Should_SetMakerProperly(string name,
          int quantity,
            decimal price,
            double volume,
            string maker,
            string imageMimeType)
        {
            var category = new Mock<Category>();

            var buffer = new byte[2];
            var product = new Product(name, category.Object, quantity, price, volume, maker, imageMimeType, buffer);

            Assert.AreEqual(product.Name, name);
        }

        [TestCase("TestProduct", 10, 5.00, 2.00, "TestMaker", ".jpg")]
        public void Constructor_Should_SetCategoryCorrectly(string name,
          int quantity,
            decimal price,
            double volume,
            string maker,
            string imageMimeType)
        {
            var category = new Mock<Category>();

            var buffer = new byte[2];
            var product = new Product(name, category.Object, quantity, price, volume, maker, imageMimeType, buffer);

            Assert.AreSame(product.Category, category.Object);
        }
    }
}
