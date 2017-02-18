using System;
using Moq;
using NUnit.Framework;
using ZobShop.ModelViewPresenter;
using ZobShop.ModelViewPresenter.ShoppingCart.Summary;
using ZobShop.Orders.Contracts;

namespace ZobShop.Mvp.Tests.ShoppingCart.CartSummaryPresenterTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassIShoppingCartNull_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<ICartSummaryView>();
            var mockedFactory = new Mock<IViewModelFactory>();

            Assert.Throws<ArgumentNullException>(() => new CartSummaryPresenter(mockedView.Object, null, mockedFactory.Object));
        }

        [Test]
        public void TestConstructor_PassFactoryNull_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<ICartSummaryView>();
            var mockedShoppingCart = new Mock<IShoppingCart>();

            Assert.Throws<ArgumentNullException>(() => new CartSummaryPresenter(mockedView.Object, mockedShoppingCart.Object, null));
        }

        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldNotThrow()
        {
            var mockedView = new Mock<ICartSummaryView>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedFactory = new Mock<IViewModelFactory>();

            Assert.DoesNotThrow((() => new CartSummaryPresenter(mockedView.Object, mockedShoppingCart.Object, mockedFactory.Object)));
        }


        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldInitializeCorrectly()
        {
            var mockedView = new Mock<ICartSummaryView>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var presenter = new CartSummaryPresenter(mockedView.Object, mockedShoppingCart.Object, mockedFactory.Object);

            Assert.IsNotNull(presenter);
        }
    }
}
