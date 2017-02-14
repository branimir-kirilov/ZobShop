using ZobShop.ModelViewPresenter.Product.Details;

namespace ZobShop.ModelViewPresenter.ShoppingCart.Summary
{
    public class CartLineViewModel
    {
        public CartLineViewModel(ProductDetailsViewModel model, int quantity)
        {
            this.Model = model;
            this.Quantity = quantity;
        }

        public int Quantity { get; set; }

        public ProductDetailsViewModel Model { get; set; }
    }
}
