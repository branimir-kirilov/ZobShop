using System;
using System.Web;

namespace ZobShop.ModelViewPresenter.Account
{
    public class AccountRedirectEventArgs : EventArgs
    {
        public AccountRedirectEventArgs(HttpContext context)
        {
            this.HttpContext = context;
        }

        public HttpContext HttpContext { get; set; }
    }
}
