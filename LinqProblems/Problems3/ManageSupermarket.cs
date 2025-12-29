namespace LinqProblems.Problems3
{
    public class ManageSupermarket
    {
        public void  Ececute()
        {
              var groceryItems = new List<GroceryItem>
        {
            new GroceryItem { Id = 1, Name = "Milk", Category = "Dairy", 
                            UsualPrice = 45000, Unit = "liter", IsEssential = true },
            new GroceryItem { Id = 2, Name = "Bread", Category = "Bakery", 
                            UsualPrice = 25000, Unit = "piece", IsEssential = true },
            new GroceryItem { Id = 3, Name = "Eggs", Category = "Dairy", 
                            UsualPrice = 180000, Unit = "dozen", IsEssential = true },
            new GroceryItem { Id = 4, Name = "Tomatoes", Category = "Vegetables", 
                            UsualPrice = 80000, Unit = "kg", IsEssential = true },
            new GroceryItem { Id = 5, Name = "Chicken", Category = "Meat", 
                            UsualPrice = 350000, Unit = "kg", IsEssential = true },
            new GroceryItem { Id = 6, Name = "Rice", Category = "Grains", 
                            UsualPrice = 220000, Unit = "kg", IsEssential = true },
            new GroceryItem { Id = 7, Name = "Potatoes", Category = "Vegetables", 
                            UsualPrice = 60000, Unit = "kg", IsEssential = true },
            new GroceryItem { Id = 8, Name = "Chips", Category = "Snacks", 
                            UsualPrice = 75000, Unit = "piece", IsEssential = false },
            new GroceryItem { Id = 9, Name = "Yogurt", Category = "Dairy", 
                            UsualPrice = 55000, Unit = "piece", IsEssential = true }
        };

        // فروشگاه‌ها
        var stores = new List<Store>
        {
            new Store { Id = 1, Name = "Hyperstar", Location = "City Center" },
            new Store { Id = 2, Name = "Refah", Location = "North Area" },
            new Store { Id = 3, Name = "Shahrvand", Location = "West Area" }
        };

        // قیمت‌های فروشگاه‌ها
        var storePrices = new List<StorePrice>
        {
            // Hyperstar prices
            new StorePrice { Id = 1, StoreId = 1, ItemId = 1, Price = 43000, UpdatedDate = DateTime.Now.AddDays(-1) },
            new StorePrice { Id = 2, StoreId = 1, ItemId = 2, Price = 24000, UpdatedDate = DateTime.Now.AddDays(-2) },
            new StorePrice { Id = 3, StoreId = 1, ItemId = 3, Price = 175000, UpdatedDate = DateTime.Now.AddDays(-1) },
            new StorePrice { Id = 4, StoreId = 1, ItemId = 4, Price = 75000, UpdatedDate = DateTime.Now.AddDays(-3) },
            
            // Refah prices
            new StorePrice { Id = 5, StoreId = 2, ItemId = 1, Price = 45000, UpdatedDate = DateTime.Now.AddDays(-2) },
            new StorePrice { Id = 6, StoreId = 2, ItemId = 2, Price = 26000, UpdatedDate = DateTime.Now.AddDays(-1) },
            new StorePrice { Id = 7, StoreId = 2, ItemId = 3, Price = 185000, UpdatedDate = DateTime.Now.AddDays(-2) },
            new StorePrice { Id = 8, StoreId = 2, ItemId = 4, Price = 85000, UpdatedDate = DateTime.Now.AddDays(-1) },
            
            // Shahrvand prices
            new StorePrice { Id = 9, StoreId = 3, ItemId = 1, Price = 42000, UpdatedDate = DateTime.Now.AddDays(-1) },
            new StorePrice { Id = 10, StoreId = 3, ItemId = 2, Price = 23000, UpdatedDate = DateTime.Now.AddDays(-3) },
            new StorePrice { Id = 11, StoreId = 3, ItemId = 3, Price = 170000, UpdatedDate = DateTime.Now.AddDays(-2) },
            new StorePrice { Id = 12, StoreId = 3, ItemId = 4, Price = 78000, UpdatedDate = DateTime.Now.AddDays(-1) }
        };
        
        var todayShoppingList = new List<ShoppingList>
        {
            new ShoppingList { Id = 1, ItemId = 1, Quantity = 2, IsPurchased = true, 
                             ListDate = DateTime.Today, Priority = 3 },
            new ShoppingList { Id = 2, ItemId = 2, Quantity = 1, IsPurchased = true, 
                             ListDate = DateTime.Today, Priority = 3 },
            new ShoppingList { Id = 3, ItemId = 3, Quantity = 1, IsPurchased = false, 
                             ListDate = DateTime.Today, Priority = 2 },
            new ShoppingList { Id = 4, ItemId = 4, Quantity = 2, IsPurchased = false, 
                             ListDate = DateTime.Today, Priority = 2 },
            new ShoppingList { Id = 5, ItemId = 5, Quantity = 1, IsPurchased = false, 
                             ListDate = DateTime.Today, Priority = 1 },
            new ShoppingList { Id = 6, ItemId = 8, Quantity = 1, IsPurchased = false, 
                             ListDate = DateTime.Today, Priority = 1 }
        };

        // خریدهای قبلی
        var purchases = new List<Purchase>
        {
            new Purchase { Id = 1, StoreId = 1, PurchaseDate = DateTime.Now.AddDays(-7), 
                         TotalAmount = 285000, PaymentMethod = "Card" },
            new Purchase { Id = 2, StoreId = 2, PurchaseDate = DateTime.Now.AddDays(-3), 
                         TotalAmount = 320000, PaymentMethod = "Cash" }
        };

        var purchaseItems = new List<PurchaseItem>
        {
            // Purchase 1 items
            new PurchaseItem { Id = 1, PurchaseId = 1, ItemId = 1, Quantity = 2, UnitPrice = 43000 },
            new PurchaseItem { Id = 2, PurchaseId = 1, ItemId = 2, Quantity = 1, UnitPrice = 24000 },
            new PurchaseItem { Id = 3, PurchaseId = 1, ItemId = 6, Quantity = 2, UnitPrice = 220000 },
            
            // Purchase 2 items
            new PurchaseItem { Id = 4, PurchaseId = 2, ItemId = 1, Quantity = 1, UnitPrice = 45000 },
            new PurchaseItem { Id = 5, PurchaseId = 2, ItemId = 3, Quantity = 1, UnitPrice = 185000 },
            new PurchaseItem { Id = 6, PurchaseId = 2, ItemId = 4, Quantity = 1, UnitPrice = 85000 }
        };

          Console.WriteLine("=== Today's Shopping List ===");
        
        var todayList = todayShoppingList
            .Where(sl => sl.ListDate.Date == DateTime.Today)
            .Select(sl => new
            {
                Item = groceryItems.First(i => i.Id == sl.ItemId),
                sl.Quantity,
                sl.IsPurchased,
                sl.Priority
            })
            .OrderByDescending(x => x.Priority)
            .ThenBy(x => x.Item.Category)
            .ToList();

        foreach (var item in todayList)
        {
            string status = item.IsPurchased ? "✅" : "📝";
            string priorityStars = new string('⭐', item.Priority);
            string essential = item.Item.IsEssential ? " (Essential)" : "";
            
            Console.WriteLine($"{status} {priorityStars} {item.Item.Name}");
            Console.WriteLine($"  Category: {item.Item.Category}, Quantity: {item.Quantity} {item.Item.Unit}{essential}");
            Console.WriteLine($"  Usual Price: {item.Item.UsualPrice?.ToString("C0") ?? "Unknown"}");
        }

          var purchasedItems = todayList
            .Where(x => x.IsPurchased)
            .ToList();

        var notPurchasedItems = todayList
            .Where(x => !x.IsPurchased)
            .ToList();

        Console.WriteLine($"\nPurchased: {purchasedItems.Count}/{todayList.Count} items");

        Console.WriteLine("\n=== Price Comparison ===");
        
        // برای آیتم‌های خریداری نشده، بهترین قیمت را پیدا کن
        foreach (var item in notPurchasedItems.Take(3)) // فقط 3 آیتم اول
        {
            var itemPrices = storePrices
                .Where(sp => sp.ItemId == item.Item.Id)
                .Select(sp => new
                {
                    Store = stores.First(s => s.Id == sp.StoreId).Name,
                    sp.Price,
                    DaysOld = (DateTime.Now - sp.UpdatedDate).Days
                })
                .OrderBy(p => p.Price)
                .ToList();

            if (itemPrices.Any())
            {
                Console.WriteLine($"\n{item.Item.Name}:");
                foreach (var price in itemPrices)
                {
                    string freshness = price.DaysOld <= 1 ? "🟢" : price.DaysOld <= 3 ? "🟡" : "🔴";
                    Console.WriteLine($"  {freshness} {price.Store}: {price.Price:C0} ({price.DaysOld} days old)");
                }
            }

            var weeklyPurchases = purchases
            .Where(p => p.PurchaseDate >= DateTime.Now.AddDays(-7))
            .Select(p => new
            {
                Store = stores.First(s => s.Id == p.StoreId).Name,
                p.PurchaseDate,
                p.TotalAmount,
                Items = purchaseItems
                    .Where(pi => pi.PurchaseId == p.Id)
                    .Select(pi => new
                    {
                        Item = groceryItems.First(i => i.Id == pi.ItemId).Name,
                        pi.Quantity,
                        pi.UnitPrice
                    })
                    .ToList()
            })
            .OrderByDescending(p => p.PurchaseDate)
            .ToList();

        Console.WriteLine("\n=== Weekly Purchases ===");
        foreach (var purchase in weeklyPurchases)
        {
            Console.WriteLine($"{purchase.PurchaseDate:MMM dd} at {purchase.Store}: {purchase.TotalAmount:C0}");
            Console.WriteLine("  Items:");
            foreach (var item in purchase.Items)
            {
                Console.WriteLine($"    - {item.Item}: {item.Quantity} × {item.UnitPrice:C0}");
            }
        }

         Console.WriteLine("\n=== Today's Purchase Estimate ===");
        
        var estimatedCost = notPurchasedItems
            .Sum(item => 
            {
                var minPrice = storePrices
                    .Where(sp => sp.ItemId == item.Item.Id)
                    .Min(sp => sp.Price);
                
                return (decimal?)minPrice * item.Quantity ?? 
                       item.Item.UsualPrice * item.Quantity ?? 0;
            });

        var essentialCost = notPurchasedItems
            .Where(item => item.Item.IsEssential)
            .Sum(item => 
            {
                var minPrice = storePrices
                    .Where(sp => sp.ItemId == item.Item.Id)
                    .Min(sp => sp.Price);
                
                return (decimal?)minPrice * item.Quantity ?? 
                       item.Item.UsualPrice * item.Quantity ?? 0;
            });

        Console.WriteLine($"Remaining items: {notPurchasedItems.Count}");
        Console.WriteLine($"Estimated total cost: {estimatedCost:C0}");
        Console.WriteLine($"Essential items cost: {essentialCost:C0}");
        
        if (notPurchasedItems.Any(item => !item.Item.IsEssential))
        {
            var nonEssentialCost = estimatedCost - essentialCost;
            Console.WriteLine($"Non-essential items cost: {nonEssentialCost:C0}");
            Console.WriteLine($"You can save {nonEssentialCost:C0} by skipping non-essentials!");
        }

         var itemsByCategory = todayList
            .GroupBy(x => x.Item.Category)
            .Select(g => new
            {
                Category = g.Key,
                ItemCount = g.Count(),
                PurchasedCount = g.Count(x => x.IsPurchased),
                TotalQuantity = g.Sum(x => x.Quantity),
                EstimatedCost = g.Sum(item => 
                {
                    var minPrice = storePrices
                        .Where(sp => sp.ItemId == item.Item.Id)
                        .Min(sp => sp.Price);
                    
                    return (decimal?)minPrice * item.Quantity ?? 
                           item.Item.UsualPrice * item.Quantity ?? 0;
                })
            })
            .OrderByDescending(c => c.ItemCount)
            .ToList();

        Console.WriteLine("\n=== Items by Category ===");
        foreach (var category in itemsByCategory)
        {
            string progress = $"{category.PurchasedCount}/{category.ItemCount}";
            Console.WriteLine($"{category.Category}: {progress} items");
            Console.WriteLine($"  Quantity: {category.TotalQuantity}, Est. Cost: {category.EstimatedCost:C0}");
        }

         Console.WriteLine("\n=== Shopping Recommendations ===");
        
        // آیتم‌های ضروری که موجود نیستند
        var missingEssentials = notPurchasedItems
            .Where(item => item.Item.IsEssential && item.Priority >= 2)
            .Select(item => item.Item.Name)
            .ToList();

        if (missingEssentials.Any())
        {
            Console.WriteLine("🚨 Must buy:");
            foreach (var item in missingEssentials)
            {
                Console.WriteLine($"  • {item}");
            }
        }

        // آیتم‌های غیرضروری که می‌توان حذف کرد
        var optionalItems = notPurchasedItems
            .Where(item => !item.Item.IsEssential)
            .Select(item => new
            {
                item.Item.Name,
                EstimatedPrice = storePrices
                    .Where(sp => sp.ItemId == item.Item.Id)
                    .Min(sp => sp.Price) * item.Quantity
            })
            .OrderByDescending(item => item.EstimatedPrice)
            .ToList();

        if (optionalItems.Any())
        {
            Console.WriteLine("\n💡 Consider skipping (to save money):");
            foreach (var item in optionalItems.Take(2)) // فقط 2 آیتم گران
            {
                Console.WriteLine($"  • {item.Name} (~{item.EstimatedPrice:C0})");
            }
        }

        var stats = new
        {
            TotalItems = todayList.Count,
            EssentialItems = todayList.Count(x => x.Item.IsEssential),
            CompletedRate = todayList.Count > 0 ? 
                Math.Round((double)todayList.Count(x => x.IsPurchased) / todayList.Count * 100, 0) : 0,
            AvgWeeklySpend = purchases.Count > 0 ? 
                purchases.Average(p => p.TotalAmount) : 0
        };

        Console.WriteLine("\n=== Quick Stats ===");
        Console.WriteLine($"Today's list: {stats.TotalItems} items ({stats.EssentialItems} essentials)");
        Console.WriteLine($"Completion: {stats.CompletedRate}%");
        Console.WriteLine($"Average weekly spend: {stats.AvgWeeklySpend:C0}");

        }

    }

    public class GroceryItem
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