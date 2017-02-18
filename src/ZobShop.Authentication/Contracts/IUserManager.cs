using Microsoft.AspNet.Identity;
using ZobShop.Models;

namespace ZobShop.Authentication.Contracts
{
    public interface IUserManager
    {
        IdentityResult CreateUser(User user, string password);
    }
}
