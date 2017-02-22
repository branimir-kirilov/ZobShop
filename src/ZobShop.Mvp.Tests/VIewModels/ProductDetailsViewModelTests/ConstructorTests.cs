using NUnit.Framework;
using ZobShop.ModelViewPresenter.Product.Details;

namespace ZobShop.Mvp.Tests.VIewModels.ProductDetailsViewModelTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [TestCase(1, "TestProduct", "Zob", 10, 5.00, 2.00, "TestMaker", ".jpg")]
        public void Constructor_Should_SetNameCorrectly(int id,
            string name,
           string category,
           int quantity,
           decimal price,
           double volume,
           string maker,
           string imageMimeType)
        {
            var buffer = new byte[2];

            var product = new ProductDetailsViewModel(id, name, category, price, volume, maker, imageMimeType, buffer);

            Assert.AreEqual(name, product.Name);
        }

        [TestCase(1, "TestProduct", "Zob", 10, 5.00, 2.00, "TestMaker", ".jpg")]
        public void Constructor_Should_SetImageBufferCorrectly(int id,
            string name,
           string category,
           int quantity,
           decimal price,
           double volume,
           string maker,
           string imageMimeType)
        {
            var buffer = new byte[2];

            var product = new ProductDetailsViewModel(id, name, category, price, volume, maker, imageMimeType, buffer);

            Assert.AreEqual(buffer, product.ImageBuffer);
        }

        [TestCase(1, "TestProduct", "Zob", 10, 5.00, 2.00, "TestMaker", ".jpg")]
        public void Constructor_Should_SetImageMimeTypeCorrectly(int id,
            string name,
           string category,
           int quantity,
           decimal price,
           double volume,
           string maker,
           string imageMimeType)
        {
            var buffer = new byte[2];

            var product = new ProductDetailsViewModel(id, name, category, price, volume, maker, imageMimeType, buffer);

            Assert.AreEqual(imageMimeType, product.ImageMimeType);
        }

        [TestCase(1, "TestProduct", "Zob", 10, 5.00, 2.00, "TestMaker", ".jpg")]
        public void Constructor_Should_SetMakerCorrectly(int id,
            string name,
           string category,
           int quantity,
           decimal price,
           double volume,
           string maker,
           string imageMimeType)
        {
            var buffer = new byte[2];

            var product = new ProductDetailsViewModel(id, name, category, price, volume, maker, imageMimeType, buffer);

            Assert.AreEqual(maker, product.Maker);
        }

        [TestCase(1, "TestProduct", "Zob", 10, 5.00, 2.00, "TestMaker", ".jpg")]
        public void Constructor_Should_SetPriceCorrectly(int id,
            string name,
           string category,
           int quantity,
           decimal price,
           double volume,
           string maker,
           string imageMimeType)
        {
            var buffer = new byte[2];

            var product = new ProductDetailsViewModel(id, name, category, price, volume, maker, imageMimeType, buffer);

            Assert.AreEqual(price, product.Price);
        }

        [TestCase(1, "TestProduct", "Zob", 10, 5.00, 2.00, "TestMaker", ".jpg")]
        public void Constructor_Should_SetVolumeCorrectly(int id,
            string name,
           string category,
           int quantity,
           decimal price,
           double volume,
           string maker,
           string imageMimeType)
        {
            var buffer = new byte[2];

            var product = new ProductDetailsViewModel(id, name, category, price, volume, maker, imageMimeType, buffer);

            Assert.AreEqual(volume, product.Volume);
        }
    }
}
