using System.Data.Entity;
using Moq;
using NUnit.Framework;
using ZobShop.Data;

namespace ZobShop.Tests.Data.UnitOfWorkTests
{
    [TestFixture]
    public class DisposeTests
    {
        [Test]
        public void TestDispose_ShouldNotThrow()
        {
            var dbContext = new Mock<DbContext>();

            var unitOfWork = new UnitOfWork(dbContext.Object);

            Assert.DoesNotThrow(() => unitOfWork.Dispose());
        }
    }
}
