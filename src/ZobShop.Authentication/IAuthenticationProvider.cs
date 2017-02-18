using ZobShop.Authentication.Contracts;

namespace ZobShop.Authentication
{
    public interface IAuthenticationProvider
    {
        ISignInManager GetSignInManager();

        IUserManager GetUserManager();

        bool IsAuthenticated { get; }
    }
}
