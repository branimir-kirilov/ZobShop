using Moq;
using NUnit.Framework;
using ZobShop.Data.Contracts;
using ZobShop.Factories;
using ZobShop.Models;
using ZobShop.Services.Contracts;

namespace ZobShop.Tests.Services.ProductService
{
    [TestFixture]
    public class DeleteProductTests
    {
        [TestCase(1)]
        [TestCase(197)]
        [TestCase(123)]
        public void TestDeleteProduct_ShouldCallRepositoryGetByIdCorrectly(int id)
        {
            var factory = new Mock<IProductFactory>();
            var repository = new Mock<IRepository<Product>>();
            var categoryService = new Mock<ICategoryService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            service.DeleteProduct(id);

            repository.Verify(x => x.GetById(id), Times.Once);
        }

        [TestCase(123)]
        public void TestDeleteProduct_NoProductFound_ShouldNotCallRepositoryDeleteCorrectly(int id)
        {
            var factory = new Mock<IProductFactory>();
            var repository = new Mock<IRepository<Product>>();
            repository.Setup(x => x.GetById(It.IsAny<object>()))
                .Returns((Product)null);

            var categoryService = new Mock<ICategoryService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            service.DeleteProduct(id);

            repository.Verify(x => x.Delete(It.IsAny<Product>()), Times.Never);
        }

        [TestCase(123)]
        public void TestDeleteProduct_NoProductFound_ShouldNotCallUnitOfWorkCommit(int id)
        {
            var factory = new Mock<IProductFactory>();
            var repository = new Mock<IRepository<Product>>();
            repository.Setup(x => x.GetById(It.IsAny<object>()))
                .Returns((Product)null);

            var categoryService = new Mock<ICategoryService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            service.DeleteProduct(id);

            unitOfWork.Verify(x => x.Commit(), Times.Never);
        }

        [TestCase(1)]
        [TestCase(123)]
        public void TestDeleteProduct_ShouldCallRepositoryDeleteCorrectly(int id)
        {
            var factory = new Mock<IProductFactory>();

            var mockedProduct = new Mock<Product>();

            var repository = new Mock<IRepository<Product>>();
            repository.Setup(x => x.GetById(It.IsAny<object>()))
                .Returns(mockedProduct.Object);

            var categoryService = new Mock<ICategoryService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            service.DeleteProduct(id);

            repository.Verify(x => x.Delete(mockedProduct.Object), Times.Once);
        }

        [TestCase(1)]
        [TestCase(123)]
        public void TestDeleteProduct_ShouldCallUnitOfWorkCommitCorrectly(int id)
        {
            var factory = new Mock<IProductFactory>();

            var mockedProduct = new Mock<Product>();

            var repository = new Mock<IRepository<Product>>();
            repository.Setup(x => x.GetById(It.IsAny<object>()))
                .Returns(mockedProduct.Object);

            var categoryService = new Mock<ICategoryService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            service.DeleteProduct(id);

            unitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
