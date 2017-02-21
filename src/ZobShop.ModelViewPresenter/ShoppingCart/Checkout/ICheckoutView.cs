using System;
using WebFormsMvp;

namespace ZobShop.ModelViewPresenter.ShoppingCart.Checkout
{
    public interface ICheckoutView : IView<CheckoutViewModel>
    {
        event EventHandler MyInit;
    }
}
