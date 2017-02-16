using System;
using System.Collections.Generic;
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
    public class SearchProductTests
    {
        [TestCase("search param")]
        [TestCase("searcho")]
        [TestCase("searching")]
        public void TestSearchProducts_ShouldCallRepositoryGetAll(string searchParam)
        {
            var factory = new Mock<IProductFactory>();
            var repository = new Mock<IRepository<Product>>();
            var categoryService = new Mock<ICategoryService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            service.SearchProducts(searchParam);

            repository.Verify(x => x.GetAll(It.IsAny<Expression<Func<Product, bool>>>()), Times.Once);
        }

        [TestCase("search param")]
        [TestCase("searcho")]
        [TestCase("searching")]
        public void TestSearchProducts_ShouldReturnCorrectProducts(string searchParam)
        {
            var firstMockedProduct = new Mock<Product>();
            var secondMockedProduct = new Mock<Product>();
            var thirdMockedProduct = new Mock<Product>();

            var products = new List<Product>
            {
                firstMockedProduct.Object,
                secondMockedProduct.Object,
                thirdMockedProduct.Object
            };

            var factory = new Mock<IProductFactory>();
            var repository = new Mock<IRepository<Product>>();
            repository.Setup(x => x.GetAll(It.IsAny<Expression<Func<Product, bool>>>()))
                .Returns(products);

            var categoryService = new Mock<ICategoryService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            var result = service.SearchProducts(searchParam);

            Assert.AreEqual(products, result);
        }
    }
}
