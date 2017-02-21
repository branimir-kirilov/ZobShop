using System;
using Moq;
using NUnit.Framework;
using ZobShop.Authentication;
using ZobShop.Models;
using ZobShop.ModelViewPresenter;
using ZobShop.ModelViewPresenter.ShoppingCart.Checkout;
using ZobShop.Orders.Contracts;
using ZobShop.Services.Contracts;

namespace ZobShop.Mvp.Tests.ShoppingCart.CheckoutPresenterTests
{
    [TestFixture]
    public class ViewMyInitTests
    {
        [TestCase("Id1")]
        [TestCase("Id2-12-423-sad")]
        public void TestViewMyInit_ShouldCallCreateCheckoutViewModel(string id)
        {
            var mockedView = new Mock<ICheckoutView>();
            mockedView.Setup(v => v.Model).Returns(new CheckoutViewModel());

            var user = new User() { Id = id };

            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(u => u.GetById(It.IsAny<string>())).Returns(user);

            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            mockedAuthenticationProvider.Setup(p => p.CurrentUserId).Returns(id);

            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(f => f.CreateCheckoutViewModel(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new CheckoutViewModel());

            var mockedCart = new Mock<IShoppingCart>();

            var checkoutPresenter =
                new CheckoutPresenter(mockedView.Object, mockedAuthenticationProvider.Object, mockedUserService.Object, mockedViewModelFactory.Object, mockedCart.Object);

            mockedView.Raise(v => v.MyInit += null, EventArgs.Empty);

            mockedViewModelFactory.Verify(f => f.CreateCheckoutViewModel(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
