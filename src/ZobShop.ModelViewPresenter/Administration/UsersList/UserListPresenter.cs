using System;
using System.Linq;
using WebFormsMvp;
using ZobShop.Services.Contracts;

namespace ZobShop.ModelViewPresenter.Administration.UsersList
{
    public class UserListPresenter : Presenter<IUserListView>
    {
        private readonly IUserService service;
        private readonly IViewModelFactory factory;

        public UserListPresenter(IUserListView view, IUserService service, IViewModelFactory factory) : base(view)
        {
            if (service == null)
            {
                throw new ArgumentNullException("service cannot be null");
            }

            if (factory == null)
            {
                throw new ArgumentNullException("factory cannot be null");
            }

            this.service = service;
            this.factory = factory;

            this.View.MyInit += View_MyInit;
            this.View.DeleteUser += View_DeleteUser;
        }

        private void View_DeleteUser(object sender, UserIdEventArgs e)
        {
            this.service.DeleteUser(e.UserId);
        }

        private void View_MyInit(object sender, EventArgs e)
        {
            var users = this.service.GetUsers();

            var viewModels =
                users.Select(
                    u => this.factory.CreateUserDetailsViewModel(u.Email, u.Address, u.PhoneNumber, u.UserName, u.Id));

            this.View.Model.Users = viewModels;
        }
    }
}
