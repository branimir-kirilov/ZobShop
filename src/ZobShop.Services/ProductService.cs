using System;
using System.Linq;
using ZobShop.Data.Contracts;
using ZobShop.Factories;
using ZobShop.Models;
using ZobShop.Services.Contracts;

namespace ZobShop.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductFactory factory;
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<Category> categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IProductFactory factory,
            IRepository<Product> productRepository,
            IRepository<Category> categoryRepository,
            IUnitOfWork unitOfWork)
        {
            this.factory = factory;
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public Product CreateProduct(string name, string categoryName, int quantity, decimal price, double volume, string maker)
        {
            var category = new Category { Name = categoryName };

            var product = this.factory.CreateProduct(name, category, quantity, price, volume, maker);
            this.productRepository.Add(product);
            this.unitOfWork.Commit();

            return product;
        }
    }
}
