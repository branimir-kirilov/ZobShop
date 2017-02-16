using System;
using WebFormsMvp;
using ZobShop.ModelViewPresenter.Administration.ProductsList;

namespace ZobShop.ModelViewPresenter.ShoppingCart.Summary
{
    public interface ICartSummaryView : IView<CartSummaryVIewModel>
    {
        event EventHandler MyInit;

        event EventHandler<DeleteProductEventArgs> RemoveFromCart;
    }
}
