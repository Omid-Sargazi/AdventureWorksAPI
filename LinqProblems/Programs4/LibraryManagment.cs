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
        
    }
}