using System;
using Moq;
using NUnit.Framework;
using ZobShop.ModelViewPresenter;
using ZobShop.ModelViewPresenter.Search;
using ZobShop.Services.Contracts;

namespace ZobShop.Mvp.Tests.SearchPresenterTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassServiceNull_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<ISearchView>();
            var mockedFactory = new Mock<IViewModelFactory>();

            Assert.Throws<ArgumentNullException>(() => new SearchPresenter(mockedView.Object, null, mockedFactory.Object));
        }

        [Test]
        public void TestConstructor_PassFactoryNull_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<ISearchView>();
            var mockedService = new Mock<IProductService>();

            Assert.Throws<ArgumentNullException>(() => new SearchPresenter(mockedView.Object, mockedService.Object, null));
        }

        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldNotThrow()
        {
            var mockedView = new Mock<ISearchView>();
            var mockedService = new Mock<IProductService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            Assert.DoesNotThrow(() => new SearchPresenter(mockedView.Object, mockedService.Object, mockedFactory.Object));
        }

        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldInitializeCorrectly()
        {
            var mockedView = new Mock<ISearchView>();
            var mockedService = new Mock<IProductService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var presenter = new SearchPresenter(mockedView.Object, mockedService.Object, mockedFactory.Object);

            Assert.IsNotNull(presenter);
        }
    }
}
