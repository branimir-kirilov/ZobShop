using WebFormsMvp;
using ZobShop.Orders.Contracts;

namespace ZobShop.ModelViewPresenter.ShoppingCart.Add
{
    public class AddToCartPresenter : Presenter<IAddToCartView>
    {
        private readonly IShoppingCart cart;

        public AddToCartPresenter(IAddToCartView view, IShoppingCart cart) : base(view)
        {
            this.cart = cart;

            this.View.MyAddToCart += View_MyAddToCart;
        }

        private void View_MyAddToCart(object sender, AddToCartEventArgs e)
        {
            this.cart.AddItem(e.ProductId, e.Quantity);
        }
    }
}
