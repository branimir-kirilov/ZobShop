using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using ZobShop.Models;
using ZobShop.ModelViewPresenter;
using ZobShop.ModelViewPresenter.Administration.UsersList;
using ZobShop.Services.Contracts;

namespace ZobShop.Mvp.Tests.Administration.UsersListPresenterTests
{
    [TestFixture]
    public class ViewMyInitTests
    {
        [Test]
        public void TestViewMyInit_ShouldCallServiceGetUsers()
        {
            var mockedView = new Mock<IUserListView>();
            mockedView.Setup(v => v.Model).Returns(new UserListViewModel());

            var mockedService = new Mock<IUserService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var presenter = new UserListPresenter(mockedView.Object, mockedService.Object, mockedFactory.Object);

            mockedView.Raise(v => v.MyInit += null, EventArgs.Empty);

            mockedService.Verify(s => s.GetUsers(), Times.Once);
        }

        [Test]
        public void TestViewMyInit_ShouldSetViewModelUsers()
        {
            var mockedView = new Mock<IUserListView>();
            mockedView.Setup(v => v.Model).Returns(new UserListViewModel());

            var user = new User();

            var mockedService = new Mock<IUserService>();
            mockedService.Setup(s => s.GetUsers()).Returns(new List<User> { user });

            var viewModel = new UserDetailsViewModel(null, null, null, null, null);

            var mockedFactory = new Mock<IViewModelFactory>();
            mockedFactory.Setup(f => f.CreateUserDetailsViewModel(It.IsAny<string>(), It.IsAny<string>(),
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(viewModel);

            var presenter = new UserListPresenter(mockedView.Object, mockedService.Object, mockedFactory.Object);

            mockedView.Raise(v => v.MyInit += null, EventArgs.Empty);

            var expected = new List<UserDetailsViewModel> { viewModel };

            CollectionAssert.AreEqual(expected, mockedView.Object.Model.Users);
        }
    }
}
