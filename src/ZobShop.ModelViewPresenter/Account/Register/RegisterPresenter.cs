using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using ZobShop.Authentication;
using ZobShop.Models;

namespace ZobShop.ModelViewPresenter.Account.Register
{
    public class RegisterPresenter : Presenter<IRegisterView>
    {
        public RegisterPresenter(IRegisterView view) : base(view)
        {
            this.View.MyRegister += this.OnRegister;
        }

        private void OnRegister(object sender, RegisterEventArgs e)
        {
            var manager = e.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var user = new User()
            {
                UserName = e.Email,
                Email = e.Email,
                Name = e.Name,
                PhoneNumber = e.Phone,
                Address = e.Address
            };

            var result = manager.Create(user, e.Password);

            if (result.Succeeded)
            {
                var signInManager = e.Context.GetOwinContext().Get<ApplicationSignInManager>();
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);

                this.View.Model.IsRegistrationSuccessful = true;
            }
            else
            {
                this.View.Model.ErrorMessage = result.Errors.FirstOrDefault();
            }
        }
    }
}
