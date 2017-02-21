using System;
using Moq;
using NUnit.Framework;
using ZobShop.Authentication;
using ZobShop.ModelViewPresenter;
using ZobShop.ModelViewPresenter.Product.Details;
using ZobShop.Services.Contracts;

namespace ZobShop.Mvp.Tests.Product.ProductDetailsPresenterTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassNullProductService_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<IProductDetailsView>();
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedRatingService = new Mock<IProductRatingService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            Assert.Throws<ArgumentNullException>(() => new ProductDetailsPresenter(mockedView.Object, null, mockedFactory.Object, mockedRatingService.Object, mockedAuthenticationProvider.Object));
        }

        [Test]
        public void TestConstructor_PassNullFactory_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<IProductDetailsView>();
            var mockedProductService = new Mock<IProductService>();
            var mockedRatingService = new Mock<IProductRatingService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            Assert.Throws<ArgumentNullException>(() => new ProductDetailsPresenter(mockedView.Object, mockedProductService.Object, null, mockedRatingService.Object, mockedAuthenticationProvider.Object));
        }

        [Test]
        public void TestConstructor_PassNullRatingService_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<IProductDetailsView>();
            var mockedProductService = new Mock<IProductService>();
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            Assert.Throws<ArgumentNullException>(() => new ProductDetailsPresenter(mockedView.Object, mockedProductService.Object, mockedFactory.Object, null, mockedAuthenticationProvider.Object));
        }

        [Test]
        public void TestConstructor_PassNullAuthenticationProvider_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<IProductDetailsView>();
            var mockedProductService = new Mock<IProductService>();
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedProductRatingService = new Mock<IProductRatingService>();

            Assert.Throws<ArgumentNullException>(() => new ProductDetailsPresenter(mockedView.Object, mockedProductService.Object, mockedFactory.Object, mockedProductRatingService.Object, null));
        }

        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldNotThrow()
        {
            var mockedView = new Mock<IProductDetailsView>();
            var mockedProductService = new Mock<IProductService>();
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedProductRatingService = new Mock<IProductRatingService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            Assert.DoesNotThrow(() => new ProductDetailsPresenter(mockedView.Object, mockedProductService.Object, mockedFactory.Object, mockedProductRatingService.Object, mockedAuthenticationProvider.Object));
        }


        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldInitializeCorrectly()
        {
            var mockedView = new Mock<IProductDetailsView>();
            var mockedProductService = new Mock<IProductService>();
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedProductRatingService = new Mock<IProductRatingService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();

            var presenter = new ProductDetailsPresenter(mockedView.Object, mockedProductService.Object, mockedFactory.Object, mockedProductRatingService.Object, mockedAuthenticationProvider.Object);
            
            Assert.IsNotNull(presenter);
        }
    }
}
