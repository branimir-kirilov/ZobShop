using System;
using System.Linq.Expressions;
using Moq;
using NUnit.Framework;
using ZobShop.Data.Contracts;
using ZobShop.Factories;
using ZobShop.Models;
using ZobShop.Services;

namespace ZobShop.Tests.Services.CategoryServiceTests
{
    [TestFixture]
    public class GetCategoryByNameTests
    {
        public void TestGetCategoryByName_PassNull_ShouldThrowArgumentNullException()
        {
            var factory = new Mock<ICategoryFactory>();
            var repository = new Mock<IRepository<Category>>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new CategoryService(repository.Object, unitOfWork.Object, factory.Object);

            service.GetCategoryByName(null);
        }

        [TestCase("TestCategoryName")]
        public void TestGetCategoryByName_PassValidName_ShouldCallRepositoryGetAll(string name)
        {
            var factory = new Mock<ICategoryFactory>();
            var repository = new Mock<IRepository<Category>>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new CategoryService(repository.Object, unitOfWork.Object, factory.Object);
            service.GetCategoryByName(name);

            repository.Verify(x => x.GetAll(It.IsAny<Expression<Func<Category, bool>>>()), Times.Once);
        }

    }
}
