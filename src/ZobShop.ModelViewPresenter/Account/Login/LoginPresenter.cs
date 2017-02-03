using System.Web;
using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using ZobShop.Authentication;

namespace ZobShop.ModelViewPresenter.Account.Login
{
    public class LoginPresenter : Presenter<ILoginView>
    {
        public LoginPresenter(ILoginView view) : base(view)
        {
            this.View.MyLogin += this.OnLogin;
        }

        private void OnLogin(object sender, LoginEventArgs e)
        {
            var signinManager = e.Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
            
            var result = signinManager.PasswordSignIn(e.Email, e.Password, e.RememberMe, shouldLockout: false);

            this.View.Model.SignInStatus = result;
        }
    }
}
