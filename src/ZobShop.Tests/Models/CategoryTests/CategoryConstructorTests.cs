using NUnit.Framework;
using ZobShop.Models;

namespace ZobShop.Tests.Models.CategoryTests
{
    [TestFixture]
    public class CategoryConstructorTests
    {
        [Test]
        public void Constructor_ShouldBeInstanceOfCategory()
        {
            var category = new Category();

            Assert.IsInstanceOf<Category>(category);
        }

        [Test]
        public void Constructor_Should_InitializeCategory()
        {
            var category = new Category();

            Assert.IsNotNull(category);
        }

        [TestCase("Name")]
        [TestCase("AnotherName")]
        public void Constructor_Should_InitiliazeNameCorrectly(string name)
        {
            var category = new Category(name);

            Assert.AreSame(category.Name, name);
        }
    }
}
