using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using ZobShop.Data.Contracts;
using ZobShop.Factories;
using ZobShop.Models;
using ZobShop.Services.Contracts;

namespace ZobShop.Tests.Services.ProductService
{
    [TestFixture]
    public class GetProductsTests
    {
        [Test]
        public void TestGetProducts_ShouldCallRepositoryEntities()
        {
            var factory = new Mock<IProductFactory>();
            var repository = new Mock<IRepository<Product>>();
            var categoryService = new Mock<ICategoryService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            service.GetProducts();

            repository.Verify(x => x.Entities, Times.Once);
        }

        public void TestGetProducts_ShouldReturnCorrectCollection()
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
            repository.Setup(x => x.Entities).Returns(collection);

            var categoryService = new Mock<ICategoryService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            var result = service.GetProducts();

            Assert.AreSame(collection, result);
        }
    }
}
