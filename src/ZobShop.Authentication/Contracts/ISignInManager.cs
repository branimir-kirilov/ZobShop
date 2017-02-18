using Microsoft.AspNet.Identity.Owin;
using ZobShop.Models;

namespace ZobShop.Authentication.Contracts
{
    public interface ISignInManager
    {
        SignInStatus SignInWithPassword(string email, string password, bool remember);

        void SignInUser(User user, bool isPersistent, bool rememberBrowser);
    }
}
