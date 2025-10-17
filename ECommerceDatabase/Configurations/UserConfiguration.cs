using ECommerceDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceDatabase.Configurations
{
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
}