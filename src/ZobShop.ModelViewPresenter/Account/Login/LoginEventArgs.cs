using System;
using System.Web;

namespace ZobShop.ModelViewPresenter.Account.Login
{
    public class LoginEventArgs : EventArgs
    {
        public LoginEventArgs(HttpContext context, string email, string password, bool rememberMe)
        {
            this.Context = context;
            this.Email = email;
            this.Password = password;
            this.RememberMe = rememberMe;
        }

        public HttpContext Context { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public bool RememberMe { get; private set; }
    }
}
