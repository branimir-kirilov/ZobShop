using ZobShop.Models;

namespace ZobShop.Services.Contracts
{
    public interface IProductRatingService
    {
        ProductRating CreateProductRating(int rating, string content, int productId, string userId);
    }
}
