using System;
using WebFormsMvp;

namespace ZobShop.ModelViewPresenter.Account.Login
{
    public interface ILoginView : IView<LoginViewModel>
    {
        event EventHandler<LoginEventArgs> MyLogin;
    }
}
