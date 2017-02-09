using NUnit.Framework;
using ZobShop.Models;

namespace ZobShop.Tests.Models
{
    [TestFixture]
    public class ReviewConstructorTests
    {
        [Test]
        public void Constructor_ShouldBeInstanceOfReview()
        {
            var review = new Review();

            Assert.IsInstanceOf<Review>(review);
        }

        [Test]
        public void Constructor_Should_InitializeReviewCorrectly()
        {
            var review = new Review();

            Assert.IsNotNull(review);
        }
    }
}
