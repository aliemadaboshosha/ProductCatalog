using a_product_catalog.Models;
using Microsoft.EntityFrameworkCore;

namespace a_product_catalog.Data
{
    public class ProductDbContext:DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public ProductDbContext(DbContextOptions<ProductDbContext>options):base(options) { }



        
        
    }
}
