using ZobShop.ModelViewPresenter.Product.Details;

namespace ZobShop.ModelViewPresenter.ShoppingCart.Summary
{
    public class CartLineViewModel
    {
        public CartLineViewModel(ProductDetailsViewModel model, int quantity)
        {
            this.Model = model;
            this.Quantity = quantity;
            this.ProductId = this.Model.Id;
        }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public ProductDetailsViewModel Model { get; set; }
    }
}
