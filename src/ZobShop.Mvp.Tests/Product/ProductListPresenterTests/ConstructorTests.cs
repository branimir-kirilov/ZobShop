using System;
using Moq;
using NUnit.Framework;
using ZobShop.ModelViewPresenter;
using ZobShop.ModelViewPresenter.Administration.ProductsList;
using ZobShop.ModelViewPresenter.Product.List;
using ZobShop.Services.Contracts;

namespace ZobShop.Mvp.Tests.Product.ProductListPresenterTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassProductServiceNull_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<IProductListView>();
            var mockedFactory = new Mock<IViewModelFactory>();

            Assert.Throws<ArgumentNullException>(() =>
            new ProductListPresenter(mockedView.Object, null, mockedFactory.Object));
        }

        [Test]
        public void TestConstructor_PassFactoryNull_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<IProductListView>();
            var mockedService = new Mock<IProductService>();

            Assert.Throws<ArgumentNullException>(() =>
            new ProductListPresenter(mockedView.Object, mockedService.Object, null));
        }


        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldInitializeCorrectly()
        {
            var mockedView = new Mock<IProductListView>();
            var mockedService = new Mock<IProductService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var presenter = new ProductListPresenter(mockedView.Object, mockedService.Object, mockedFactory.Object);

            Assert.IsNotNull(presenter);
        }
    }
}
