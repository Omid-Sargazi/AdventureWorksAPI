namespace LinqProblems.Problems3
{
    public class ManageSupermarket
    {
        public void  Ececute()
        {
            
        }
    }

    ublic class GroceryItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; } // "Dairy", "Vegetables", "Meat", "Snacks"
    public decimal? UsualPrice { get; set; }
    public string Unit { get; set; } // "kg", "piece", "liter"
    public bool IsEssential { get; set; }
}

public class ShoppingList
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public int Quantity { get; set; }
    public bool IsPurchased { get; set; }
    public DateTime ListDate { get; set; }
    public int Priority { get; set; } // 1-3 (3 is highest)
}

public class Store
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
}

public class StorePrice
{
    public int Id { get; set; }
    public int StoreId { get; set; }
    public int ItemId { get; set; }
    public decimal Price { get; set; }
    public DateTime UpdatedDate { get; set; }
}

public class Purchase
{
    public int Id { get; set; }
    public int StoreId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string PaymentMethod { get; set; }
}

public class PurchaseItem
{
    public int Id { get; set; }
    public int PurchaseId { get; set; }
    public int ItemId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
}