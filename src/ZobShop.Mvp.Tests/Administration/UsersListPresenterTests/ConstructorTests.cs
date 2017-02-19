using System;
using Moq;
using NUnit.Framework;
using ZobShop.ModelViewPresenter;
using ZobShop.ModelViewPresenter.Administration.ProductsList;
using ZobShop.ModelViewPresenter.Administration.UsersList;
using ZobShop.Services.Contracts;

namespace ZobShop.Mvp.Tests.Administration.UsersListPresenterTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassServiceNull_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<IUserListView>();
            var mockedFactory = new Mock<IViewModelFactory>();

            Assert.Throws<ArgumentNullException>(() =>
            new UserListPresenter(mockedView.Object, null, mockedFactory.Object));
        }

        [Test]
        public void TestConstructor_PassFactoryNull_ShouldThrowArgumentNullException()
        {
            var mockedView = new Mock<IUserListView>();
            var mockedService = new Mock<IUserService>();

            Assert.Throws<ArgumentNullException>(() =>
             new UserListPresenter(mockedView.Object, mockedService.Object, null));
        }

        [Test]
        public void TestConstructor_ShouldInitializeCorrectly()
        {
            var mockedView = new Mock<IUserListView>();
            var mockedService = new Mock<IUserService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var presenter = new UserListPresenter(mockedView.Object, mockedService.Object, mockedFactory.Object);

            Assert.IsNotNull(presenter);
        }
    }
}
