using NUnit.Framework;
using ZobShop.Models;

namespace ZobShop.Tests.Models
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
    }
}
