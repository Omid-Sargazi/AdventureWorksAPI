namespace AdventureWorks.Domain.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }       // Primary Key
        public int? PersonID { get; set; }

        public Person Person { get; set; }
        public ICollection<SalesOrderHeader> SalesOrders { get; set; }
    }
}