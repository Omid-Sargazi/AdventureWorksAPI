namespace LinqProblems.Problems2
{
    public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
}

public class Reviewer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime JoinDate { get; set; }
    public int TotalReviews { get; set; }
}

public class Review
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ReviewerId { get; set; }
    public int Rating { get; set; } // 1-5
    public string Comment { get; set; }
    public DateTime ReviewDate { get; set; }
    public int HelpfulCount { get; set; }
    public int UnhelpfulCount { get; set; }
}

public class LinqExecute2
    {
        public static void Run()
        {
             var products = new List<Product>
        {
            new Product { Id = 1, Name = "Smartphone X", Category = "Electronics", Price = 800 },
            new Product { Id = 2, Name = "Laptop Pro", Category = "Electronics", Price = 1500 },
            new Product { Id = 3, Name = "Wireless Earbuds", Category = "Electronics", Price = 120 },
            new Product { Id = 4, Name = "Coffee Maker", Category = "Home", Price = 80 },
            new Product { Id = 5, Name = "Running Shoes", Category = "Sports", Price = 100 }
        };

         var reviewers = new List<Reviewer>
        {
            new Reviewer { Id = 1, Name = "Tech Expert", JoinDate = DateTime.Now.AddYears(-1), TotalReviews = 50 },
            new Reviewer { Id = 2, Name = "Casual User", JoinDate = DateTime.Now.AddMonths(-6), TotalReviews = 10 },
            new Reviewer { Id = 3, Name = "Professional", JoinDate = DateTime.Now.AddYears(-2), TotalReviews = 100 },
            new Reviewer { Id = 4, Name = "New User", JoinDate = DateTime.Now.AddDays(-30), TotalReviews = 5 }
        };

         var reviews = new List<Review>
        {
            new Review { Id = 1, ProductId = 1, ReviewerId = 1, Rating = 5, 
                        Comment = "Excellent phone, great camera!", ReviewDate = DateTime.Now.AddDays(-10), 
                        HelpfulCount = 20, UnhelpfulCount = 2 },
            new Review { Id = 2, ProductId = 1, ReviewerId = 2, Rating = 4, 
                        Comment = "Good but battery could be better", ReviewDate = DateTime.Now.AddDays(-5), 
                        HelpfulCount = 15, UnhelpfulCount = 5 },
            new Review { Id = 3, ProductId = 1, ReviewerId = 3, Rating = 3, 
                        Comment = "Average performance", ReviewDate = DateTime.Now.AddDays(-3), 
                        HelpfulCount = 5, UnhelpfulCount = 10 },
            new Review { Id = 4, ProductId = 2, ReviewerId = 1, Rating = 5, 
                        Comment = "Best laptop I've ever used", ReviewDate = DateTime.Now.AddDays(-15), 
                        HelpfulCount = 30, UnhelpfulCount = 1 },
            new Review { Id = 5, ProductId = 2, ReviewerId = 3, Rating = 4, 
                        Comment = "Very fast, but expensive", ReviewDate = DateTime.Now.AddDays(-7), 
                        HelpfulCount = 25, UnhelpfulCount = 3 },
            new Review { Id = 6, ProductId = 3, ReviewerId = 2, Rating = 2, 
                        Comment = "Poor sound quality", ReviewDate = DateTime.Now.AddDays(-2), 
                        HelpfulCount = 8, UnhelpfulCount = 12 },
            new Review { Id = 7, ProductId = 3, ReviewerId = 4, Rating = 1, 
                        Comment = "Stopped working after a week", ReviewDate = DateTime.Now.AddDays(-1), 
                        HelpfulCount = 10, UnhelpfulCount = 2 },
            new Review { Id = 8, ProductId = 4, ReviewerId = 3, Rating = 5, 
                        Comment = "Makes perfect coffee every time", ReviewDate = DateTime.Now.AddDays(-20), 
                        HelpfulCount = 40, UnhelpfulCount = 0 },
            new Review { Id = 9, ProductId = 5, ReviewerId = 1, Rating = 4, 
                        Comment = "Comfortable for running", ReviewDate = DateTime.Now.AddDays(-12), 
                        HelpfulCount = 18, UnhelpfulCount = 4 }
        };
        }
    }
}