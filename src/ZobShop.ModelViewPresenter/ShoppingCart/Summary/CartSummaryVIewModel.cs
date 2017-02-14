using System.Collections.Generic;

namespace ZobShop.ModelViewPresenter.ShoppingCart.Summary
{
    public class CartSummaryVIewModel
    {
        public IEnumerable<CartLineViewModel> Products { get; set; }
    }
}
