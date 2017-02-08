using System.Data.Entity;
using Moq;
using NUnit.Framework;
using ZobShop.Data;
using ZobShop.Models;

namespace ZobShop.Tests.Data.RepositoryTests
{
    [TestFixture]
    public class GetByIdTests
    {
        [TestCase(1)]
        [TestCase(12)]
        public void TestGetById_ShouldCallDbContextFind(int id)
        {
            var setMock = new Mock<DbSet<Product>>();

            var dbContext = new Mock<DbContext>();
            dbContext.Setup(x => x.Set<Product>()).Returns(setMock.Object);

            var repository = new GenericRepository<Product>(dbContext.Object);
            repository.GetById(id);

            setMock.Verify(x => x.Find(id), Times.Once);
        }
    }
}
