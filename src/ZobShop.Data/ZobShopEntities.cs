using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using ZobShop.Models;

namespace ZobShop.Data
{
    public class ZobShopEntities : IdentityDbContext<User>
    {
        public ZobShopEntities()
            : base("ZobShopDb", throwIfV1Schema: false)
        {
        }

        public static ZobShopEntities Create()
        {
            return new ZobShopEntities();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<ProductRating> ProductRatings { get; set; }

        public DbSet<Review> Reviews { get; set; }
    }
}
