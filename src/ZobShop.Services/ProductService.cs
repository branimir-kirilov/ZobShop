using System;
using System.Collections.Generic;
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
        private readonly ICategoryService categoryService;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IProductFactory factory,
            IRepository<Product> productRepository,
            ICategoryService categoryService,
            IUnitOfWork unitOfWork)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory cannot be null");
            }

            if (productRepository == null)
            {
                throw new ArgumentNullException("repository cannot be null");
            }

            if (categoryService == null)
            {
                throw new ArgumentNullException("service cannot be null");
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unit of work cannot be null");
            }

            this.factory = factory;
            this.productRepository = productRepository;
            this.categoryService = categoryService;
            this.unitOfWork = unitOfWork;
        }

        public Product CreateProduct(string name,
            string categoryName,
            int quantity,
            decimal price,
            double volume,
            string maker,
            string imageMimeType,
            byte[] imageBuffer)
        {
            var category = this.categoryService.GetCategoryByName(categoryName);

            if (category == null)
            {
                category = this.categoryService.CreateCategory(categoryName);
            }

            var product = this.factory.CreateProduct(name, category, quantity, price, volume, maker, imageMimeType, imageBuffer);
            this.productRepository.Add(product);
            this.unitOfWork.Commit();

            return product;
        }

        public Product GetById(int id)
        {
            var product = this.productRepository.GetById(id);

            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.productRepository.Entities.ToList();
        }

        public IEnumerable<Product> GetProductsByCategory(string categoryName)
        {
            var products = this.productRepository
                .GetAll((Product p) => p.Category.Name == categoryName)
                .ToList();

            return products;
        }

        public void EditProduct(Product product)
        {
            this.productRepository.Update(product);
            this.unitOfWork.Commit();
        }

        public void DeleteProduct(int productId)
        {
            var product = this.productRepository.GetById(productId);

            if (product != null)
            {
                this.productRepository.Delete(product);
                this.unitOfWork.Commit();
            }
        }

        public IEnumerable<Product> SearchProducts(string searchQuery)
        {
            var products = this.productRepository.GetAll((Product p) => p.Name.Contains(searchQuery) ||
                                                                        p.Maker.Contains(searchQuery) ||
                                                                        p.Category.Name.Contains(searchQuery))
                                                                        .ToList();

            return products;
        }
    }
}
