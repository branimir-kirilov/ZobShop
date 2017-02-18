using System;
using Moq;
using NUnit.Framework;
using ZobShop.Authentication;
using ZobShop.ModelViewPresenter.Account.Login;

namespace ZobShop.Mvp.Tests.Account.LoginPresenterTests
{
    [TestFixture]
    public class ViewMyInitTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void TestViewMyInit_ShouldCallProviderIsAuthenticated(bool isAuthenticated)
        {
            var mockedView = new Mock<ILoginView>();
            mockedView.Setup(v => v.Model).Returns(new LoginViewModel());

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.IsAuthenticated).Returns(isAuthenticated);

            var presenter = new LoginPresenter(mockedView.Object, mockedProvider.Object);

            mockedView.Raise(v => v.MyInit += null, EventArgs.Empty);

            mockedProvider.Verify(p => p.IsAuthenticated, Times.Once);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void TestViewMyInit_ShouldSetViewModelIsAuthenticatedCorrectly(bool isAuthenticated)
        {
            var mockedView = new Mock<ILoginView>();
            mockedView.Setup(v => v.Model).Returns(new LoginViewModel());

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.IsAuthenticated).Returns(isAuthenticated);

            var presenter = new LoginPresenter(mockedView.Object, mockedProvider.Object);

            mockedView.Raise(v => v.MyInit += null, EventArgs.Empty);

            Assert.AreEqual(isAuthenticated, mockedView.Object.Model.IsAuthenticated);
        }
    }
}
