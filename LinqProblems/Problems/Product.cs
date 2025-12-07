namespace LinqProblems.Problems
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
    }


    public class LinqExecute
    {
        public static void Execute()
        {
            var products = new List<Product>
        {
            new Product { Id = 1, Name = "Gaming Laptop", Category = "Electronics", 
                         Price = 1500, Tags = new List<string> {"gaming", "laptop", "computer"} },
            new Product { Id = 2, Name = "Wireless Mouse", Category = "Electronics", 
                         Price = 25, Tags = new List<string> {"mouse", "wireless", "accessories"} },
            new Product { Id = 3, Name = "Coffee Maker", Category = "Home Appliances", 
                         Price = 80, Tags = new List<string> {"coffee", "kitchen", "appliance"} },
            new Product { Id = 4, Name = "Running Shoes", Category = "Sports", 
                         Price = 120, Tags = new List<string> {"shoes", "running", "sports"} },
            new Product { Id = 5, Name = "Desk Lamp", Category = "Home Decor", 
                         Price = 35, Tags = new List<string> {"lamp", "desk", "lighting"} },
            new Product { Id = 6, Name = "Gaming Chair", Category = "Furniture", 
                         Price = 250, Tags = new List<string> {"gaming", "chair", "office"} },
            new Product { Id = 7, Name = "Bluetooth Speaker", Category = "Electronics", 
                         Price = 60, Tags = new List<string> {"speaker", "bluetooth", "audio"} }
        };

         Console.Write("Enter product name to search: ");
        string searchTerm = Console.ReadLine();
        
        var searchResults = products
            .Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            .ToList();
        
        Console.WriteLine($"\n=== Search Results for '{searchTerm}' ===");
        DisplayProducts(searchResults);
        
        // 2. فیلتر بر اساس محدوده قیمت
        decimal minPrice = 50;
        decimal maxPrice = 200;
        
        var priceFiltered = products
            .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
            .OrderBy(p => p.Price)
            .ToList();
        
        Console.WriteLine($"\n=== Products between ${minPrice} and ${maxPrice} ===");
        DisplayProducts(priceFiltered);
        
        // 3. فیلتر بر اساس دسته‌بندی
        string selectedCategory = "Electronics";
        
        var categoryProducts = products
            .Where(p => p.Category == selectedCategory)
            .ToList();
        
        Console.WriteLine($"\n=== {selectedCategory} Products ===");
        DisplayProducts(categoryProducts);
        
        // 4. جستجو بر اساس تگ
        string tagToSearch = "gaming";
        
        var tagProducts = products
            .Where(p => p.Tags.Any(tag => 
                tag.Equals(tagToSearch, StringComparison.OrdinalIgnoreCase)))
            .ToList();
        
        Console.WriteLine($"\n=== Products with tag '{tagToSearch}' ===");
        DisplayProducts(tagProducts);
        
        // 5. سیستم جستجوی ترکیبی
        Console.WriteLine("\n=== Advanced Search ===");
        Console.WriteLine("Available filters:");
        Console.WriteLine("1. By category");
        Console.WriteLine("2. By price range");
        Console.WriteLine("3. By tag");
        }


         static void DisplayProducts(List<Product> products)
    {
        if (!products.Any())
        {
            Console.WriteLine("No products found.");
            return;
        }
        
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Name} (${product.Price})");
            Console.WriteLine($"  Category: {product.Category}");
            Console.WriteLine($"  Tags: {string.Join(", ", product.Tags)}");
            Console.WriteLine();
        }
    }
    }
}