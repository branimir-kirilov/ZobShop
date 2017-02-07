using Moq;
using NUnit.Framework;
using ZobShop.Data.Contracts;
using ZobShop.Factories;
using ZobShop.Models;
using ZobShop.Services.Contracts;

namespace ZobShop.Tests.Services.ProductService
{
    [TestFixture]
    public class CreateProductTests
    {
        [TestCase("TestProduct", "TestCategoryName", 10, 5.00, 2.00, "TestMaker")]
        public void TestCreateProduct_ShouldCallCategoryServiceGetCategoryByNameWithCorrectValue(string name,
            string categoryName,
            int quantity,
            decimal price,
            double volume,
            string maker)
        {
            var factory = new Mock<IProductFactory>();
            var repository = new Mock<IRepository<Product>>();
            var categoryService = new Mock<ICategoryService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            service.CreateProduct(name, categoryName, quantity, price, volume, maker);

            categoryService.Verify(x => x.GetCategoryByName(categoryName), Times.Once);
        }

        [TestCase("TestProduct", "TestCategoryName", 10, 5.00, 2.00, "TestMaker")]
        public void TestCreateProduct_ServiceReturnsNull_ShouldCallCategoryServiceCreateCategoryWithCorrectValue(string name,
           string categoryName,
           int quantity,
           decimal price,
           double volume,
           string maker)
        {
            var factory = new Mock<IProductFactory>();
            var repository = new Mock<IRepository<Product>>();
            var categoryService = new Mock<ICategoryService>();
            categoryService.Setup(x => x.GetCategoryByName(It.IsAny<string>())).Returns((Category)null);

            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            service.CreateProduct(name, categoryName, quantity, price, volume, maker);

            categoryService.Verify(x => x.CreateCategory(categoryName), Times.Once);
        }

        [TestCase("TestProduct", "TestCategoryName", 10, 5.00, 2.00, "TestMaker")]
        public void TestCreateProduct_ShouldCallFactoryCreateProduct(string name,
           string categoryName,
           int quantity,
           decimal price,
           double volume,
           string maker)
        {
            var factory = new Mock<IProductFactory>();
            var repository = new Mock<IRepository<Product>>();
            var categoryService = new Mock<ICategoryService>();
            categoryService.Setup(x => x.GetCategoryByName(It.IsAny<string>())).Returns(It.IsAny<Category>());

            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            service.CreateProduct(name, categoryName, quantity, price, volume, maker);

            factory.Verify(x => x.CreateProduct(name, It.IsAny<Category>(), quantity, price, volume, maker), Times.Once);
        }

        [TestCase("TestProduct", "TestCategoryName", 10, 5.00, 2.00, "TestMaker")]
        public void TestCreateProduct_ShouldCallRepositoryAdd(string name,
           string categoryName,
           int quantity,
           decimal price,
           double volume,
           string maker)
        {
            var mockedProduct = new Mock<Product>();

            var factory = new Mock<IProductFactory>();
            factory.Setup(f => f.CreateProduct(It.IsAny<string>(),
                    It.IsAny<Category>(),
                    It.IsAny<int>(),
                    It.IsAny<decimal>(),
                    It.IsAny<double>(),
                    It.IsAny<string>()))
                .Returns(mockedProduct.Object);

            var repository = new Mock<IRepository<Product>>();
            var categoryService = new Mock<ICategoryService>();
            categoryService.Setup(x => x.GetCategoryByName(It.IsAny<string>())).Returns(It.IsAny<Category>());

            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            service.CreateProduct(name, categoryName, quantity, price, volume, maker);

            repository.Verify(x => x.Add(mockedProduct.Object), Times.Once);
        }

        [TestCase("TestProduct", "TestCategoryName", 10, 5.00, 2.00, "TestMaker")]
        public void TestCreateProduct_ShouldCallUnitOfWorkCommit(string name,
           string categoryName,
           int quantity,
           decimal price,
           double volume,
           string maker)
        {
            var factory = new Mock<IProductFactory>();
            factory.Setup(f => f.CreateProduct(It.IsAny<string>(),
                    It.IsAny<Category>(),
                    It.IsAny<int>(),
                    It.IsAny<decimal>(),
                    It.IsAny<double>(),
                    It.IsAny<string>()))
                .Returns(It.IsAny<Product>());

            var repository = new Mock<IRepository<Product>>();
            var categoryService = new Mock<ICategoryService>();
            categoryService.Setup(x => x.GetCategoryByName(It.IsAny<string>())).Returns(It.IsAny<Category>());

            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            service.CreateProduct(name, categoryName, quantity, price, volume, maker);

            unitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [TestCase("TestProduct", "TestCategoryName", 10, 5.00, 2.00, "TestMaker")]
        public void TestCreateProduct_ShouldReturnCorrectProduct(string name,
           string categoryName,
           int quantity,
           decimal price,
           double volume,
           string maker)
        {
            var mockedProduct = new Mock<Product>();

            var factory = new Mock<IProductFactory>();
            factory.Setup(f => f.CreateProduct(It.IsAny<string>(),
                    It.IsAny<Category>(),
                    It.IsAny<int>(),
                    It.IsAny<decimal>(),
                    It.IsAny<double>(),
                    It.IsAny<string>()))
                .Returns(mockedProduct.Object);

            var repository = new Mock<IRepository<Product>>();
            var categoryService = new Mock<ICategoryService>();
            categoryService.Setup(x => x.GetCategoryByName(It.IsAny<string>())).Returns(It.IsAny<Category>());

            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            var result = service.CreateProduct(name, categoryName, quantity, price, volume, maker);

            Assert.AreSame(mockedProduct.Object, result);
        }
    }
}
