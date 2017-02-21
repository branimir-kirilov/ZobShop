using Moq;
using NUnit.Framework;
using ZobShop.Authentication;
using ZobShop.ModelViewPresenter;
using ZobShop.ModelViewPresenter.Product.Details;
using ZobShop.ModelViewPresenter.Product.Details.RateProduct;
using ZobShop.Services.Contracts;

namespace ZobShop.Mvp.Tests.Product.ProductDetailsPresenterTests
{
    [TestFixture]
    public class OnRatingTests
    {
        [TestCase(4, "SomeContent", 5, "UserId-1")]
        [TestCase(-2, "Content", 10, "UserId-2")]
        public void TestOnRatingProduct_ShouldCallRatingServiceCorrectly(
            int rating,
            string content,
            int productId,
            string userId)
        {
            var mockedView = new Mock<IProductDetailsView>();
            mockedView.Setup(v => v.Model).Returns(new ProductDetailsViewModel());

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(v => v.CurrentUserId).Returns(userId);

            var mockedService = new Mock<IProductRatingService>();
            mockedService.Setup(
                s =>
                    s.CreateProductRating(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>()))
                        .Returns(new Models.ProductRating());

            var mockedProductService = new Mock<IProductService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var presenter = new ProductDetailsPresenter(mockedView.Object, mockedProductService.Object, mockedFactory.Object, mockedService.Object, mockedProvider.Object);

            var args = new RateProductEventArgs(rating, content, productId);
            mockedView.Raise(v => v.RateProduct += null, args);

            mockedService.Verify(s => s.CreateProductRating(rating, content, productId, mockedProvider.Object.CurrentUserId),
                Times.Once);
        }
    }
}
