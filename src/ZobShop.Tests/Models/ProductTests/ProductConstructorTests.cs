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

        [TestCase("TestProduct", 10, 5.00, 2.00, "TestMaker")]
        public void Constructor_Should_SetNameCorrectly(string name,
            int quantity,
            decimal price,
            double volume,
            string maker)
        {
            var category = new Mock<Category>();

            var product = new Product(name, category.Object, quantity, price, volume, maker);

            Assert.AreEqual(product.Name, name);
        }

        [TestCase("TestProduct", 10, 5.00, 2.00, "TestMaker")]
        public void Constructor_Should_SetQuantityCorrectly(string name,
           int quantity,
           decimal price,
           double volume,
           string maker)
        {
            var category = new Mock<Category>();

            var product = new Product(name, category.Object, quantity, price, volume, maker);

            Assert.AreEqual(product.Name, name);
        }

        [TestCase("TestProduct", 10, 5.00, 2.00, "TestMaker")]
        public void Constructor_Should_SetPriceCorrectly(string name,
        int quantity,
        decimal price,
        double volume,
        string maker)
        {
            var category = new Mock<Category>();

            var product = new Product(name, category.Object, quantity, price, volume, maker);

            Assert.AreEqual(product.Name, name);
        }

        [TestCase("TestProduct", 10, 5.00, 2.00, "TestMaker")]
        public void Constructor_Should_SetVolumeCorrectly(string name,
          int quantity,
          decimal price,
          double volume,
          string maker)
        {
            var category = new Mock<Category>();

            var product = new Product(name, category.Object, quantity, price, volume, maker);

            Assert.AreEqual(product.Name, name);
        }

        [TestCase("TestProduct", 10, 5.00, 2.00, "TestMaker")]
        public void Constructor_Should_SetMakerProperly(string name,
          int quantity,
          decimal price,
          double volume,
          string maker)
        {
            var category = new Mock<Category>();

            var product = new Product(name, category.Object, quantity, price, volume, maker);

            Assert.AreEqual(product.Name, name);
        }

        [TestCase("TestProduct", 10, 5.00, 2.00, "TestMaker")]
        public void Constructor_Should_SetCategoryCorrectly(string name,
          int quantity,
          decimal price,
          double volume,
          string maker)
        {
            var category = new Mock<Category>();

            var product = new Product(name, category.Object, quantity, price, volume, maker);

            Assert.AreSame(product.Category, category.Object);
        }
    }
}
