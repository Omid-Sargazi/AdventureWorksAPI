using Microsoft.EntityFrameworkCore;

namespace EfCoreBasics.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Book> Books { get; set; } = new();
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;
    }

    public class LibraryContext : DbContext
    {
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Book> Books => Set<Book>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=library.db");
        }
    }

    public class TrackingDemo
    {
        public static void Execute()
        {
            using var db = new LibraryContext();
            var author = db.Authors.FirstOrDefault();

            if (author == null)
            {
                Console.WriteLine("No Author Found");
                return;
            }

            Console.WriteLine($"Before change:{db.Entry(author).State}");
            author.Name = "George Owel(Updated)";

            Console.WriteLine($"After change:{db.Entry(author).State}");

            db.SaveChanges();
            Console.WriteLine($"After Saved:{db.Entry(author).State}");


        }
    }


    public class TrackingBehaviorDemo
    {
        public static void Run()
        {
            Console.WriteLine("=== Default (Tracking) ===");

            using (var db = new LibraryContext())
            {
                var authors = db.Authors.Include(a => a.Books).ToList();
                var first = authors.First();
                first.Name = "Update in Memory";
                Console.WriteLine($"State after change: {db.Entry(first).State}");
            }

            Console.WriteLine("\n=== AsNoTracking ===");
            using (var db = new LibraryContext())
            {
                var authors = db.Authors.AsNoTracking()
                .Include(a => a.Books)
                .ToList();

                var first = authors.First(); first.Name = "Updated in memory";
                Console.WriteLine($"Tracked entities: {db.ChangeTracker.Entries().Count()}");
            }

            Console.WriteLine("\n=== AsNoTrackingWithIdentityResolution ===");

            using (var db = new LibraryContext())
            {
                var authors = db.Authors
                .AsNoTrackingWithIdentityResolution()
                .Include(a => a.Books)
                .ToList();


                var firstBook = authors.First().Books.First();
                Console.WriteLine($"Book '{firstBook.Title}' belongs to '{firstBook.Author.Name}'");
            }

        }
    }


    public class LINQExamples
    {
        public static void TotalSalesMonth(int[] arr)
        {
            var sales = new[]

            {
                new {Date=new DateTime(2024,1,15),Amount=1000 },
                new { Date = new DateTime(2024, 1, 20), Amount = 1500 },
                new { Date = new DateTime(2024, 2, 5), Amount = 800 },
                new { Date = new DateTime(2024, 2, 18), Amount = 1200 },
                new { Date = new DateTime(2024, 3, 10), Amount = 2000 },
                new { Date = new DateTime(2024, 3, 25), Amount = 1800 },
                new { Date = new DateTime(2024, 1, 30), Amount = 900 }
            };



            var res = sales.GroupBy(s => new { s.Date.Year, s.Date.Month })
            .Select(g => new { YearMonth = $"{g.Key.Year}--{g.Key.Month}", TotalAmount = g.Sum(s => s.Amount) }).OrderBy(s => s.TotalAmount);
        }
    }


}