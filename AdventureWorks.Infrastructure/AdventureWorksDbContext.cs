using System.Security.Cryptography.X509Certificates;
using AdventureWorks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Infrastructure
{
    public class AdventureWorksDbContext : DbContext
    {
        public AdventureWorksDbContext(DbContextOptions<AdventureWorksDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product", schema: "Production");
            modelBuilder.Entity<ProductSubcategory>().ToTable("ProductSubcategory", "Production");

            modelBuilder.Entity<Product>()
            .HasOne(p => p.ProductSubcategory)
            .WithMany(s => s.Products)
            .HasForeignKey(p => p.ProductSubcategoryID);

            modelBuilder.Entity<SalesOrderDetail>()
            .ToTable("SalesOrderDetail", "Sales")
            .HasKey(x => new { x.SalesOrderID, x.SalesOrderDetailID });

            modelBuilder.Entity<SalesOrderDetail>()
            .Property(x => x.LineTotal)
            .HasColumnType("money");

            modelBuilder.Entity<SalesOrderDetail>()
            .Property(x => x.UnitPrice)
            .HasColumnName("money");

            modelBuilder.Entity<SalesOrderDetail>()
            .HasOne(x => x.Product)
            .WithMany(p => p.SalesOrderDetails)
            .HasForeignKey(x => x.ProductID);
        }
    }
}