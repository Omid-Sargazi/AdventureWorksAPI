namespace LinqProblems
{

    public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; } // "Fiction", "Non-Fiction", "Sci-Fi", "Biography"
    public int PageCount { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public string Status { get; set; } // "To Read", "Reading", "Read"
    public int CurrentPage { get; set; }
}

public class ReadingSession
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int PagesRead { get; set; }
    public string Notes { get; set; }
}

public class Review
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int Rating { get; set; } // 1-5
    public DateTime ReviewDate { get; set; }
    public string Comment { get; set; }
}

public class Bookshelf
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; } // "Favorites", "To Read", "Currently Reading"
}
    public class LibraryManagment
    {
        public static void Execute()
        {
            var books = new List<Book>
        {
            new Book { Id = 1, Title = "1984", Author = "George Orwell", Genre = "Fiction", 
                      PageCount = 328, PurchaseDate = new DateTime(2023, 1, 15), 
                      Status = "Read", CurrentPage = 328 },
            new Book { Id = 2, Title = "The Alchemist", Author = "Paulo Coelho", Genre = "Fiction", 
                      PageCount = 208, PurchaseDate = new DateTime(2023, 2, 20), 
                      Status = "Reading", CurrentPage = 120 },
            new Book { Id = 3, Title = "Sapiens", Author = "Yuval Noah Harari", Genre = "Non-Fiction", 
                      PageCount = 443, PurchaseDate = new DateTime(2023, 3, 10), 
                      Status = "Read", CurrentPage = 443 },
            new Book { Id = 4, Title = "The Martian", Author = "Andy Weir", Genre = "Sci-Fi", 
                      PageCount = 369, PurchaseDate = new DateTime(2023, 4, 5), 
                      Status = "To Read", CurrentPage = 0 },
            new Book { Id = 5, Title = "Steve Jobs", Author = "Walter Isaacson", Genre = "Biography", 
                      PageCount = 656, PurchaseDate = new DateTime(2023, 5, 25), 
                      Status = "Reading", CurrentPage = 300 },
            new Book { Id = 6, Title = "The Hobbit", Author = "J.R.R. Tolkien", Genre = "Fiction", 
                      PageCount = 310, PurchaseDate = new DateTime(2023, 6, 15), 
                      Status = "Read", CurrentPage = 310 }
        };

        // جلسات مطالعه
        var readingSessions = new List<ReadingSession>
        {
            new ReadingSession { Id = 1, BookId = 2, StartTime = DateTime.Now.AddDays(-2).AddHours(18), 
                               EndTime = DateTime.Now.AddDays(-2).AddHours(20), PagesRead = 25, Notes = "Evening reading" },
            new ReadingSession { Id = 2, BookId = 2, StartTime = DateTime.Now.AddDays(-1).AddHours(9), 
                               EndTime = DateTime.Now.AddDays(-1).AddHours(10).AddMinutes(30), PagesRead = 30, Notes = "Morning coffee" },
            new ReadingSession { Id = 3, BookId = 5, StartTime = DateTime.Now.AddDays(-3).AddHours(15), 
                               EndTime = DateTime.Now.AddDays(-3).AddHours(17), PagesRead = 40, Notes = "Afternoon session" },
            new ReadingSession { Id = 4, BookId = 5, StartTime = DateTime.Now.AddDays(-1).AddHours(20), 
                               EndTime = DateTime.Now.AddDays(-1).AddHours(22), PagesRead = 35, Notes = "Late night reading" },
            new ReadingSession { Id = 5, BookId = 2, StartTime = DateTime.Now.AddHours(-3), 
                               EndTime = DateTime.Now.AddHours(-1), PagesRead = 20, Notes = "Current session" }
        };

        // نظرات
        var reviews = new List<Review>
        {
            new Review { Id = 1, BookId = 1, Rating = 5, ReviewDate = DateTime.Now.AddDays(-30), 
                        Comment = "Amazing book! Still relevant today." },
            new Review { Id = 2, BookId = 3, Rating = 4, ReviewDate = DateTime.Now.AddDays(-15), 
                        Comment = "Very insightful, but a bit long" },
            new Review { Id = 3, BookId = 6, Rating = 5, ReviewDate = DateTime.Now.AddDays(-7), 
                        Comment = "Fantastic adventure story" }
        };

        // قفسه‌های کتاب
        var bookshelves = new List<Bookshelf>
        {
            new Bookshelf { Id = 1, Name = "Favorites", Category = "Favorites" },
            new Bookshelf { Id = 2, Name = "Currently Reading", Category = "Currently Reading" },
            new Bookshelf { Id = 3, Name = "To Read Next", Category = "To Read" }
        };

        var currentlyReading = books
            .Where(b => b.Status == "Reading")
            .Select(b => new
            {
                b.Title,
                b.Author,
                Progress = Math.Round((double)b.CurrentPage / b.PageCount * 100, 1),
                PagesLeft = b.PageCount - b.CurrentPage,
                ReadingTime = readingSessions
                    .Where(rs => rs.BookId == b.Id)
                    .Sum(rs => (rs.EndTime - rs.StartTime).TotalHours)
            })
            .ToList();

        Console.WriteLine("=== Currently Reading ===");
        foreach (var book in currentlyReading)
        {
            Console.WriteLine($"{book.Title} by {book.Author}");
            Console.WriteLine($"  Progress: {book.Progress}% ({book.PagesLeft} pages left)");
            Console.WriteLine($"  Time spent: {book.ReadingTime:F1} hours");
        }

         var readBooksWithRatings = books
            .Where(b => b.Status == "Read")
            .Select(b => new
            {
                b.Title,
                b.Author,
                b.Genre,
                Rating = reviews.FirstOrDefault(r => r.BookId == b.Id)?.Rating ?? 0,
                Review = reviews.FirstOrDefault(r => r.BookId == b.Id)?.Comment ?? "No review yet",
                DaysToFinish = readingSessions
                    .Where(rs => rs.BookId == b.Id)
                    .Select(rs => rs.StartTime.Date)
                    .Distinct()
                    .Count()
            })
            .OrderByDescending(b => b.Rating)
            .ToList();

        Console.WriteLine("\n=== Read Books with Ratings ===");
        foreach (var book in readBooksWithRatings)
        {
            string stars = new string('★', book.Rating) + new string('☆', 5 - book.Rating);
            Console.WriteLine($"{book.Title} ({book.Genre})");
            Console.WriteLine($"  Author: {book.Author}, Rating: {stars}");
            Console.WriteLine($"  Review: {book.Review}");
            Console.WriteLine($"  Days to finish: {book.DaysToFinish}");
        }

        }
    }
}