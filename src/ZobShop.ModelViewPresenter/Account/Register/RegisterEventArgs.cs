using System.Web;

namespace ZobShop.ModelViewPresenter.Account.Register
{
    public class RegisterEventArgs
    {
        public RegisterEventArgs(HttpContext context, string email, string password)
        {
            this.Context = context;
            this.Email = email;
            this.Password = password;
        }

        public HttpContext Context { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }
    }
}
