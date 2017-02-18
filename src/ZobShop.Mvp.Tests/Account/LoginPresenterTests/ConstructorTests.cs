using System;
using Moq;
using NUnit.Framework;
using ZobShop.Authentication;
using ZobShop.ModelViewPresenter.Account.Login;

namespace ZobShop.Mvp.Tests.Account.LoginPresenterTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassProviderNull_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<ILoginView>();

            Assert.Throws<ArgumentNullException>(() => new LoginPresenter(mockedView.Object, null));
        }


        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldNotThrow()
        {
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedView = new Mock<ILoginView>();

            Assert.DoesNotThrow(() => new LoginPresenter(mockedView.Object, mockedProvider.Object));
        }

        [Test]
        public void TestConstructor_ShouldInitializeCorrectly()
        {
            var mockedView = new Mock<ILoginView>();
            var mockedProvider = new Mock<IAuthenticationProvider>();

            var presenter = new LoginPresenter(mockedView.Object, mockedProvider.Object);

            Assert.IsNotNull(presenter);
        }
    }
}
