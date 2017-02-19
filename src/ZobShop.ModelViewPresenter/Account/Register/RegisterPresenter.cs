using System;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using ZobShop.Authentication;
using ZobShop.Factories;
using ZobShop.Models;

namespace ZobShop.ModelViewPresenter.Account.Register
{
    public class RegisterPresenter : Presenter<IRegisterView>
    {
        private readonly IAuthenticationProvider provider;
        private readonly IUserFactory factory;

        public RegisterPresenter(IRegisterView view, IAuthenticationProvider provider, IUserFactory factory) : base(view)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider cannot be null");
            }

            if (factory == null)
            {
                throw new ArgumentNullException("factory cannot be null");
            }

            this.provider = provider;
            this.factory = factory;

            this.View.MyRegister += this.OnRegister;
            this.View.MyInit += View_MyInit;
        }

        private void View_MyInit(object sender, EventArgs e)
        {
            this.View.Model.IsAuthenticated = this.provider.IsAuthenticated;
        }

        private void OnRegister(object sender, RegisterEventArgs e)
        {
            var manager = this.provider.GetUserManager();

            var user = this.factory.CreateUser(e.Email, e.Email, e.Name, e.Phone, e.Address);

            var result = manager.CreateUser(user, e.Password);

            if (result.Succeeded)
            {
                var signInManager = this.provider.GetSignInManager();
                signInManager.SignInUser(user, isPersistent: false, rememberBrowser: false);

                this.View.Model.IsRegistrationSuccessful = true;
            }
            else
            {
                this.View.Model.ErrorMessage = result.Errors.FirstOrDefault();
            }
        }
    }
}
