using Moq;
using NUnit.Framework;
using ZobShop.ModelViewPresenter.Product.Create;
using ZobShop.Services.Contracts;

namespace ZobShop.Mvp.Tests.Product.CreateProductPresenterTests
{
    [TestFixture]
    public class OnCreateProductTests
    {
        [TestCase("TestProduct", "TestCategoryName", 10, 5.00, 2.00, "TestMaker", ".jpg")]
        public void TestOnCreateProduct_ShouldCallServiceCreateProductCorrectly(string name,
            string categoryName,
            int quantity,
            decimal price,
            double volume,
            string maker,
            string imageMimeType)
        {
            var buffer = new byte[2];

            var mockedView = new Mock<ICreateProductView>();
            mockedView.Setup(v => v.Model).Returns(new CreateProductViewModel());

            var mockedService = new Mock<IProductService>();
            mockedService.Setup(
                    s => s.CreateProduct(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<decimal>(),
                        It.IsAny<double>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(new Models.Product());

            var presenter = new CreateProductPresenter(mockedView.Object, mockedService.Object);

            var args = new CreateProductEventArgs(name, categoryName, quantity, price, volume, maker, imageMimeType, buffer);
            mockedView.Raise(v => v.MyCreateProduct += null, args);

            mockedService.Verify(s => s.CreateProduct(name, categoryName, quantity, price, volume, maker, imageMimeType, buffer),
                Times.Once);
        }

        [TestCase("TestProduct", "TestCategoryName", 10, 5.00, 2.00, "TestMaker", ".jpg", 1)]
        [TestCase("TestProduct", "TestCategoryName", 10, 5.00, 2.00, "TestMaker", ".jpg", 13)]
        public void TestOnCreateProduct_ShouldSetViewModelIdCorrectly(string name,
            string categoryName,
            int quantity,
            decimal price,
            double volume,
            string maker,
            string imageMimeType,
            int id)
        {
            var buffer = new byte[2];

            var mockedView = new Mock<ICreateProductView>();
            mockedView.Setup(v => v.Model).Returns(new CreateProductViewModel());

            var product = new Models.Product { ProductId = id };

            var mockedService = new Mock<IProductService>();
            mockedService.Setup(
                    s => s.CreateProduct(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<decimal>(),
                        It.IsAny<double>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(product);

            var presenter = new CreateProductPresenter(mockedView.Object, mockedService.Object);

            var args = new CreateProductEventArgs(name, categoryName, quantity, price, volume, maker, imageMimeType, buffer);
            mockedView.Raise(v => v.MyCreateProduct += null, args);

            Assert.AreEqual(id, mockedView.Object.Model.Id);
        }
    }
}
