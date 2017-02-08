using System.Data.Entity;
using Moq;
using NUnit.Framework;
using ZobShop.Data;
using ZobShop.Models;

namespace ZobShop.Tests.Data.RepositoryTests
{
    [TestFixture]
    public class EntitiesTests
    {
        [Test]
        public void TestEntities_ShouldCallDbContextSet()
        {
            var mockedContext = new Mock<DbContext>();

            var repository = new GenericRepository<Product>(mockedContext.Object);

            var result = repository.Entities;

            mockedContext.Verify(x => x.Set<Product>());
        }

        [Test]
        public void TestEntities_ShouldReturnDbContextSet()
        {
            var setMock = new Mock<DbSet<Product>>();

            var dbContext = new Mock<DbContext>();
            dbContext.Setup(x => x.Set<Product>()).Returns(setMock.Object);

            var repository = new GenericRepository<Product>(dbContext.Object);

            var result = repository.Entities;

            Assert.AreSame(setMock.Object, result);
        }
    }
}
