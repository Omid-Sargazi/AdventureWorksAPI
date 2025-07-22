namespace AdventureWorks.Domain.Entities
{
    public class ProductSubcategory
    {
        public int ProductSubcategoryID { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}