using System;
using System.Collections.Generic;
using System.Linq;
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

            Assert.Throws<ArgumentNullException>(() => service.GetCategoryByName(null));
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

        [TestCase("TestCategoryName")]
        [TestCase("OtherTestCategoryName")]
        public void TestGetCategoryByName_PassValidName_ShouldReturnCorrectly(string name)
        {
            var factory = new Mock<ICategoryFactory>();

            var firstMockedCategory = new Mock<Category>();
            var categories = new List<Category> { firstMockedCategory.Object };

            var repository = new Mock<IRepository<Category>>();
            repository.Setup(x => x.GetAll(It.IsAny<Expression<Func<Category, bool>>>()))
                .Returns(categories);

            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new CategoryService(repository.Object, unitOfWork.Object, factory.Object);
            var result = service.GetCategoryByName(name);

            Assert.AreSame(firstMockedCategory.Object, result);
        }

    }
}
