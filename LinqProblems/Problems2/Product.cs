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

        var productRatings = reviews
            .GroupBy(r => r.ProductId)
            .Select(g => new
            {
                ProductId = g.Key,
                AverageRating = Math.Round(g.Average(r => r.Rating), 2),
                TotalReviews = g.Count(),
                TotalHelpful = g.Sum(r => r.HelpfulCount),
                TotalUnhelpful = g.Sum(r => r.UnhelpfulCount)
            })
            .Join(products,
                  rating => rating.ProductId,
                  product => product.Id,
                  (rating, product) => new
                  {
                      product.Name,
                      product.Category,
                      rating.AverageRating,
                      rating.TotalReviews,
                      rating.TotalHelpful,
                      rating.TotalUnhelpful,
                      HelpfulnessRate = rating.TotalHelpful > 0 ? 
                          Math.Round((double)rating.TotalHelpful / (rating.TotalHelpful + rating.TotalUnhelpful) * 100, 1) : 0
                  })
            .OrderByDescending(p => p.AverageRating)
            .ToList();

              Console.WriteLine("=== Product Ratings Summary ===");
        foreach (var product in productRatings)
        {
            Console.WriteLine($"{product.Name} ({product.Category}):");
            Console.WriteLine($"  Rating: {product.AverageRating}/5 from {product.TotalReviews} reviews");
            Console.WriteLine($"  Helpfulness: {product.HelpfulnessRate}% ({product.TotalHelpful} helpful, {product.TotalUnhelpful} unhelpful)");
        }

         var topRatedProducts = productRatings
            .Where(p => p.AverageRating >= 4)
            .Take(3)
            .ToList();

        Console.WriteLine("\n=== Top Rated Products (4+ stars) ===");
        foreach (var product in topRatedProducts)
        {
            Console.WriteLine($"{product.Name}: {product.AverageRating} stars");
        }

        var recentReviews = reviews
            .OrderByDescending(r => r.ReviewDate)
            .Take(5)
            .Join(products,
                  review => review.ProductId,
                  product => product.Id,
                  (review, product) => new
                  {
                      product.Name,
                      Rating = new string('★', review.Rating) + new string('☆', 5 - review.Rating),
                      review.Comment,
                      review.ReviewDate,
                      review.HelpfulCount,
                      Helpfulness = review.HelpfulCount - review.UnhelpfulCount
                  })
            .ToList();

        Console.WriteLine("\n=== Recent Reviews ===");
        foreach (var review in recentReviews)
        {
            Console.WriteLine($"{review.Name}: {review.Rating}");
            Console.WriteLine($"  \"{review.Comment}\"");
            Console.WriteLine($"  Date: {review.ReviewDate:yyyy-MM-dd}, Helpful: +{review.Helpfulness}");
        }

        var mostHelpfulReviews = reviews
            .OrderByDescending(r => r.HelpfulCount)
            .Take(3)
            .Join(products,
                  review => review.ProductId,
                  product => product.Id,
                  (review, product) => new
                  {
                      product.Name,
                      review.Rating,
                      review.Comment,
                      review.HelpfulCount,
                      review.UnhelpfulCount
                  })
            .ToList();

        Console.WriteLine("\n=== Most Helpful Reviews ===");
        foreach (var review in mostHelpfulReviews)
        {
            Console.WriteLine($"{review.Name} - {review.Rating} stars");
            Console.WriteLine($"  \"{review.Comment}\"");
            Console.WriteLine($"  Helpful: {review.HelpfulCount}, Unhelpful: {review.UnhelpfulCount}");
        }

        var sentimentAnalysis = reviews
            .Select(r => new
            {
                r.Rating,
                r.Comment,
                Sentiment = AnalyzeSentiment(r.Comment, r.Rating)
            })
            .GroupBy(r => r.Sentiment)
            .Select(g => new
            {
                Sentiment = g.Key,
                Count = g.Count(),
                Percentage = Math.Round((double)g.Count() / reviews.Count * 100, 1)
            })
            .OrderByDescending(g => g.Count)
            .ToList();

        Console.WriteLine("\n=== Review Sentiment Analysis ===");
        foreach (var sentiment in sentimentAnalysis)
        {
            Console.WriteLine($"{sentiment.Sentiment}: {sentiment.Count} reviews ({sentiment.Percentage}%)");
        }

        var activeReviewers = reviews
            .GroupBy(r => r.ReviewerId)
            .Select(g => new
            {
                ReviewerId = g.Key,
                TotalReviews = g.Count(),
                AverageRating = Math.Round(g.Average(r => r.Rating), 2),
                TotalHelpful = g.Sum(r => r.HelpfulCount)
            })
            .Join(reviewers,
                  stat => stat.ReviewerId,
                  reviewer => reviewer.Id,
                  (stat, reviewer) => new
                  {
                      reviewer.Name,
                      reviewer.JoinDate,
                      stat.TotalReviews,
                      stat.AverageRating,
                      stat.TotalHelpful,
                      ReviewerLevel = stat.TotalReviews switch
                      {
                          > 50 => "Expert",
                          > 20 => "Advanced",
                          > 5 => "Intermediate",
                          _ => "Beginner"
                      }
                  })
            .OrderByDescending(r => r.TotalHelpful)
            .ToList();

        Console.WriteLine("\n=== Active Reviewers ===");
        foreach (var reviewer in activeReviewers)
        {
            Console.WriteLine($"{reviewer.Name} ({reviewer.ReviewerLevel}):");
            Console.WriteLine($"  Reviews: {reviewer.TotalReviews}, Avg Rating: {reviewer.AverageRating}");
            Console.WriteLine($"  Total Helpful Votes: {reviewer.TotalHelpful}");
        }
    }

        

            static string AnalyzeSentiment(string comment, int rating)
    {
        if (rating >= 4) return "Positive";
        if (rating == 3) return "Neutral";
        return "Negative";
    }
    }
}