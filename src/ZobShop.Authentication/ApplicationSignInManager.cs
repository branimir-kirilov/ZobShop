using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using ZobShop.Authentication.Contracts;
using ZobShop.Models;

namespace ZobShop.Authentication
{
    public class ApplicationSignInManager : SignInManager<User, string>, ISignInManager
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager) :
            base(userManager, authenticationManager)
        { }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }

        public SignInStatus SignInWithPassword(string email, string password, bool remember)
        {
            return this.PasswordSignIn(email, password, remember, shouldLockout: false);
        }

        public void SignInUser(User user, bool isPersistent, bool rememberBrowser)
        {
            this.SignIn(user, isPersistent, rememberBrowser);
        }
    }
}
