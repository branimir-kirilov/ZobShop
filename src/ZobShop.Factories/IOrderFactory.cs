using ZobShop.Models;

namespace ZobShop.Factories
{
    public interface IOrderFactory
    {
        Order CreateOrder(string name, string address, string phoneNumber, decimal total);

        ProductOrder CreateProductOrder(Product product, int quantity);
    }
}
