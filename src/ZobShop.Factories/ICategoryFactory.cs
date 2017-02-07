using ZobShop.Models;

namespace ZobShop.Factories
{
    public interface ICategoryFactory
    {
        Category CreateCategory(string name);
    }
}
