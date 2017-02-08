using System;
using System.Data.Entity;
using Moq;
using NUnit.Framework;
using ZobShop.Data;

namespace ZobShop.Tests.Data.UnitOfWorkTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassDbContextNull_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => new UnitOfWork(null));
        }

        [Test]
        public void TestConstructor_PassDbContext_ShouldNotThrow()
        {
            var dbContext = new Mock<DbContext>();

            Assert.DoesNotThrow(() => new UnitOfWork(dbContext.Object));
        }
    }
}
