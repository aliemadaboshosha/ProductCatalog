using a_product_catalog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace a_product_catalog.Data
{
    public class ProductDbContext:IdentityDbContext<IdentityUser>
    {
        public virtual DbSet<Product> Products { get; set; }
        public ProductDbContext(DbContextOptions<ProductDbContext>options):base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = Guid.NewGuid().ToString(),
                Name="Admin",
                NormalizedName="admin",
                ConcurrencyStamp=Guid.NewGuid().ToString()},
                new IdentityRole() {
                    Id = Guid.NewGuid().ToString(),
                    Name = "StockWorker",
                    NormalizedName = "worker",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole() {
                    Id = Guid.NewGuid().ToString(),
                    Name = "NormalUser",
                    NormalizedName = "User",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
                ) ;
            base.OnModelCreating(builder);
        }


    }
}
