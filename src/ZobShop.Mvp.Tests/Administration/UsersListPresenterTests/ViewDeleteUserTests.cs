using Moq;
using NUnit.Framework;
using ZobShop.ModelViewPresenter;
using ZobShop.ModelViewPresenter.Administration.UsersList;
using ZobShop.Services.Contracts;

namespace ZobShop.Mvp.Tests.Administration.UsersListPresenterTests
{
    [TestFixture]
    public class ViewDeleteUserTests
    {
        [TestCase("2e2c6146-caf9-4091-9c8a-f11128dc8f39")]
        [TestCase("682caaec-71ac-4dd1-82f5-d05e5817f943")]
        public void TestViewDeleteUser_ShouldCallServiceDeleteUserCorrectly(string userId)
        {
            var mockedView = new Mock<IUserListView>();
            mockedView.Setup(v => v.Model).Returns(new UserListViewModel());

            var mockedService = new Mock<IUserService>();
            var mockedFactory = new Mock<IViewModelFactory>();

            var presenter = new UserListPresenter(mockedView.Object, mockedService.Object, mockedFactory.Object);

            var args = new UserIdEventArgs(userId);
            mockedView.Raise(v => v.DeleteUser += null, args);

            mockedService.Verify(s => s.DeleteUser(userId), Times.Once);
        }
    }
}
