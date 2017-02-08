using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Moq;
using NUnit.Framework;
using ZobShop.Data.Contracts;
using ZobShop.Factories;
using ZobShop.Models;
using ZobShop.Services.Contracts;

namespace ZobShop.Tests.Services.ProductService
{
    [TestFixture]
    public class GetProductsByCategoryTests
    {
        [TestCase("TestCategory")]
        [TestCase("CategoryTest")]
        public void TestGetProductsByCategory_ShouldCallRepositoryGetAll(string category)
        {
            var factory = new Mock<IProductFactory>();
            var repository = new Mock<IRepository<Product>>();
            var categoryService = new Mock<ICategoryService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            service.GetProductsByCategory(category);

            repository.Verify(x => x.GetAll(It.IsAny<Expression<Func<Product, bool>>>()), Times.Once);
        }

        [TestCase("TestCategory")]
        [TestCase("CategoryTest")]
        public void TestGetProductsByCategory_ShouldReturnCorrectly(string category)
        {
            var firstMockedProduct = new Mock<Product>();
            var secondMockedProduct = new Mock<Product>();
            var thirdMockedProduct = new Mock<Product>();

            var collection = new List<Product>
            {
                firstMockedProduct.Object,
                secondMockedProduct.Object,
                thirdMockedProduct.Object
           };

            var factory = new Mock<IProductFactory>();
            var repository = new Mock<IRepository<Product>>();
            repository.Setup(x => x.GetAll(It.IsAny<Expression<Func<Product, bool>>>())).Returns(collection);

            var categoryService = new Mock<ICategoryService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            var result = service.GetProductsByCategory(category);

            Assert.AreEqual(collection, result);
        }
    }
}
