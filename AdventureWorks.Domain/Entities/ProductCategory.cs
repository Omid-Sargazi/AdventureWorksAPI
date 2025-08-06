namespace AdventureWorks.Domain.Entities
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }


        public ICollection<ProductSubcategory> ProductSubcategories { get; set; }
    }
}