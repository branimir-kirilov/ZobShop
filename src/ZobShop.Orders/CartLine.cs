using ZobShop.Models;
using ZobShop.Orders.Contracts;

namespace ZobShop.Orders
{
    public class CartLine : ICartLine
    {
        public CartLine(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
