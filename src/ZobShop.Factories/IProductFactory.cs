using ZobShop.Models;

namespace ZobShop.Factories
{
    public interface IProductFactory
    {
        Product CreateProduct(string name, Category category, int quantity, decimal price, double volume, string maker);
    }
}
