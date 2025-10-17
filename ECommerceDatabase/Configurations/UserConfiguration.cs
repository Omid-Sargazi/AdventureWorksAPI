using ECommerceDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceDatabase.Configurations
{
    public enum ProductStatus
    {
        Draft = 0,
        Active = 1,
        Inactive = 2,
        Discontinued = 3
    }
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email)
            .HasMaxLength(255)
            .IsRequired();

            builder.HasIndex(u => u.Email)
            .IsUnique();

            builder.HasMany(u => u.Addresses)
            .WithOne(a => a.User)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.UserRoles)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId);
        }


    }

    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(r => r.Name).HasMaxLength(100)
            .IsRequired();
            builder.HasIndex(r => r.Name).IsUnique();
        }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = default;

        public int? ParentId { get; set; }
        public Category? Parent { get; set; }
        public ICollection<Category> Children { get; set; } = new List<Category>();

        //Navigation
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }

    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; } = default;
        public string ContactEmail { get; set; } = default!;
        public string Phone { get; set; } = default!;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }

    public class Inventory
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public int Reserved { get; set; }
        public int Available => Quantity - Reserved;
        public string WarehouseLocation { get; set; } = default;

    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string SKU { get; set; } = default!; // Stock Keeping Unit
        public decimal Price { get; set; }
        public ProductStatus Status { get; set; } // Enum
        public string Description { get; set; } = default!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
         
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = default!;
          
        public Inventory Inventory { get; set; } = default!;
    }
}