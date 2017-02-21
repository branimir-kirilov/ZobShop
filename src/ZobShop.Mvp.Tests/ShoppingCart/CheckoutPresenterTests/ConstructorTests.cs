using System;
using Moq;
using NUnit.Framework;
using ZobShop.Authentication;
using ZobShop.ModelViewPresenter;
using ZobShop.ModelViewPresenter.ShoppingCart.Checkout;
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

            Assert.Throws<ArgumentNullException>(() => new CheckoutPresenter(mockedView.Object, null, mockedUserService.Object, mockedViewModelFactory.Object));
        }

        [Test]
        public void TestConstructor_PassNullUserService_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<ICheckoutView>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            Assert.Throws<ArgumentNullException>(() => new CheckoutPresenter(mockedView.Object, mockedAuthenticationProvider.Object, null, mockedViewModelFactory.Object));
        }

        [Test]
        public void TestConstructor_PassNullViewModelFactory_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<ICheckoutView>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedUserService = new Mock<IUserService>();

            Assert.Throws<ArgumentNullException>(() => new CheckoutPresenter(mockedView.Object, mockedAuthenticationProvider.Object, mockedUserService.Object, null));
        }
    }
}
