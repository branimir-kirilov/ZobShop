using System;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using ZobShop.Authentication;

namespace ZobShop.ModelViewPresenter.Account.Login
{
    public class LoginPresenter : Presenter<ILoginView>
    {
        private readonly IAuthenticationProvider provider;

        public LoginPresenter(ILoginView view, IAuthenticationProvider provider) : base(view)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider cannot be null");
            }

            this.provider = provider;

            this.View.MyLogin += this.OnLogin;
            this.View.MyInit += View_MyInit;
        }

        private void View_MyInit(object sender, EventArgs e)
        {
            this.View.Model.IsAuthenticated = this.provider.IsAuthenticated;
        }

        private void OnLogin(object sender, LoginEventArgs e)
        {
            var signinManager = this.provider.GetSignInManager();

            var result = signinManager.SignInWithPassword(e.Email, e.Password, e.RememberMe);

            this.View.Model.SignInStatus = result;
        }
    }
}
