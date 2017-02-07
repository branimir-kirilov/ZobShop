using System;
using Moq;
using NUnit.Framework;
using ZobShop.Data.Contracts;
using ZobShop.Factories;
using ZobShop.Models;
using ZobShop.Services.Contracts;

namespace ZobShop.Tests.Services.ProductService
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassFactoryNull_ShouldThrowArgumentNullException()
        {
            var repository = new Mock<IRepository<Product>>();
            var service = new Mock<ICategoryService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentNullException>(
                    () =>
                        new ZobShop.Services.ProductService(null, repository.Object, service.Object,
                            unitOfWork.Object));
        }

        [Test]
        public void TestConstructor_PassRepositoryNull_ShouldThrowArgumentNullException()
        {
            var factory = new Mock<IProductFactory>();
            var service = new Mock<ICategoryService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentNullException>(
                    () =>
                        new ZobShop.Services.ProductService(factory.Object, null, service.Object,
                            unitOfWork.Object));
        }

        [Test]
        public void TestConstructor_PassServiceNull_ShouldThrowArgumentNullException()
        {
            var factory = new Mock<IProductFactory>();
            var repository = new Mock<IRepository<Product>>();
            var unitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentNullException>(
                    () =>
                        new ZobShop.Services.ProductService(factory.Object, repository.Object, null,
                            unitOfWork.Object));
        }

        [Test]
        public void TestConstructor_PassUnitOfWorkNull_ShouldThrowArgumentNullException()
        {
            var factory = new Mock<IProductFactory>();
            var repository = new Mock<IRepository<Product>>();
            var service = new Mock<ICategoryService>();

            Assert.Throws<ArgumentNullException>(
                    () =>
                        new ZobShop.Services.ProductService(factory.Object, repository.Object, service.Object,
                           null));
        }

        [Test]
        public void TestConstructor_PassEverything_ShouldNotThrow()
        {
            var factory = new Mock<IProductFactory>();
            var repository = new Mock<IRepository<Product>>();
            var service = new Mock<ICategoryService>();
            var unitOfWork = new Mock<IUnitOfWork>();

            Assert.DoesNotThrow(
                    () =>
                        new ZobShop.Services.ProductService(factory.Object, repository.Object, service.Object,
                           unitOfWork.Object));
        }
    }
}
