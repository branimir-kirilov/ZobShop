using System;
using System.Web;

namespace ZobShop.ModelViewPresenter.Account.Login
{
    public class LoginEventArgs : EventArgs
    {
        public LoginEventArgs( string email, string password, bool rememberMe)
        {
            this.Email = email;
            this.Password = password;
            this.RememberMe = rememberMe;
        }
        
        public string Email { get; private set; }

        public string Password { get; private set; }

        public bool RememberMe { get; private set; }
    }
}
