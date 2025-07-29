namespace AdventureWorks.Application.DTOs
{
    public class TopCustomerDto
    {
        public int CustomerID { get; set; }
        public string FullName { get; set; }
        public decimal TotalSales { get; set; }
        public int OrderCount { get; set; }
    }
}