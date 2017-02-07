using System;
using WebFormsMvp;

namespace ZobShop.ModelViewPresenter.Administration.UsersList
{
    public interface IUserListView : IView<UserListViewModel>
    {
        event EventHandler MyInit;
    }
}
