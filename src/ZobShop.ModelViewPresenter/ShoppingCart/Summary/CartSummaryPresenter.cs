using WebFormsMvp;
using ZobShop.Orders.Contracts;

namespace ZobShop.ModelViewPresenter.ShoppingCart.Summary
{
    public class CartSummaryPresenter : Presenter<ICartSummaryView>
    {
        private readonly IShoppingCart cart;

        public CartSummaryPresenter(ICartSummaryView view, IShoppingCart cart)
            : base(view)
        {
            this.cart = cart;
        }
    }
}
