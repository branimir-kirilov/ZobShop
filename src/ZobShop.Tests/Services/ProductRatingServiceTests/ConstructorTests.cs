using System;
using Moq;
using NUnit.Framework;
using ZobShop.Data.Contracts;
using ZobShop.Factories;
using ZobShop.Models;
using ZobShop.Services;

namespace ZobShop.Tests.Services.ProductRatingServiceTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassUserRepositoryNull_ShouldThrowArgumentNullException()
        {
            var mockedProductRepository = new Mock<IRepository<Product>>();
            var mockedProductRatingRepository = new Mock<IRepository<ProductRating>>();
            var mockedFactory = new Mock<IProductRatingFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentNullException>(() => new ProductRatingService(null,
                mockedProductRepository.Object,
                mockedProductRatingRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object));
        }

        [Test]
        public void TestConstructor_PassProductRepositoryNull_ShouldThrowArgumentNullException()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedProductRatingRepository = new Mock<IRepository<ProductRating>>();
            var mockedFactory = new Mock<IProductRatingFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentNullException>(() => new ProductRatingService(mockedUserRepository.Object,
                null,
                mockedProductRatingRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object));
        }

        [Test]
        public void TestConstructor_PassProductRatingRepositoryNull_ShouldThrowArgumentNullException()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedProductRepository = new Mock<IRepository<Product>>();
            var mockedFactory = new Mock<IProductRatingFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentNullException>(() => new ProductRatingService(mockedUserRepository.Object,
                mockedProductRepository.Object,
                null,
                mockedUnitOfWork.Object,
                mockedFactory.Object));
        }

        [Test]
        public void TestConstructor_PassFactoryNull_ShouldThrowArgumentNullException()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedProductRepository = new Mock<IRepository<Product>>();
            var mockedProductRatingRepository = new Mock<IRepository<ProductRating>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.Throws<ArgumentNullException>(() => new ProductRatingService(mockedUserRepository.Object,
                mockedProductRepository.Object,
                mockedProductRatingRepository.Object,
                mockedUnitOfWork.Object,
                null));
        }

        [Test]
        public void TestConstructor_PassUnitOfWorkRepositoryNull_ShouldThrowArgumentNullException()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedProductRepository = new Mock<IRepository<Product>>();
            var mockedProductRatingRepository = new Mock<IRepository<ProductRating>>();
            var mockedFactory = new Mock<IProductRatingFactory>();

            Assert.Throws<ArgumentNullException>(() => new ProductRatingService(mockedUserRepository.Object,
                mockedProductRepository.Object,
                mockedProductRatingRepository.Object,
                null,
                mockedFactory.Object));
        }

        [Test]
        public void TestConstructor_ShouldInitialiseCorrectly()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedProductRepository = new Mock<IRepository<Product>>();
            var mockedProductRatingRepository = new Mock<IRepository<ProductRating>>();
            var mockedFactory = new Mock<IProductRatingFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new ProductRatingService(mockedUserRepository.Object,
                mockedProductRepository.Object,
                mockedProductRatingRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            Assert.IsNotNull(service);
        }

        [Test]
        public void TestConstructor_ShouldNotThrow()
        {
            var mockedUserRepository = new Mock<IRepository<User>>();
            var mockedProductRepository = new Mock<IRepository<Product>>();
            var mockedProductRatingRepository = new Mock<IRepository<ProductRating>>();
            var mockedFactory = new Mock<IProductRatingFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            Assert.DoesNotThrow(() => new ProductRatingService(mockedUserRepository.Object,
                mockedProductRepository.Object,
                mockedProductRatingRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object));
        }
    }
}
