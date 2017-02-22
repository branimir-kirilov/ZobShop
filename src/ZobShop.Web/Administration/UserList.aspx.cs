using System;
using System.Collections.Generic;
using WebFormsMvp;
using WebFormsMvp.Web;
using ZobShop.ModelViewPresenter.Administration.UsersList;
using ZobShop.ModelViewPresenter.Product.Details;

namespace ZobShop.Web.Administration
{
    [PresenterBinding(typeof(UserListPresenter))]
    public partial class UserList : MvpPage<UserListViewModel>, IUserListView
    {
        public event EventHandler MyInit;
        public event EventHandler<UserIdEventArgs> DeleteUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.MyInit?.Invoke(sender, e);
        }

        public void Delete(string userId)
        {
            var args = new UserIdEventArgs(userId);

            this.DeleteUser?.Invoke(this, args);
        }

        public IEnumerable<UserDetailsViewModel> Select()
        {
            return this.Model.Users;
        }
    }
}