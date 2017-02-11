using Moq;
using NUnit.Framework;
using ZobShop.Models;

namespace ZobShop.Tests.Models.ProductRatingTests
{
    [TestFixture]
    public class ProductRatingConstructorTests
    {
        [Test]
        public void Constructor_ShouldBeInstanceOfProductRating()
        {
            var rating = new ProductRating();

            Assert.IsInstanceOf<ProductRating>(rating);
        }

        [Test]
        public void Constructor_Should_InitializeProductRatingCorrectly()
        {
            var productRating = new ProductRating();

            Assert.IsNotNull(productRating);
        }

        [TestCase(1, "test")]
        [TestCase(2, "tests")]
        [TestCase(123, "test content")]
        public void Constructor_ShouldSetRatingCorrectly(int rating, string content)
        {
            var mockedProduct = new Mock<Product>();
            var mockedUser = new Mock<User>();

            var productRating = new ProductRating(rating, content, mockedProduct.Object, mockedUser.Object);

            Assert.AreEqual(productRating.Rating, rating);
        }

        [TestCase(1, "test")]
        [TestCase(2, "tests")]
        [TestCase(123, "test content")]
        public void Constructor_ShouldSetContentCorrectly(int rating, string content)
        {
            var mockedProduct = new Mock<Product>();
            var mockedUser = new Mock<User>();

            var productRating = new ProductRating(rating, content, mockedProduct.Object, mockedUser.Object);

            Assert.AreEqual(productRating.Content, content);
        }

        [TestCase(1, "test")]
        [TestCase(2, "tests")]
        [TestCase(123, "test content")]
        public void Constructor_ShouldSetProductCorrectly(int rating, string content)
        {
            var mockedProduct = new Mock<Product>();
            var mockedUser = new Mock<User>();

            var productRating = new ProductRating(rating, content, mockedProduct.Object, mockedUser.Object);

            Assert.AreEqual(productRating.Product, mockedProduct.Object);
        }

        [TestCase(1, "test")]
        [TestCase(2, "tests")]
        [TestCase(123, "test content")]
        public void Constructor_ShouldSetAuthorContentCorrectly(int rating, string content)
        {
            var mockedProduct = new Mock<Product>();
            var mockedUser = new Mock<User>();

            var productRating = new ProductRating(rating, content, mockedProduct.Object, mockedUser.Object);

            Assert.AreEqual(productRating.Author, mockedUser.Object);
        }
    }
}
