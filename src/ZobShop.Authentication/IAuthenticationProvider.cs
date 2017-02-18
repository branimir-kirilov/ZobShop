namespace ZobShop.Authentication
{
    public interface IAuthenticationProvider
    {
        ApplicationSignInManager GetSignInManager();

        ApplicationUserManager GetUserManager();

        bool IsAuthenticated { get; }
    }
}
