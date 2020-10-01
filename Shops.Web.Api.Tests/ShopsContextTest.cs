using Microsoft.EntityFrameworkCore;
using Shops.Web.Api.Context;
using Shops.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shops.Web.Api.Tests
{
    public class ShopsContextTest
    {
        protected ShopsContextTest(DbContextOptions<ShopsContext> contextOptions)
        {
            ContextOptions = contextOptions;
            Seed();
        }
        protected DbContextOptions<ShopsContext> ContextOptions { get; }

        private void Seed()
        {
            using (var context = new ShopsContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var shop = new Shop()
                {
                    Id = Guid.NewGuid(),
                    Name = "Aldi",
                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            Name ="pomme",
                            Price = 5
                        }
                    }
                };

                context.AddRange(shop);

                context.SaveChanges();
            }
        }
    }
}
