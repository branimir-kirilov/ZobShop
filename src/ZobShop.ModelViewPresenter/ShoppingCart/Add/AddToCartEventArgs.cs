using System;

namespace ZobShop.ModelViewPresenter.ShoppingCart.Add
{
    public class AddToCartEventArgs : EventArgs
    {
        public AddToCartEventArgs(int productId, int quantity)
        {
            this.ProductId = productId;
            this.Quantity = quantity;
        }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
