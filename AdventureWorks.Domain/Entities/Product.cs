namespace AdventureWorks.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public decimal? ListPrice { get; set; }

        public int? ProductSubcategoryID { get; set; }
        public ProductSubcategory ProductSubcategory { get; set; }
    }
}