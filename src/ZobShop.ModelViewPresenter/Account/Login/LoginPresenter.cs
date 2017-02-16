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
            this.View.MyInit += View_MyInit;
        }

        private void View_MyInit(object sender, AccountRedirectEventArgs e)
        {
            var isAuthenticated = e.HttpContext.User.Identity.IsAuthenticated;
            this.View.Model.IsAuthenticated = isAuthenticated;
        }

        private void OnLogin(object sender, LoginEventArgs e)
        {
            var signinManager = e.Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

            var result = signinManager.PasswordSignIn(e.Email, e.Password, e.RememberMe, shouldLockout: false);

            this.View.Model.SignInStatus = result;
        }
    }
}
