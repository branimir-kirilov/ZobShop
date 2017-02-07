using Moq;
using NUnit.Framework;
using ZobShop.Data.Contracts;
using ZobShop.Factories;
using ZobShop.Models;
using ZobShop.Services.Contracts;

namespace ZobShop.Tests.Services.ProductService
{
    [TestFixture]
    public class GetByIdTests
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void TestGetById_ShouldCallRepositoryGetById(int id)
        {
            var factory = new Mock<IProductFactory>();
            var repository = new Mock<IRepository<Product>>();
            var categoryService = new Mock<ICategoryService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            service.GetById(id);

            repository.Verify(x => x.GetById(id), Times.Once);
        }

        [TestCase(3)]
        [TestCase(1)]
        public void TestGetById_ShouldReturnCorrectly(int id)
        {
            var mockedProduct = new Mock<Product>();

            var factory = new Mock<IProductFactory>();
            var repository = new Mock<IRepository<Product>>();
            repository.Setup(x => x.GetById(It.IsAny<object>())).Returns(mockedProduct.Object);

            var categoryService = new Mock<ICategoryService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            var result = service.GetById(id);

            Assert.AreSame(mockedProduct.Object, result);
        }
    }
}
