using System;
using WebFormsMvp;

namespace ZobShop.ModelViewPresenter.ShoppingCart.Summary
{
    public interface ICartSummaryView : IView<CartSummaryVIewModel>
    {
        event EventHandler MyInit;
    }
}
