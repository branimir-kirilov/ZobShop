using System;
using Moq;
using NUnit.Framework;
using ZobShop.Authentication;
using ZobShop.Factories;
using ZobShop.ModelViewPresenter.Account.Register;

namespace ZobShop.Mvp.Tests.Account.RegisterPresenterTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassProviderNull_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<IRegisterView>();
            var mockedFactory = new Mock<IUserFactory>();

            Assert.Throws<ArgumentNullException>(
                () => new RegisterPresenter(mockedView.Object, null, mockedFactory.Object));
        }

        [Test]
        public void TestConstructor_PassFactoryNull_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<IRegisterView>();
            var mockedProvider = new Mock<IAuthenticationProvider>();

            Assert.Throws<ArgumentNullException>(
                () => new RegisterPresenter(mockedView.Object, mockedProvider.Object, null));
        }

        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldNotThrow()
        {
            var mockedView = new Mock<IRegisterView>();
            var mockedFactory = new Mock<IUserFactory>();
            var mockedProvider = new Mock<IAuthenticationProvider>();

            Assert.DoesNotThrow(
                () => new RegisterPresenter(mockedView.Object, mockedProvider.Object, mockedFactory.Object));
        }

        [Test]
        public void TestConstructor_PassEverythingCorrectly_ShouldInitializeCorrectly()
        {
            var mockedView = new Mock<IRegisterView>();
            var mockedProvider = new Mock<IAuthenticationProvider>();
            var mockedFactory = new Mock<IUserFactory>();

            var presenter = new RegisterPresenter(mockedView.Object, mockedProvider.Object, mockedFactory.Object);

            Assert.IsNotNull(presenter);
        }
    }
}
