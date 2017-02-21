using System.Collections.Generic;
using ZobShop.Models;

namespace ZobShop.Orders.Contracts
{
    public interface IShoppingCart
    {
        ICollection<ICartLine> CartLines { get; }

        void AddItem(int productId, int quantity);

        void RemoveItem(int productId);

        decimal ComputeTotal();

        void ClearCart();

        void FinishOrder(string name, string address, string phoneNumber);
    }
}
