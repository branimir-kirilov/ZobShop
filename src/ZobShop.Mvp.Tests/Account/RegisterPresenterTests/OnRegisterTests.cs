using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using ZobShop.Authentication;
using ZobShop.Authentication.Contracts;
using ZobShop.Factories;
using ZobShop.Models;
using ZobShop.ModelViewPresenter.Account.Register;

namespace ZobShop.Mvp.Tests.Account.RegisterPresenterTests
{
    [TestFixture]
    public class OnRegisterTests
    {
        [TestCase("pesho@pesho.com", "123456", "Peter", "0881768356", "1 Peshova street")]
        public void TestViewMyInit_ShouldCallProviderGetUserManager(string email, string password, string name, string phone, string address)
        {
            var mockedView = new Mock<IRegisterView>();
            mockedView.Setup(v => v.Model).Returns(new RegisterViewModel());

            var mockedUserManager = new Mock<IUserManager>();
            mockedUserManager.Setup(m => m.CreateUser(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(new IdentityResult());

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.GetUserManager()).Returns(mockedUserManager.Object);

            var mockedFactory = new Mock<IUserFactory>();

            var presenter = new RegisterPresenter(mockedView.Object, mockedProvider.Object, mockedFactory.Object);

            var args = new RegisterEventArgs(email, password, name, phone, address);
            mockedView.Raise(v => v.MyRegister += null, args);

            mockedProvider.Verify(p => p.GetUserManager(), Times.Once);
        }

        [TestCase("pesho@pesho.com", "123456", "Peter", "0881768356", "1 Peshova street")]
        public void TestViewMyInit_ShouldCallFactoryCreateUser(string email, string password, string name, string phone, string address)
        {
            var mockedView = new Mock<IRegisterView>();
            mockedView.Setup(v => v.Model).Returns(new RegisterViewModel());

            var mockedUserManager = new Mock<IUserManager>();
            mockedUserManager.Setup(m => m.CreateUser(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(new IdentityResult());

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.GetUserManager()).Returns(mockedUserManager.Object);

            var mockedFactory = new Mock<IUserFactory>();

            var presenter = new RegisterPresenter(mockedView.Object, mockedProvider.Object, mockedFactory.Object);

            var args = new RegisterEventArgs(email, password, name, phone, address);
            mockedView.Raise(v => v.MyRegister += null, args);

            mockedFactory.Verify(f => f.CreateUser(email, email, name, phone, address), Times.Once);
        }

        [TestCase("pesho@pesho.com", "123456", "Peter", "0881768356", "1 Peshova street")]
        public void TestViewMyInit_ShouldCallManagerCreateUserCorrectly(string email, string password, string name, string phone, string address)
        {
            var mockedView = new Mock<IRegisterView>();
            mockedView.Setup(v => v.Model).Returns(new RegisterViewModel());

            var mockedUserManager = new Mock<IUserManager>();
            mockedUserManager.Setup(m => m.CreateUser(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(new IdentityResult());

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.GetUserManager()).Returns(mockedUserManager.Object);

            var user = new User();

            var mockedFactory = new Mock<IUserFactory>();
            mockedFactory.Setup(
                    f =>
                        f.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                            It.IsAny<string>()))
                .Returns(user);

            var presenter = new RegisterPresenter(mockedView.Object, mockedProvider.Object, mockedFactory.Object);

            var args = new RegisterEventArgs(email, password, name, phone, address);
            mockedView.Raise(v => v.MyRegister += null, args);

            mockedUserManager.Verify(m => m.CreateUser(user, password), Times.Once);
        }

        [TestCase("pesho@pesho.com", "123456", "Peter", "0881768356", "1 Peshova street", "User not created")]
        public void TestViewMyInit_ResultNotSucceeded_ShouldAddViewModelErrorMessage(string email,
            string password,
            string name,
            string phone,
            string address,
            string errorMessage)
        {
            var mockedView = new Mock<IRegisterView>();
            mockedView.Setup(v => v.Model).Returns(new RegisterViewModel());

            var errorMessages = new List<string> { errorMessage };

            var mockedUserManager = new Mock<IUserManager>();
            mockedUserManager.Setup(m => m.CreateUser(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(new IdentityResult(errorMessages));

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.GetUserManager()).Returns(mockedUserManager.Object);

            var user = new User();

            var mockedFactory = new Mock<IUserFactory>();
            mockedFactory.Setup(
                    f =>
                        f.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                            It.IsAny<string>()))
                .Returns(user);

            var presenter = new RegisterPresenter(mockedView.Object, mockedProvider.Object, mockedFactory.Object);

            var args = new RegisterEventArgs(email, password, name, phone, address);
            mockedView.Raise(v => v.MyRegister += null, args);

            Assert.AreEqual(errorMessage, mockedView.Object.Model.ErrorMessage);
        }


        [TestCase("pesho@pesho.com", "123456", "Peter", "0881768356", "1 Peshova street")]
        public void TestViewMyInit_ResultNotSucceeded_ShouldNotCallProviderGetSignInManager(string email,
            string password,
            string name,
            string phone,
            string address)
        {
            var mockedView = new Mock<IRegisterView>();
            mockedView.Setup(v => v.Model).Returns(new RegisterViewModel());

            var mockedUserManager = new Mock<IUserManager>();
            mockedUserManager.Setup(m => m.CreateUser(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(new IdentityResult());

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.GetUserManager()).Returns(mockedUserManager.Object);

            var user = new User();

            var mockedFactory = new Mock<IUserFactory>();
            mockedFactory.Setup(
                    f =>
                        f.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                            It.IsAny<string>()))
                .Returns(user);

            var presenter = new RegisterPresenter(mockedView.Object, mockedProvider.Object, mockedFactory.Object);

            var args = new RegisterEventArgs(email, password, name, phone, address);
            mockedView.Raise(v => v.MyRegister += null, args);

            mockedProvider.Verify(p => p.GetSignInManager(), Times.Never);
        }

        [TestCase("pesho@pesho.com", "123456", "Peter", "0881768356", "1 Peshova street")]
        public void TestViewMyInit_ResultSucceededTrue_ShouldCallProviderGetSignInManager(string email, string password, string name, string phone, string address)
        {
            var mockedView = new Mock<IRegisterView>();
            mockedView.Setup(v => v.Model).Returns(new RegisterViewModel());

            var mockedUserManager = new Mock<IUserManager>();
            mockedUserManager.Setup(m => m.CreateUser(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(IdentityResult.Success);

            var mockedSignInManager = new Mock<ISignInManager>();

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.GetUserManager()).Returns(mockedUserManager.Object);
            mockedProvider.Setup(p => p.GetSignInManager()).Returns(mockedSignInManager.Object);

            var user = new User();

            var mockedFactory = new Mock<IUserFactory>();
            mockedFactory.Setup(
                    f =>
                        f.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                            It.IsAny<string>()))
                .Returns(user);

            var presenter = new RegisterPresenter(mockedView.Object, mockedProvider.Object, mockedFactory.Object);

            var args = new RegisterEventArgs(email, password, name, phone, address);
            mockedView.Raise(v => v.MyRegister += null, args);

            mockedProvider.Verify(p => p.GetSignInManager(), Times.Once);
        }

        [TestCase("pesho@pesho.com", "123456", "Peter", "0881768356", "1 Peshova street")]
        public void TestViewMyInit_ResultSucceededTrue_ShouldCallSignInManagerSignInUserCorrectly(string email, string password, string name, string phone, string address)
        {
            var mockedView = new Mock<IRegisterView>();
            mockedView.Setup(v => v.Model).Returns(new RegisterViewModel());

            var mockedUserManager = new Mock<IUserManager>();
            mockedUserManager.Setup(m => m.CreateUser(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(IdentityResult.Success);

            var mockedSignInManager = new Mock<ISignInManager>();

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.GetUserManager()).Returns(mockedUserManager.Object);
            mockedProvider.Setup(p => p.GetSignInManager()).Returns(mockedSignInManager.Object);

            var user = new User();

            var mockedFactory = new Mock<IUserFactory>();
            mockedFactory.Setup(
                    f =>
                        f.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                            It.IsAny<string>()))
                .Returns(user);

            var presenter = new RegisterPresenter(mockedView.Object, mockedProvider.Object, mockedFactory.Object);

            var args = new RegisterEventArgs(email, password, name, phone, address);
            mockedView.Raise(v => v.MyRegister += null, args);

            mockedSignInManager.Verify(m => m.SignInUser(user, false, false), Times.Once);
        }

        [TestCase("pesho@pesho.com", "123456", "Peter", "0881768356", "1 Peshova street")]
        public void TestViewMyInit_ResultSucceededTrue_ShouldSetViewModelIsRegistrationSuccessfulToTrue(string email, string password, string name, string phone, string address)
        {
            var mockedView = new Mock<IRegisterView>();
            mockedView.Setup(v => v.Model).Returns(new RegisterViewModel());

            var mockedUserManager = new Mock<IUserManager>();
            mockedUserManager.Setup(m => m.CreateUser(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(IdentityResult.Success);

            var mockedSignInManager = new Mock<ISignInManager>();

            var mockedProvider = new Mock<IAuthenticationProvider>();
            mockedProvider.Setup(p => p.GetUserManager()).Returns(mockedUserManager.Object);
            mockedProvider.Setup(p => p.GetSignInManager()).Returns(mockedSignInManager.Object);

            var user = new User();

            var mockedFactory = new Mock<IUserFactory>();
            mockedFactory.Setup(
                    f =>
                        f.CreateUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                            It.IsAny<string>()))
                .Returns(user);

            var presenter = new RegisterPresenter(mockedView.Object, mockedProvider.Object, mockedFactory.Object);

            var args = new RegisterEventArgs(email, password, name, phone, address);
            mockedView.Raise(v => v.MyRegister += null, args);

            Assert.IsTrue(mockedView.Object.Model.IsRegistrationSuccessful);
        }
    }
}
