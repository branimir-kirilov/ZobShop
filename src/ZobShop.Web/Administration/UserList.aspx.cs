using System;
using WebFormsMvp;
using WebFormsMvp.Web;
using ZobShop.ModelViewPresenter.Administration.UsersList;

namespace ZobShop.Web.Administration
{
    [PresenterBinding(typeof(UserListPresenter))]
    public partial class UserList : MvpPage<UserListViewModel>, IUserListView
    {
        public event EventHandler MyInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.MyInit?.Invoke(sender, e);
        }
    }
}