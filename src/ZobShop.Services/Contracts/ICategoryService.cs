using ZobShop.Models;

namespace ZobShop.Services.Contracts
{
    public interface ICategoryService
    {
        Category GetCategoryByName(string name);

        Category CreateCategory(string name);
    }
}
