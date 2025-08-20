using Microsoft.EntityFrameworkCore;
using ShopDb.Models;

namespace ShopDb
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Liked> Liked { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new List<Product>
            {
                new Product("2f62ae97-69db-4cfa-9094-a68398360bd5", "Name", 10, "Desc1", "/images/jinx.png"),
                new Product("7d49957c-b2a2-442d-93e0-706467f5ac4f", "Name", 10, "Desc1", "/images/jinx.png"),
                new Product("a5c9c924-db14-4677-bd38-211ae80a01c1","Name", 10, "Desc1", "/images/jinx.png"),
                new Product("e7d0492a-b54e-4bc8-9e0c-5b3d119e28f7", "Name", 10, "Desc1", "/images/jinx.png"),
                new Product("ea17a73a-5300-45a7-8a4e-3ab7e63b8a5b", "Name", 10, "Desc1", "/images/jinx.png"),
            });
        }
    }
}
