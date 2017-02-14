using System;
using WebFormsMvp;

namespace ZobShop.ModelViewPresenter.ShoppingCart.Add
{
    public interface IAddToCartView : IView<AddToCartViewModel>
    {
        event EventHandler<AddToCartEventArgs> MyAddToCart;
    }
}
