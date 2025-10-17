using Microsoft.AspNetCore.Http.HttpResults;

namespace ECommerceDatabase.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = default;

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();


    }

    public class UserRole
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public AddressType Type { get; set; } // Enum: Billing, Shipping, etc.
    }

    public enum AddressType

    {
        Billing = 1,
        Shipping = 2,
        Office=3
    };

}