using System;

namespace ZobShop.ModelViewPresenter.Account
{
    public interface IAccountRedirectView
    {
        event EventHandler<AccountRedirectEventArgs> MyInit;
    }
}
