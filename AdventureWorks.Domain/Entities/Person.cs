namespace AdventureWorks.Domain.Entities
{
    public class Person
    {
        public int BusinessEntityID { get; set; } // Primary Key
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}