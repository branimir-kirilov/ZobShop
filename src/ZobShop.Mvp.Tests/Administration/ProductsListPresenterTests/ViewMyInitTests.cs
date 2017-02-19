using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using ZobShop.Models;
using ZobShop.ModelViewPresenter;
using ZobShop.ModelViewPresenter.Administration.ProductsList;
using ZobShop.ModelViewPresenter.Product.Details;
using ZobShop.ModelViewPresenter.Product.List;
using ZobShop.Services.Contracts;

namespace ZobShop.Mvp.Tests.Administration.ProductsListPresenterTests
{
    [TestFixture]
    public class ViewMyInitTests
    {
        [Test]
        public void TestViewMyInit_ShouldCallServiceGetProducts()
        {
            var mockedView = new Mock<IProductsListView>();
            mockedView.Setup(v => v.Model).Returns(new ProductListViewModel());

            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedService = new Mock<IProductService>();

            var presenter =
                new ProductsListPresenter(mockedView.Object, mockedService.Object, mockedFactory.Object,
                    mockedCategoryService.Object);

            mockedView.Raise(v => v.MyInit += null, EventArgs.Empty);

            mockedService.Verify(s => s.GetProducts(), Times.Once);
        }

        [Test]
        public void TestViewMyInit_ShouldSetViewModelProducts()
        {
            var mockedView = new Mock<IProductsListView>();
            mockedView.Setup(v => v.Model).Returns(new ProductListViewModel());

            var viewModel = new ProductDetailsViewModel();

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateProductDetailsViewModel(It.IsAny<int>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<double>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(viewModel);

            var mockedCategoryService = new Mock<ICategoryService>();

            var category = new Category();
            var product = new Models.Product { Category = category };

            var productsResult = new List<Models.Product> { product };

            var mockedService = new Mock<IProductService>();
            mockedService.Setup(s => s.GetProducts()).Returns(productsResult);

            var presenter =
                new ProductsListPresenter(mockedView.Object, mockedService.Object, mockedFactory.Object, mockedCategoryService.Object);

            mockedView.Raise(v => v.MyInit += null, EventArgs.Empty);

            var expected = new List<ProductDetailsViewModel> { viewModel };

            CollectionAssert.AreEqual(expected, mockedView.Object.Model.Products);
        }
    }
}
