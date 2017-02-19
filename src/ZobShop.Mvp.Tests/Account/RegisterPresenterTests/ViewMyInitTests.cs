using System;
using Moq;
using NUnit.Framework;
using ZobShop.Authentication;
using ZobShop.Factories;
using ZobShop.ModelViewPresenter.Account.Login;
using ZobShop.ModelViewPresenter.Account.Register;

namespace ZobShop.Mvp.Tests.Account.RegisterPresenterTests
{
    [TestFixture]
    public class ViewMyInitTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void TestViewMyInit_ShouldCallProviderIsAuthenticated(bool isAuthenticated)
        {
            var mockedView = new Mock<IRegisterView>();
            mockedView.Setup(v => v.Model).Returns(new RegisterViewModel());

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.IsAuthenticated).Returns(isAuthenticated);
            var mockedFactory = new Mock<IUserFactory>();

            var presenter = new RegisterPresenter(mockedView.Object, mockedProvider.Object, mockedFactory.Object);

            mockedView.Raise(v => v.MyInit += null, EventArgs.Empty);

            mockedProvider.Verify(p => p.IsAuthenticated, Times.Once);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void TestViewMyInit_ShouldSetViewModelIsAuthenticatedCorrectly(bool isAuthenticated)
        {
            var mockedView = new Mock<IRegisterView>();
            mockedView.Setup(v => v.Model).Returns(new RegisterViewModel());

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.IsAuthenticated).Returns(isAuthenticated);
            var mockedFactory = new Mock<IUserFactory>();

            var presenter = new RegisterPresenter(mockedView.Object, mockedProvider.Object, mockedFactory.Object);

            mockedView.Raise(v => v.MyInit += null, EventArgs.Empty);

            Assert.AreEqual(isAuthenticated, mockedView.Object.Model.IsAuthenticated);
        }
    }
}
