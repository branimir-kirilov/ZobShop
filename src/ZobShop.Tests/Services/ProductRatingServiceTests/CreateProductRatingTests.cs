using Moq;
using NUnit.Framework;
using ZobShop.Data.Contracts;
using ZobShop.Factories;
using ZobShop.Models;
using ZobShop.Services;

namespace ZobShop.Tests.Services.ProductRatingServiceTests
{
    [TestFixture]
    public class CreateProductRatingTests
    {
        [TestCase(1, "test", 1, "abcd")]
        [TestCase(12, "tests", 31, "abcd-bcda")]
        public void TestCreateProductRating_ShouldCallProductRepositoryGetByIdCorrectly(int rating,
            string content,
            int productId,
            string userId)
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

            service.CreateProductRating(rating, content, productId, userId);

            mockedProductRepository.Verify(x => x.GetById(productId), Times.Once);
        }

        [TestCase(1, "test", 1, "abcd")]
        [TestCase(12, "tests", 31, "abcd-bcda")]
        public void TestCreateProductRating_ShouldCallUserRepositoryGetByIdCorrectly(int rating,
           string content,
           int productId,
           string userId)
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

            service.CreateProductRating(rating, content, productId, userId);

            mockedUserRepository.Verify(x => x.GetById(userId), Times.Once);
        }

        [TestCase(1, "test", 1, "abcd")]
        [TestCase(12, "tests", 31, "abcd-bcda")]
        public void TestCreateProductRating_ShouldFactoryCreateCorrectly(int rating,
           string content,
           int productId,
           string userId)
        {
            var mockedUser = new Mock<User>();

            var mockedUserRepository = new Mock<IRepository<User>>();
            mockedUserRepository.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);

            var mockedProduct = new Mock<Product>();

            var mockedProductRepository = new Mock<IRepository<Product>>();
            mockedProductRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedProduct.Object);

            var mockedProductRatingRepository = new Mock<IRepository<ProductRating>>();
            var mockedFactory = new Mock<IProductRatingFactory>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new ProductRatingService(mockedUserRepository.Object,
                mockedProductRepository.Object,
                mockedProductRatingRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            service.CreateProductRating(rating, content, productId, userId);

            mockedFactory.Verify(x => x.CreateProductRating(rating, content, mockedProduct.Object, mockedUser.Object));
        }

        [TestCase(1, "test", 1, "abcd")]
        [TestCase(12, "tests", 31, "abcd-bcda")]
        public void TestCreateProductRating_ShouldCallProductRatingRepositoryAddCorrectly(int rating,
           string content,
           int productId,
           string userId)
        {
            var mockedUser = new Mock<User>();

            var mockedUserRepository = new Mock<IRepository<User>>();
            mockedUserRepository.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);

            var mockedProduct = new Mock<Product>();

            var mockedProductRepository = new Mock<IRepository<Product>>();
            mockedProductRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedProduct.Object);

            var mockedProductRatingRepository = new Mock<IRepository<ProductRating>>();

            var mockedRating = new Mock<ProductRating>();

            var mockedFactory = new Mock<IProductRatingFactory>();
            mockedFactory.Setup(
                    x =>
                        x.CreateProductRating(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<Product>(),
                            It.IsAny<User>()))
                .Returns(mockedRating.Object);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new ProductRatingService(mockedUserRepository.Object,
                mockedProductRepository.Object,
                mockedProductRatingRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            service.CreateProductRating(rating, content, productId, userId);

            mockedProductRatingRepository.Verify(x => x.Add(mockedRating.Object), Times.Once);
        }

        [TestCase(12, "tests", 31, "abcd-bcda")]
        public void TestCreateProductRating_ShouldCallUnitOfWorkCommitCorrectly(int rating,
           string content,
           int productId,
           string userId)
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

            service.CreateProductRating(rating, content, productId, userId);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [TestCase(1, "test", 1, "abcd")]
        [TestCase(12, "tests", 31, "abcd-bcda")]
        public void TestCreateProductRating_ShouldReturnMockedProductRating(int rating,
          string content,
          int productId,
          string userId)
        {
            var mockedUser = new Mock<User>();

            var mockedUserRepository = new Mock<IRepository<User>>();
            mockedUserRepository.Setup(x => x.GetById(It.IsAny<string>())).Returns(mockedUser.Object);

            var mockedProduct = new Mock<Product>();

            var mockedProductRepository = new Mock<IRepository<Product>>();
            mockedProductRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedProduct.Object);

            var mockedProductRatingRepository = new Mock<IRepository<ProductRating>>();

            var mockedRating = new Mock<ProductRating>();

            var mockedFactory = new Mock<IProductRatingFactory>();
            mockedFactory.Setup(
                    x =>
                        x.CreateProductRating(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<Product>(),
                            It.IsAny<User>()))
                .Returns(mockedRating.Object);

            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new ProductRatingService(mockedUserRepository.Object,
                mockedProductRepository.Object,
                mockedProductRatingRepository.Object,
                mockedUnitOfWork.Object,
                mockedFactory.Object);

            var result = service.CreateProductRating(rating, content, productId, userId);

            Assert.AreSame(mockedRating.Object, result);
        }
    }
}
