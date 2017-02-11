using System;
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
            if (userRepository == null)
            {
                throw new ArgumentNullException("user repository cannot be null");
            }

            if (productRepository == null)
            {
                throw new ArgumentNullException("product repository cannot be null");
            }

            if (productRatingRepository == null)
            {
                throw new ArgumentNullException("product rating repository cannot be null");
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unit of work repository cannot be null");
            }

            if (factory == null)
            {
                throw new ArgumentNullException("factory repository cannot be null");
            }

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
