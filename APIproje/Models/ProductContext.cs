using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIproje.Models
{
    public class ProductContext: IdentityDbContext<AppUser,AppRole,int>
    {
        public ProductContext(DbContextOptions<ProductContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 1, ProductName="Test", IsActive = true, Price=500 });
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 2, ProductName="Test 2", IsActive = true, Price=600 });
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 3, ProductName="Test 3", IsActive = true, Price=700 });
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 4, ProductName="Test 4", IsActive = true, Price=800 });
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 5, ProductName="Test 5", IsActive = true, Price=900 });
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 6, ProductName="Test 6", IsActive = true, Price=1000 });
        }

        public DbSet<Product> Products { get; set; }

    }
}
