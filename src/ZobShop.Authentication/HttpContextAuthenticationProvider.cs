using Microsoft.AspNet.Identity.Owin;
using System.Web;
using ZobShop.Authentication.Contracts;

namespace ZobShop.Authentication
{
    public class HttpContextAuthenticationProvider : IAuthenticationProvider
    {
        public ISignInManager GetSignInManager()
        {
            return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationSignInManager>();
        }

        public IUserManager GetUserManager()
        {
            return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        bool IAuthenticationProvider.IsAuthenticated
        {
            get { return HttpContext.Current.User.Identity.IsAuthenticated; }
        }
    }
}
