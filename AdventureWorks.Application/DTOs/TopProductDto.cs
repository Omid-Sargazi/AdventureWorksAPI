namespace AdventureWorks.Application.DTOs
{
    public class TopProductDto
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int TotalQuantitySold { get; set; }
        public decimal TotalSales { get; set; }
    }
}