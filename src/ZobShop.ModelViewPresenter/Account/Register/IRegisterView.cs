using System;
using WebFormsMvp;

namespace ZobShop.ModelViewPresenter.Account.Register
{
    public interface IRegisterView : IView<RegisterViewModel>, IAccountRedirectView
    {
        event EventHandler<RegisterEventArgs> MyRegister;
    }
}
