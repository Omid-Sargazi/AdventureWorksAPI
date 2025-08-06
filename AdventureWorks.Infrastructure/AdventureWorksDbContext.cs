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
        public DbSet<Person> Persons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
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
            .HasColumnType("money");

            modelBuilder.Entity<SalesOrderDetail>()
            .HasOne(x => x.Product)
            .WithMany(p => p.SalesOrderDetails)
            .HasForeignKey(x => x.ProductID);

            modelBuilder.Entity<Person>()
            .ToTable("Person", "Person")
            .HasKey(p => p.BusinessEntityID);

            modelBuilder.Entity<Person>()
            .Property(p => p.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Person>()
            .Property(p => p.LastName).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<Customer>()
            .ToTable("Customer", "Sales")
            .HasKey(c => c.CustomerID);

            modelBuilder.Entity<Customer>()
            .HasOne(c => c.Person)
            .WithMany(p => p.Customers)
            .HasForeignKey(c => c.PersonID)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SalesOrderHeader>()
            .ToTable("SalesOrderHeader", "Sales")
            .HasKey(s => s.SalesOderID);

            modelBuilder.Entity<SalesOrderHeader>()
             .Property(s => s.TotalDue).HasColumnType("money");

            modelBuilder.Entity<SalesOrderHeader>()
            .HasOne(s => s.Customer)
            .WithMany(c => c.SalesOrders)
            .HasForeignKey(s => s.CustomerID);

            modelBuilder.Entity<ProductCategory>()
            .ToTable("ProductCategory", "Production")
            .HasKey(pc => pc.ProductCategoryId);

            modelBuilder.Entity<ProductCategory>()
            .Property(pc => pc.Name)
            .HasMaxLength(50).IsRequired();

            modelBuilder.Entity<ProductCategory>()
            .HasMany(pc => pc.ProductSubcategories)
            .WithOne(psc => psc.ProductCategory)
            .HasForeignKey(sc => sc.ProductCategoryId);
        }
    }
}