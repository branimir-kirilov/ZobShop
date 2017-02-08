using System;
using System.Data.Entity;
using Moq;
using NUnit.Framework;
using ZobShop.Data;
using ZobShop.Models;
using ZobShop.Tests.Data.RepositoryTests.Fakes;

namespace ZobShop.Tests.Data.RepositoryTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassDbContextNull_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => new GenericRepository<Product>(null));
        }

        [Test]
        public void TestConstructor_PassDbContext_ShouldSetPropertyCorrectly()
        {
            var dbContext = new Mock<DbContext>();

            var repository = new FakeGenericRepository<Product>(dbContext.Object);

            Assert.AreSame(dbContext.Object, repository.DbContext);
        }

        [Test]
        public void TestConstructor_PassDbContext_ShouldCallDbSet()
        {
            var dbContext = new Mock<DbContext>();

            var repository = new FakeGenericRepository<Product>(dbContext.Object);

            Assert.AreSame(dbContext.Object.Set<Product>(), repository.DbSet);
        }

        [Test]
        public void TestConstructor_PassCorectData_ShouldNotThrow()
        {
            var dbContext = new Mock<DbContext>();

            Assert.DoesNotThrow(() => new GenericRepository<Product>(dbContext.Object));
        }
    }
}
