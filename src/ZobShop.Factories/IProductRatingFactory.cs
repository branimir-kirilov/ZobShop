using ZobShop.Models;

namespace ZobShop.Factories
{
    public interface IProductRatingFactory
    {
        ProductRating CreateProductRating(int rating, string content, Product product, User author);
    }
}
