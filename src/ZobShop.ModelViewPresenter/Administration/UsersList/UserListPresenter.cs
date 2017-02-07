using System;
using System.Linq;
using WebFormsMvp;
using ZobShop.Services.Contracts;

namespace ZobShop.ModelViewPresenter.Administration.UsersList
{
    public class UserListPresenter : Presenter<IUserListView>
    {
        private readonly IUserService service;

        public UserListPresenter(IUserListView view, IUserService service) : base(view)
        {
            this.service = service;

            this.View.MyInit += View_MyInit;
        }

        private void View_MyInit(object sender, EventArgs e)
        {
            this.View.Model.Users = this.service.GetUsers();
        }
    }
}
