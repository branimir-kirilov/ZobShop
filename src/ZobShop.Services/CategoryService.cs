using System;
using System.Linq;
using ZobShop.Data.Contracts;
using ZobShop.Factories;
using ZobShop.Models;
using ZobShop.Services.Contracts;

namespace ZobShop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICategoryFactory factory;

        public CategoryService(IRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryFactory factory)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository cannot be null");
            }

            if (factory == null)
            {
                throw new ArgumentNullException("factory cannot be null");
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unit of work cannot be null");
            }

            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.factory = factory;
        }

        public Category GetCategoryByName(string name)
        {
            var category = this.repository
                .GetAll((Category c) => c.Name == name)
                .FirstOrDefault();

            return category;
        }

        public Category CreateCategory(string name)
        {
            var category = this.factory.CreateCategory(name);

            this.repository.Add(category);
            this.unitOfWork.Commit();

            return category;
        }
    }
}
