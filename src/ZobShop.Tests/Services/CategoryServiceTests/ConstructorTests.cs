using System;
using Moq;
using NUnit.Framework;
using ZobShop.Data.Contracts;
using ZobShop.Factories;
using ZobShop.Models;
using ZobShop.Services;
using ZobShop.Services.Contracts;

namespace ZobShop.Tests.Services.CategoryServiceTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassRepositoryNull_ShouldThrowArgumentNullException()
        {
            var factory = new Mock<ICategoryFactory>();
            var unitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentNullException>(
                    () =>
                        new CategoryService(null, unitOfWork.Object, factory.Object));
        }

        [Test]
        public void TestConstructor_PassFactoryNull_ShouldThrowArgumentNullException()
        {
            var repository = new Mock<IRepository<Category>>();
            var unitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentNullException>(
                    () =>
                       new CategoryService(repository.Object, unitOfWork.Object, null));
        }

        [Test]
        public void TestConstructor_PassUnitOfWorkNull_ShouldThrowArgumentNullException()
        {
            var factory = new Mock<ICategoryFactory>();
            var repository = new Mock<IRepository<Category>>();

            Assert.Throws<ArgumentNullException>(
                () =>
                        new CategoryService(repository.Object, null, factory.Object));
        }

        [Test]
        public void TestConstructor_PassEverythingCorrect_ShouldNotThrow()
        {
            var factory = new Mock<ICategoryFactory>();
            var repository = new Mock<IRepository<Category>>();
            var unitOfWork = new Mock<IUnitOfWork>();

            Assert.DoesNotThrow(() => new CategoryService(repository.Object, unitOfWork.Object, factory.Object));
        }
    }
}
