using Microsoft.AspNet.Identity.Owin;
using System.Web;
using Microsoft.AspNet.Identity;
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

        public bool IsAuthenticated
        {
            get { return HttpContext.Current.User.Identity.IsAuthenticated; }
        }

        public string CurrentUserId
        {
            get { return HttpContext.Current.User.Identity.GetUserId(); }
        }
    }
}
