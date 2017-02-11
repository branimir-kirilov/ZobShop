using ZobShop.Data.Contracts;
using ZobShop.Factories;
using ZobShop.Models;
using ZobShop.Services.Contracts;

namespace ZobShop.Services
{
    public class ProductRatingService : IProductRatingService
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<ProductRating> productRatingRepository;
        private readonly IRepository<Product> productRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductRatingFactory factory;

        public ProductRatingService(IRepository<User> userRepository,
            IRepository<Product> productRepository,
            IRepository<ProductRating> productRatingRepository,
            IUnitOfWork unitOfWork,
            IProductRatingFactory factory)
        {
            this.userRepository = userRepository;
            this.productRepository = productRepository;
            this.productRatingRepository = productRatingRepository;
            this.unitOfWork = unitOfWork;
            this.factory = factory;
        }

        public ProductRating CreateProductRating(int rating, string content, int productId, string userId)
        {
            var product = this.productRepository.GetById(productId);
            var user = this.userRepository.GetById(userId);

            var newRating = this.factory.CreateProductRating(rating, content, product, user);
            this.productRatingRepository.Add(newRating);
            this.unitOfWork.Commit();

            return newRating;
        }
    }
}
