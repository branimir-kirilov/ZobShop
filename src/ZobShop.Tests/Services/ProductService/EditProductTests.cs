using Moq;
using NUnit.Framework;
using ZobShop.Data.Contracts;
using ZobShop.Factories;
using ZobShop.Models;
using ZobShop.Services.Contracts;

namespace ZobShop.Tests.Services.ProductService
{
    [TestFixture]
    public class EditProductTests
    {
        [Test]
        public void TestEditProduct_ShouldCallRepositoryUpdateCorrectly()
        {
            var factory = new Mock<IProductFactory>();
            var repository = new Mock<IRepository<Product>>();
            var categoryService = new Mock<ICategoryService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            var mockedProduct = new Mock<Product>();

            service.EditProduct(mockedProduct.Object);

            repository.Verify(x => x.Update(mockedProduct.Object), Times.Once);
        }

        [Test]
        public void TestEditProduct_ShouldCallUnitOfWorkCommitCorrectly()
        {
            var factory = new Mock<IProductFactory>();
            var repository = new Mock<IRepository<Product>>();
            var categoryService = new Mock<ICategoryService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            var mockedProduct = new Mock<Product>();

            service.EditProduct(mockedProduct.Object);

            unitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
