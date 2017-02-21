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
    public class ViewMyCheckoutTests
    {
        [TestCase("Pesho", "Pesho str", "123456789")]

        public void TestViewMyCheckout_ShouldCallCartFinishOrder(string name, string address, string phoneNumber)
        {
            var mockedView = new Mock<ICheckoutView>();
            mockedView.Setup(v => v.Model).Returns(new CheckoutViewModel());

            var mockedUserService = new Mock<IUserService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedCart = new Mock<IShoppingCart>();

            var checkoutPresenter = new CheckoutPresenter(mockedView.Object,
                mockedAuthenticationProvider.Object,
                mockedUserService.Object,
                mockedViewModelFactory.Object,
                mockedCart.Object);

            var args = new CheckoutEventArgs(name, address, phoneNumber);
            mockedView.Raise(v => v.MyCheckout += null, args);

            mockedCart.Verify(c => c.FinishOrder(name, address, phoneNumber), Times.Once);
        }

        [TestCase("Pesho", "Pesho str", "123456789")]

        public void TestViewMyCheckout_ShouldSetViewModelIsCheckoutSuccessfullToTrue(string name, string address, string phoneNumber)
        {
            var mockedView = new Mock<ICheckoutView>();
            mockedView.Setup(v => v.Model).Returns(new CheckoutViewModel());

            var mockedUserService = new Mock<IUserService>();
            var mockedAuthenticationProvider = new Mock<IAuthenticationProvider>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedCart = new Mock<IShoppingCart>();

            var checkoutPresenter = new CheckoutPresenter(mockedView.Object,
                mockedAuthenticationProvider.Object,
                mockedUserService.Object,
                mockedViewModelFactory.Object,
                mockedCart.Object);

            var args = new CheckoutEventArgs(name, address, phoneNumber);
            mockedView.Raise(v => v.MyCheckout += null, args);

            Assert.IsTrue(mockedView.Object.Model.IsCheckoutSuccessful);
        }
    }
}
