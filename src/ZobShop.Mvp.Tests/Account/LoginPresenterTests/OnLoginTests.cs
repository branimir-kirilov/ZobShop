using Microsoft.AspNet.Identity.Owin;
using Moq;
using NUnit.Framework;
using ZobShop.Authentication;
using ZobShop.Authentication.Contracts;
using ZobShop.ModelViewPresenter.Account.Login;

namespace ZobShop.Mvp.Tests.Account.LoginPresenterTests
{
    [TestFixture]
    public class OnLoginTests
    {
        [TestCase("pesho@pesho.com", "abc123", true, SignInStatus.Failure)]
        [TestCase("pesho@pesho.com", "abc123", false, SignInStatus.RequiresVerification)]
        [TestCase("pesho@pesho.com", "abc123", false, SignInStatus.LockedOut)]
        [TestCase("pesho@pesho.com", "abc123", true, SignInStatus.Success)]
        public void TestOnLogin_ShouldCallProviderGetSignInManager(string email, string password, bool rememberMe, SignInStatus status)
        {
            var mockedView = new Mock<ILoginView>();
            mockedView.Setup(v => v.Model).Returns(new LoginViewModel());

            var mockedManager = new Mock<ISignInManager>();
            mockedManager.Setup(m => m.SignInWithPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(status);

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.GetSignInManager()).Returns(mockedManager.Object);

            var presenter = new LoginPresenter(mockedView.Object, mockedProvider.Object);

            var args = new LoginEventArgs(email, password, rememberMe);
            mockedView.Raise(v => v.MyLogin += null, args);

            mockedProvider.Verify(p => p.GetSignInManager(), Times.Once);
        }

        [TestCase("pesho@pesho.com", "abc123", true, SignInStatus.Failure)]
        [TestCase("pesho@pesho.com", "abc123", false, SignInStatus.RequiresVerification)]
        [TestCase("pesho@pesho.com", "abc123", false, SignInStatus.LockedOut)]
        [TestCase("pesho@pesho.com", "abc123", true, SignInStatus.Success)]
        public void TestOnLogin_ShouldSetCorrectSignInStatusToViewModel(string email, string password, bool rememberMe, SignInStatus status)
        {
            var mockedView = new Mock<ILoginView>();
            mockedView.Setup(v => v.Model).Returns(new LoginViewModel());

            var mockedManager = new Mock<ISignInManager>();
            mockedManager.Setup(m => m.SignInWithPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(status);

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.GetSignInManager()).Returns(mockedManager.Object);

            var presenter = new LoginPresenter(mockedView.Object, mockedProvider.Object);

            var args = new LoginEventArgs(email, password, rememberMe);
            mockedView.Raise(v => v.MyLogin += null, args);

            Assert.AreEqual(status, mockedView.Object.Model.SignInStatus);
        }
    }
}
