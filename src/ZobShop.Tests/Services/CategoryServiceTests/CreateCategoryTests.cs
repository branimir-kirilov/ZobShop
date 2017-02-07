using System;
using Moq;
using NUnit.Framework;
using ZobShop.Data.Contracts;
using ZobShop.Factories;
using ZobShop.Models;
using ZobShop.Services;

namespace ZobShop.Tests.Services.CategoryServiceTests
{
    [TestFixture]
    public class CreateCategoryTests
    {
        [Test]
        public void TestCreateCategory_PassNull_ShouldThrowArgumentNullException()
        {
            var factory = new Mock<ICategoryFactory>();
            var repository = new Mock<IRepository<Category>>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new CategoryService(repository.Object, unitOfWork.Object, factory.Object);

            Assert.Throws<ArgumentNullException>(() => service.CreateCategory(null));
        }

        [TestCase("TestCategoryName")]
        public void TestCreateCategory_PassValidName_ShouldCallFactoryCreateCategory(string name)
        {
            var factory = new Mock<ICategoryFactory>();
            var repository = new Mock<IRepository<Category>>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new CategoryService(repository.Object, unitOfWork.Object, factory.Object);

            service.CreateCategory(name);

            factory.Verify(x => x.CreateCategory(name), Times.Once);
        }

        [TestCase("TestCategoryName")]
        public void TestCreateCategory_PassValidName_ShouldCallRepositoryAddCorrectly(string name)
        {
            var mockedCategory = new Mock<Category>();

            var factory = new Mock<ICategoryFactory>();
            factory.Setup(x => x.CreateCategory(It.IsAny<string>())).Returns(mockedCategory.Object);

            var repository = new Mock<IRepository<Category>>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new CategoryService(repository.Object, unitOfWork.Object, factory.Object);

            service.CreateCategory(name);

            repository.Verify(x => x.Add(mockedCategory.Object), Times.Once);
        }

        [TestCase("TestCategoryName")]
        public void TestCreateCategory_PassValidName_ShouldCallUnitOfWorkCommit(string name)
        {
            var mockedCategory = new Mock<Category>();

            var factory = new Mock<ICategoryFactory>();
            factory.Setup(x => x.CreateCategory(It.IsAny<string>())).Returns(mockedCategory.Object);

            var repository = new Mock<IRepository<Category>>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new CategoryService(repository.Object, unitOfWork.Object, factory.Object);

            service.CreateCategory(name);

            unitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [TestCase("TestCategoryName")]
        public void TestCreateCategory_PassValidName_ShouldReturnCorrectly(string name)
        {
            var mockedCategory = new Mock<Category>();

            var factory = new Mock<ICategoryFactory>();
            factory.Setup(x => x.CreateCategory(It.IsAny<string>())).Returns(mockedCategory.Object);

            var repository = new Mock<IRepository<Category>>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var service = new CategoryService(repository.Object, unitOfWork.Object, factory.Object);

            var result = service.CreateCategory(name);

            Assert.AreSame(mockedCategory.Object, result);
        }
    }
}
