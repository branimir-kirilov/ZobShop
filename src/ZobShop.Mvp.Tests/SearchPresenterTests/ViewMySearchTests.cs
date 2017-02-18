using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using ZobShop.Models;
using ZobShop.ModelViewPresenter;
using ZobShop.ModelViewPresenter.Product.Details;
using ZobShop.ModelViewPresenter.Product.List;
using ZobShop.ModelViewPresenter.Search;
using ZobShop.Services.Contracts;

namespace ZobShop.Mvp.Tests.SearchPresenterTests
{
    [TestFixture]
    public class ViewMySearchTests
    {
        [TestCase("query")]
        [TestCase("searchquery")]
        [TestCase("me search this")]
        public void TestViewMySearch_ShouldCallServiceSearchProductsCorrectly(string searchParam)
        {
            var mockedView = new Mock<ISearchView>();
            mockedView.Setup(v => v.Model).Returns(new ProductListViewModel());

            var mockedService = new Mock<IProductService>();

            var mockedFactory = new Mock<IViewModelFactory>();

            var presenter = new SearchPresenter(mockedView.Object, mockedService.Object, mockedFactory.Object);

            var args = new SearchEventArgs(searchParam);
            mockedView.Raise(v => v.MySearch += null, args);

            mockedService.Verify(s => s.SearchProducts(searchParam), Times.Once);
        }

        [TestCase("query")]
        [TestCase("searchquery")]
        [TestCase("me search this")]
        public void TestViewMySearch_ShouldSetViewModelProductsCorrectly(string searchParam)
        {
            var mockedView = new Mock<ISearchView>();
            mockedView.Setup(v => v.Model).Returns(new ProductListViewModel());

            var category = new Category();
            var product = new Product { Category = category };

            var mockedService = new Mock<IProductService>();
            mockedService.Setup(s => s.SearchProducts(It.IsAny<string>())).Returns(new List<Product> { product });

            var productDetailsViewModel = new ProductDetailsViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateProductDetailsViewModel(It.IsAny<int>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<double>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(productDetailsViewModel);

            var presenter = new SearchPresenter(mockedView.Object, mockedService.Object, mockedFactory.Object);

            var args = new SearchEventArgs(searchParam);
            mockedView.Raise(v => v.MySearch += null, args);

            var expected = new List<ProductDetailsViewModel> { productDetailsViewModel };

            CollectionAssert.AreEqual(expected, mockedView.Object.Model.Products);
        }
    }
}
