using System.Data.Entity;
using Moq;
using NUnit.Framework;
using ZobShop.Data;

namespace ZobShop.Tests.Data.UnitOfWorkTests
{
    [TestFixture]
    public class CommitTests
    {
        [Test]
        public void TestCommit_ShouldCallDbContextSaveChanges()
        {
            var dbContext = new Mock<DbContext>();

            var unitOfWork = new UnitOfWork(dbContext.Object);

            unitOfWork.Commit();

            dbContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
