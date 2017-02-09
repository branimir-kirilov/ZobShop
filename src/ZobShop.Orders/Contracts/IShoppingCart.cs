using System.Collections.Generic;
using ZobShop.Models;

namespace ZobShop.Orders.Contracts
{
    public interface IShoppingCart
    {
        ICollection<ICartLine> CartLines { get; }

        void AddItem(Product product, int quantity);

        void RemoveItem(Product product);

        decimal ComputeTotal();

        void ClearCart();
    }
}
