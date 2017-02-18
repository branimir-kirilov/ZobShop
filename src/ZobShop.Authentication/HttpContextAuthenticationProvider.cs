using Microsoft.AspNet.Identity.Owin;
using System.Web;
using Microsoft.AspNet.Identity;

namespace ZobShop.Authentication
{
    public class HttpContextAuthenticationProvider : IAuthenticationProvider
    {
        public ApplicationSignInManager GetSignInManager()
        {
            return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationSignInManager>();
        }

        public ApplicationUserManager GetUserManager()
        {
            return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        bool IAuthenticationProvider.IsAuthenticated
        {
            get { return HttpContext.Current.User.Identity.IsAuthenticated; }
        }
    }
}
