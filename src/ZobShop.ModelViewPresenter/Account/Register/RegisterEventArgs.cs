using System;
using System.Web;

namespace ZobShop.ModelViewPresenter.Account.Register
{
    public class RegisterEventArgs : EventArgs
    {
        public RegisterEventArgs(HttpContext context, string email, string password, string name, string phone, string address)
        {
            this.Context = context;
            this.Email = email;
            this.Name = name;
            this.Password = password;
            this.Phone = phone;
            this.Address = address;
        }

        public HttpContext Context { get; private set; }

        public string Email { get; private set; }

        public string Address { get; private set; }

        public string Phone { get; private set; }

        public string Name { get; private set; }

        public string Password { get; private set; }
    }
}
