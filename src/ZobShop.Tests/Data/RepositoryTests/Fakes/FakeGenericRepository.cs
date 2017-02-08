using System.Data.Entity;
using ZobShop.Data;

namespace ZobShop.Tests.Data.RepositoryTests.Fakes
{
    public class FakeGenericRepository<T> : GenericRepository<T>
        where T : class
    {
        public FakeGenericRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public DbContext DbContext
        {
            get { return this.Context; }
        }

        public IDbSet<T> DbSet
        {
            get { return this.Set; }
        }
    }
}
