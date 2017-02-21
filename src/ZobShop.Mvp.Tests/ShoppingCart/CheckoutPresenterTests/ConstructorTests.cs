using System;
using Moq;
using NUnit.Framework;
using ZobShop.Authentication;
using ZobShop.ModelViewPresenter;
using ZobShop.ModelViewPresenter.ShoppingCart.Checkout;
using ZobShop.Orders.Contracts;
using ZobShop.Services.Contracts;

namespace ZobShop.Mvp.Tests.ShoppingCart.CheckoutPresenterTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassNullAuthenticationProvider_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<ICheckoutView>();
            var mockedUserService = new Mock<IUserService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedCart = new Mock<IShoppingCart>();

            Assert.Throws<ArgumentNullException>(() =>
            new CheckoutPresenter(mockedView.Object, null, mockedUserService.Object, mockedViewModelFactory.Object, mockedCart.Object));
        }

        [Test]
        public void TestConstructor_PassNullUserService_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<ICheckoutView>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedCart = new Mock<IShoppingCart>();

            Assert.Throws<ArgumentNullException>(() =>
            new CheckoutPresenter(mockedView.Object, mockedAuthenticationProvider.Object, null, mockedViewModelFactory.Object, mockedCart.Object));
        }

        [Test]
        public void TestConstructor_PassNullViewModelFactory_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<ICheckoutView>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCart = new Mock<IShoppingCart>();

            Assert.Throws<ArgumentNullException>(() =>
            new CheckoutPresenter(mockedView.Object, mockedAuthenticationProvider.Object, mockedUserService.Object, null, mockedCart.Object));
        }

        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldNotThrow()
        {
            var mockedView = new Mock<ICheckoutView>();
            var mockedUserService = new Mock<IUserService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedCart = new Mock<IShoppingCart>();

            Assert.DoesNotThrow(() =>
            new CheckoutPresenter(mockedView.Object,
            mockedAuthenticationProvider.Object,
            mockedUserService.Object,
            mockedViewModelFactory.Object,
            mockedCart.Object));
        }

        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldInitializeCorrectly()
        {
            var mockedView = new Mock<ICheckoutView>();
            var mockedUserService = new Mock<IUserService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedCart = new Mock<IShoppingCart>();

            var checkoutPresenter = new CheckoutPresenter(mockedView.Object,
                mockedAuthenticationProvider.Object,
                mockedUserService.Object,
                mockedViewModelFactory.Object,
                mockedCart.Object);

            Assert.IsInstanceOf<CheckoutPresenter>(checkoutPresenter);
        }

        [Test]
        public void TestConstructor_PassEverythingCorrectly_NotBeNull()
        {
            var mockedView = new Mock<ICheckoutView>();
            var mockedUserService = new Mock<IUserService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedCart = new Mock<IShoppingCart>();

            var checkoutPresenter =
                new CheckoutPresenter(mockedView.Object,
                mockedAuthenticationProvider.Object, 
                mockedUserService.Object,
                mockedViewModelFactory.Object,
                mockedCart.Object);

            Assert.IsNotNull(checkoutPresenter);
        }
    }
}
