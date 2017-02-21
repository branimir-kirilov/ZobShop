using Moq;
using NUnit.Framework;
using ZobShop.Authentication;
using ZobShop.Models;
using ZobShop.ModelViewPresenter;
using ZobShop.ModelViewPresenter.Product.Details;
using ZobShop.Services.Contracts;

namespace ZobShop.Mvp.Tests.Product.ProductDetailsPresenterTests
{
    [TestFixture]
    public class ViewMyProductDetailsTests
    {
        [TestCase(1)]
        public void TestViewMyProductDetails_ShouldCallServiceGetById(int id)
        {
            var mockedView = new Mock<IProductDetailsView>();
            mockedView.Setup(v => v.Model).Returns(new ProductDetailsViewModel());

            var mockedProvider = new Mock<IAuthenticationProvider>();

            var mockedService = new Mock<IProductRatingService>();

            var mockedProductService = new Mock<IProductService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var presenter = new ProductDetailsPresenter(mockedView.Object, mockedProductService.Object, mockedFactory.Object, mockedService.Object, mockedProvider.Object);

            var args = new ProductDetailsEventArgs(id);
            mockedView.Raise(v => v.MyProductDetails += null, args);

            mockedProductService.Verify(s => s.GetById(id), Times.Once);
        }

        [TestCase(1)]
        public void TestViewMyProductDetails_ServiceReturnsNull_ShouldNotCallFactoryCreateProductDetailsViewModel(int id)
        {
            var mockedView = new Mock<IProductDetailsView>();
            mockedView.Setup(v => v.Model).Returns(new ProductDetailsViewModel());

            var mockedProvider = new Mock<IAuthenticationProvider>();

            var mockedService = new Mock<IProductRatingService>();

            var mockedProductService = new Mock<IProductService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var presenter = new ProductDetailsPresenter(mockedView.Object, mockedProductService.Object, mockedFactory.Object, mockedService.Object, mockedProvider.Object);

            var args = new ProductDetailsEventArgs(id);
            mockedView.Raise(v => v.MyProductDetails += null, args);

            mockedFactory.Verify(f => f.CreateProductDetailsViewModel(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<double>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<byte[]>()), Times.Never());
        }

        [TestCase(1)]
        public void TestViewMyProductDetails_ServiceReturnsProduct_ShouldCallFactoryCreateProductDetailsViewModel(int id)
        {
            var mockedView = new Mock<IProductDetailsView>();
            mockedView.Setup(v => v.Model).Returns(new ProductDetailsViewModel());

            var mockedProvider = new Mock<IAuthenticationProvider>();

            var category = new Category();
            var product = new Models.Product { Category = category };

            var mockedService = new Mock<IProductRatingService>();

            var mockedProductService = new Mock<IProductService>();
            mockedProductService.Setup(s => s.GetById(It.IsAny<int>()))
                .Returns(product);

            var mockedFactory = new Mock<IViewModelFactory>();

            var presenter = new ProductDetailsPresenter(mockedView.Object, mockedProductService.Object, mockedFactory.Object, mockedService.Object, mockedProvider.Object);

            var args = new ProductDetailsEventArgs(id);
            mockedView.Raise(v => v.MyProductDetails += null, args);

            mockedFactory.Verify(f => f.CreateProductDetailsViewModel(product.ProductId, product.Name, category.Name,
                product.Price,
                product.Volume,
                product.Maker,
                product.ImageMimeType,
                product.ImageBuffer), Times.Once);
        }
    }
}
