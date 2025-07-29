namespace AdventureWorks.Domain.Entities
{
    public class SalesOrderHeader
    {
        public int SalesOderID { get; set; }
        public int CustomerID { get; set; }

        public decimal TotalDue { get; set; }
        public DateTime OrderDate { get; set; }

        public Customer Customer { get; set; }
    }
}