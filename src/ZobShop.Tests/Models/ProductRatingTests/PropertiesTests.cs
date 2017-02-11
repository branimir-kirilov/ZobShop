using NUnit.Framework;
using ZobShop.Models;

namespace ZobShop.Tests.Models.ProductRatingTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [TestCase("abcd")]
        [TestCase("a2g2-17")]
        public void TestAuthorId_ShouldWorkCorrectly(string authorId)
        {
            var productRating = new ProductRating();
            productRating.AuthorId = authorId;

            Assert.AreEqual(authorId, productRating.AuthorId);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(1496)]
        public void TestProductId_ShouldWorkCorrectly(int productId)
        {
            var productRating = new ProductRating();
            productRating.ProductId = productId;

            Assert.AreEqual(productId, productRating.ProductId);
        }

        [TestCase(1)]
        [TestCase(12)]
        [TestCase(1496)]
        public void TestProductRatingId_ShouldWorkCorrectly(int productRatingId)
        {
            var productRating = new ProductRating();
            productRating.ProductRatingId = productRatingId;

            Assert.AreEqual(productRatingId, productRating.ProductRatingId);
        }
    }
}
