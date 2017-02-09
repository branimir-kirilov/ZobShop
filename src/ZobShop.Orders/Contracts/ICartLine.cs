using ZobShop.Models;

namespace ZobShop.Orders.Contracts
{
    public interface ICartLine
    {
        Product Product { get; set; }

        int Quantity { get; set; }
    }
}
