using System.Collections.Generic;
using NUnit.Framework;
using ZobShop.Models;

namespace ZobShop.Tests.Models.ProductTests
{
    [TestFixture]
    public class PropertyTests
    {
        [TestCase(1)]
        [TestCase(1234)]
        public void TestCategoryId_ShouldWorkCorrectly(int id)
        {
            var product = new Product();
            product.CategoryId = id;

            Assert.AreEqual(id, product.CategoryId);
        }

        [TestCase("maker")]
        [TestCase("test")]
        public void TestMaker_ShouldWorkCorrectly(string maker)
        {
            var product = new Product();
            product.Maker = maker;

            Assert.AreEqual(maker, product.Maker);
        }

        [TestCase(1)]
        [TestCase(1234)]
        public void TestProductId_ShouldWorkCorrectly(int id)
        {
            var product = new Product();
            product.ProductId = id;

            Assert.AreEqual(id, product.ProductId);
        }

        [TestCase(1)]
        [TestCase(1234)]
        public void TestPrice_ShouldWorkCorrectly(decimal price)
        {
            var product = new Product();
            product.Price = price;

            Assert.AreEqual(price, product.Price);
        }

        [Test]
        public void TestProductRatings_ShouldWorkCorrectly()
        {
            var ratings = new List<ProductRating>();

            var product = new Product();
            product.ProductRatings = ratings;

            Assert.AreSame(ratings, product.ProductRatings);
        }

        [TestCase(1)]
        [TestCase(1234)]
        public void TestQuantity_ShouldWorkCorrectly(int quantity)
        {
            var product = new Product();
            product.Quantity = quantity;

            Assert.AreEqual(quantity, product.Quantity);
        }

        [Test]
        public void TestReviews_ShouldWorkCorrectly()
        {
            var reviews = new List<Review>();

            var product = new Product();
            product.Reviews = reviews;

            Assert.AreEqual(reviews, product.Reviews);
        }

        [TestCase(1)]
        [TestCase(1234)]
        public void TestVolume_ShouldWorkCorrectly(double volume)
        {
            var product = new Product();
            product.Volume = volume;

            Assert.AreEqual(volume, product.Volume);
        }

        [Test]
        public void TestImageBuffer_ShouldWorkCorrectly()
        {
            var buffer = new byte[2];

            var product = new Product();
            product.ImageBuffer = buffer;

            Assert.AreEqual(buffer, product.ImageBuffer);
        }

        [TestCase(".jpg")]
        [TestCase(".png")]
        public void TestImageMimeType_ShouldWorkCorrectly(string imageMimeType)
        {
            var product = new Product();
            product.ImageMimeType = imageMimeType;

            Assert.AreEqual(imageMimeType, product.ImageMimeType);
        }
    }
}
