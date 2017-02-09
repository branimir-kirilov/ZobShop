using ZobShop.Models;
using ZobShop.Orders.Contracts;

namespace ZobShop.Orders.Factories
{
    public interface ICartLineFactory
    {
        ICartLine CreateCartLine(Product product, int quantity);
    }
}
