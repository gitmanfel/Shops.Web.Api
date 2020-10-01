using Microsoft.EntityFrameworkCore;
using Shops.Web.Api.Models;

namespace Shops.Web.Api.Context
{
    public class ShopsContext : DbContext
    {
        public ShopsContext(DbContextOptions<ShopsContext> options)
          : base(options)
        {
        }


        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasOne(p => p.Shop)
            .WithMany(b => b.Products);

            modelBuilder.Entity<Shop>()
            .HasMany(p => p.Products)
            .WithOne(b => b.Shop);
        }
    }
}
