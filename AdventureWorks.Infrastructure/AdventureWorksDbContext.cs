using AdventureWorks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Infrastructure
{
    public class AdventureWorksDbContext : DbContext
    {
        public AdventureWorksDbContext(DbContextOptions<AdventureWorksDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product", schema: "Production");
            modelBuilder.Entity<ProductSubcategory>().ToTable("ProductSubcategory", "Production");

            modelBuilder.Entity<Product>()
            .HasOne(p => p.ProductSubcategory)
            .WithMany(s => s.Products)
            .HasForeignKey(p => p.ProductSubcategoryID);
        }
    }
}