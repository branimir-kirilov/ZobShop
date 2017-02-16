using Moq;
using NUnit.Framework;
using ZobShop.ModelViewPresenter;
using ZobShop.ModelViewPresenter.Product.List;
using ZobShop.ModelViewPresenter.Search;
using ZobShop.Services.Contracts;

namespace ZobShop.Tests.Mvp.Search.SearchPresenterTests
{
    [TestFixture]
    public class ViewMySearchTests
    {
        [TestCase("search")]
        [TestCase("much")]
        public void TestViewMySearch_ShouldCallServiceSearchProductsCorrectly(string searchQuery)
        {
            var mockedModel = new Mock<ProductListViewModel>();

            var mockedView = new Mock<ISearchView>();
            mockedView.Setup(x => x.Model).Returns(mockedModel.Object);

            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedService = new Mock<IProductService>();

            var presenter = new SearchPresenter(mockedView.Object, mockedService.Object, mockedFactory.Object);

            var args = new SearchEventArgs(searchQuery);
            mockedView.Raise(x => x.MySearch += null, args);

            mockedService.Verify(x => x.SearchProducts(searchQuery), Times.Once);
        }
    }
}
