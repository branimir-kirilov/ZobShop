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
        [TestCase("TestProduct", "TestCategoryName", 10, 5.00, 2.00, "TestMaker", ".jpg")]
        public void TestCreateProduct_ShouldCallCategoryServiceGetCategoryByNameWithCorrectValue(string name,
            string categoryName,
            int quantity,
            decimal price,
            double volume,
            string maker,
            string imageMimeType)
        {
            var factory = new Mock<IProductFactory>();
            var repository = new Mock<IRepository<Product>>();
            var categoryService = new Mock<ICategoryService>();
            categoryService.Setup(x => x.GetCategoryByName(It.IsAny<string>())).Returns(It.IsAny<Category>());

            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            var buffer = new byte[3];
            service.CreateProduct(name, categoryName, quantity, price, volume, maker, imageMimeType, buffer);

            categoryService.Verify(x => x.GetCategoryByName(categoryName), Times.Once);
        }

        [TestCase("TestProduct", "TestCategoryName", 10, 5.00, 2.00, "TestMaker", ".jpg")]
        public void TestCreateProduct_ServiceReturnsNull_ShouldCallCategoryServiceCreateCategoryWithCorrectValue(string name,
           string categoryName,
            int quantity,
            decimal price,
            double volume,
            string maker,
            string imageMimeType)
        {
            var factory = new Mock<IProductFactory>();
            var repository = new Mock<IRepository<Product>>();
            var categoryService = new Mock<ICategoryService>();
            categoryService.Setup(x => x.GetCategoryByName(It.IsAny<string>())).Returns(It.IsAny<Category>());

            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            var buffer = new byte[3];
            service.CreateProduct(name, categoryName, quantity, price, volume, maker, imageMimeType, buffer);

            categoryService.Verify(x => x.CreateCategory(categoryName), Times.Once);
        }

        [TestCase("TestProduct", "TestCategoryName", 10, 5.00, 2.00, "TestMaker", ".jpg")]
        public void TestCreateProduct_ShouldCallFactoryCreateProduct(string name,
            string categoryName,
            int quantity,
            decimal price,
            double volume,
            string maker,
            string imageMimeType)
        {
            var factory = new Mock<IProductFactory>();
            var repository = new Mock<IRepository<Product>>();
            var categoryService = new Mock<ICategoryService>();
            categoryService.Setup(x => x.GetCategoryByName(It.IsAny<string>())).Returns(It.IsAny<Category>());

            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            var buffer = new byte[3];
            service.CreateProduct(name, categoryName, quantity, price, volume, maker, imageMimeType, buffer);

            factory.Verify(x => x.CreateProduct(name, It.IsAny<Category>(), quantity, price, volume, maker, imageMimeType, buffer), Times.Once);
        }

        [TestCase("TestProduct", "TestCategoryName", 10, 5.00, 2.00, "TestMaker", ".jpg")]
        public void TestCreateProduct_ShouldCallRepositoryAdd(string name,
           string categoryName,
           int quantity,
           decimal price,
           double volume,
           string maker,
           string imageMimeType)
        {
            var mockedProduct = new Mock<Product>();

            var factory = new Mock<IProductFactory>();
            factory.Setup(f => f.CreateProduct(It.IsAny<string>(),
                    It.IsAny<Category>(),
                    It.IsAny<int>(),
                    It.IsAny<decimal>(),
                    It.IsAny<double>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<byte[]>()))
                .Returns(mockedProduct.Object);

            var repository = new Mock<IRepository<Product>>();
            var categoryService = new Mock<ICategoryService>();
            categoryService.Setup(x => x.GetCategoryByName(It.IsAny<string>())).Returns(It.IsAny<Category>());

            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            var buffer = new byte[2];
            service.CreateProduct(name, categoryName, quantity, price, volume, maker, imageMimeType, buffer);

            repository.Verify(x => x.Add(mockedProduct.Object), Times.Once);
        }

        [TestCase("TestProduct", "TestCategoryName", 10, 5.00, 2.00, "TestMaker", ".jpg")]
        public void TestCreateProduct_ShouldCallUnitOfWorkCommit(string name,
           string categoryName,
           int quantity,
           decimal price,
           double volume,
           string maker,
           string imageMimeType)
        {
            var mockedProduct = new Mock<Product>();

            var factory = new Mock<IProductFactory>();
            factory.Setup(f => f.CreateProduct(It.IsAny<string>(),
                    It.IsAny<Category>(),
                    It.IsAny<int>(),
                    It.IsAny<decimal>(),
                    It.IsAny<double>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<byte[]>()))
                .Returns(mockedProduct.Object);

            var repository = new Mock<IRepository<Product>>();
            var categoryService = new Mock<ICategoryService>();
            categoryService.Setup(x => x.GetCategoryByName(It.IsAny<string>())).Returns(It.IsAny<Category>());

            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            var buffer = new byte[2];
            service.CreateProduct(name, categoryName, quantity, price, volume, maker, imageMimeType, buffer);

            unitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [TestCase("TestProduct", "TestCategoryName", 10, 5.00, 2.00, "TestMaker", ".jpg")]
        public void TestCreateProduct_ShouldReturnCorrectProduct(string name,
           string categoryName,
           int quantity,
           decimal price,
           double volume,
           string maker,
           string imageMimeType)
        {
            var mockedProduct = new Mock<Product>();

            var factory = new Mock<IProductFactory>();
            factory.Setup(f => f.CreateProduct(It.IsAny<string>(),
                    It.IsAny<Category>(),
                    It.IsAny<int>(),
                    It.IsAny<decimal>(),
                    It.IsAny<double>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<byte[]>()))
                .Returns(mockedProduct.Object);

            var repository = new Mock<IRepository<Product>>();
            var categoryService = new Mock<ICategoryService>();
            categoryService.Setup(x => x.GetCategoryByName(It.IsAny<string>())).Returns(It.IsAny<Category>());

            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new ZobShop.Services.ProductService(factory.Object, repository.Object, categoryService.Object, unitOfWork.Object);

            var buffer = new byte[2];
            var result = service.CreateProduct(name, categoryName, quantity, price, volume, maker, imageMimeType, buffer);

            Assert.AreSame(mockedProduct.Object, result);
        }
    }
}
