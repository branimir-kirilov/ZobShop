using System;
using Moq;
using NUnit.Framework;
using ZobShop.ModelViewPresenter;
using ZobShop.ModelViewPresenter.Administration.ProductsList;
using ZobShop.Services.Contracts;

namespace ZobShop.Mvp.Tests.Administration.ProductsListPresenterTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassProductServiceNull_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<IProductsListView>();
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedCategoryService = new Mock<ICategoryService>();

            Assert.Throws<ArgumentNullException>(() =>
            new ProductsListPresenter(mockedView.Object, null, mockedFactory.Object, mockedCategoryService.Object));
        }

        [Test]
        public void TestConstructor_PassCategoryServiceNull_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<IProductsListView>();
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedService = new Mock<IProductService>();

            Assert.Throws<ArgumentNullException>(() =>
            new ProductsListPresenter(mockedView.Object, mockedService.Object, mockedFactory.Object, null));
        }

        [Test]
        public void TestConstructor_PassFactoryNull_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<IProductsListView>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedService = new Mock<IProductService>();

            Assert.Throws<ArgumentNullException>(() =>
            new ProductsListPresenter(mockedView.Object, mockedService.Object, null, mockedCategoryService.Object));
        }

        [Test]
        public void TestConstructor_ShouldInitializeCorrectly()
        {
            var mockedView = new Mock<IProductsListView>();
            var mockedFactory = new Mock<IViewModelFactory>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedService = new Mock<IProductService>();
            mockedService.Setup(s => s.GetById(It.IsAny<int>())).Returns(new Models.Product());

            var presenter =
                new ProductsListPresenter(mockedView.Object, mockedService.Object, mockedFactory.Object, mockedCategoryService.Object);

            Assert.IsNotNull(presenter);
        }
    }
}
