namespace LinqProblems.Problems3
{
    public class PageView
{
    public int Id { get; set; }
    public int VisitorId { get; set; }
    public int SessionId { get; set; }
    public string PageUrl { get; set; }
    public string PageTitle { get; set; }
    public DateTime ViewTime { get; set; }
    public int TimeOnPage { get; set; } // seconds
}

public class Visitor
{
    public int Id { get; set; }
    public string IPAddress { get; set; }
    public string Country { get; set; }
    public string DeviceType { get; set; }
    public string Browser { get; set; }
    public DateTime FirstVisit { get; set; }
}

public class Session
{
    public int Id { get; set; }
    public int VisitorId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string Referrer { get; set; } // "Google", "Direct", "Social Media"


    public static void Execute()
        {
            var visitors = new List<Visitor>
        {
            new Visitor { Id = 1, IPAddress = "192.168.1.1", Country = "Iran", DeviceType = "Desktop", 
                         Browser = "Chrome", FirstVisit = DateTime.Now.AddDays(-30) },
            new Visitor { Id = 2, IPAddress = "192.168.1.2", Country = "Iran", DeviceType = "Mobile", 
                         Browser = "Firefox", FirstVisit = DateTime.Now.AddDays(-15) },
            new Visitor { Id = 3, IPAddress = "192.168.1.3", Country = "USA", DeviceType = "Tablet", 
                         Browser = "Safari", FirstVisit = DateTime.Now.AddDays(-7) },
            new Visitor { Id = 4, IPAddress = "192.168.1.4", Country = "Germany", DeviceType = "Desktop", 
                         Browser = "Chrome", FirstVisit = DateTime.Now.AddDays(-3) },
            new Visitor { Id = 5, IPAddress = "192.168.1.5", Country = "Iran", DeviceType = "Mobile", 
                         Browser = "Chrome", FirstVisit = DateTime.Now.AddDays(-1) }
        };

        var sessions = new List<Session>
        {
            new Session { Id = 1, VisitorId = 1, StartTime = DateTime.Now.AddHours(-5), 
                         EndTime = DateTime.Now.AddHours(-4).AddMinutes(30), Referrer = "Google" },
            new Session { Id = 2, VisitorId = 1, StartTime = DateTime.Now.AddHours(-2), 
                         EndTime = DateTime.Now.AddHours(-1).AddMinutes(45), Referrer = "Direct" },
            new Session { Id = 3, VisitorId = 2, StartTime = DateTime.Now.AddHours(-3), 
                         EndTime = DateTime.Now.AddHours(-2).AddMinutes(15), Referrer = "Social Media" },
            new Session { Id = 4, VisitorId = 3, StartTime = DateTime.Now.AddHours(-1), 
                         EndTime = null, Referrer = "Google" }, // Active session
            new Session { Id = 5, VisitorId = 4, StartTime = DateTime.Now.AddHours(-4), 
                         EndTime = DateTime.Now.AddHours(-3).AddMinutes(10), Referrer = "Direct" },
            new Session { Id = 6, VisitorId = 5, StartTime = DateTime.Now.AddHours(-1).AddMinutes(30), 
                         EndTime = DateTime.Now.AddHours(-1).AddMinutes(5), Referrer = "Social Media" }
        };

        var pageViews = new List<PageView>
        {
            // Session 1
            new PageView { Id = 1, VisitorId = 1, SessionId = 1, PageUrl = "/home", 
                         PageTitle = "Home Page", ViewTime = DateTime.Now.AddHours(-5), TimeOnPage = 60 },
            new PageView { Id = 2, VisitorId = 1, SessionId = 1, PageUrl = "/products", 
                         PageTitle = "Products", ViewTime = DateTime.Now.AddHours(-5).AddMinutes(1), TimeOnPage = 120 },
            new PageView { Id = 3, VisitorId = 1, SessionId = 1, PageUrl = "/contact", 
                         PageTitle = "Contact Us", ViewTime = DateTime.Now.AddHours(-5).AddMinutes(3), TimeOnPage = 45 },
            
            // Session 2
            new PageView { Id = 4, VisitorId = 1, SessionId = 2, PageUrl = "/home", 
                         PageTitle = "Home Page", ViewTime = DateTime.Now.AddHours(-2), TimeOnPage = 30 },
            new PageView { Id = 5, VisitorId = 1, SessionId = 2, PageUrl = "/blog", 
                         PageTitle = "Blog", ViewTime = DateTime.Now.AddHours(-2).AddMinutes(0.5), TimeOnPage = 90 },
            
            // Session 3
            new PageView { Id = 6, VisitorId = 2, SessionId = 3, PageUrl = "/home", 
                         PageTitle = "Home Page", ViewTime = DateTime.Now.AddHours(-3), TimeOnPage = 15 },
            
            // Session 4
            new PageView { Id = 7, VisitorId = 3, SessionId = 4, PageUrl = "/products", 
                         PageTitle = "Products", ViewTime = DateTime.Now.AddHours(-1), TimeOnPage = 180 },
            new PageView { Id = 8, VisitorId = 3, SessionId = 4, PageUrl = "/product/details", 
                         PageTitle = "Product Details", ViewTime = DateTime.Now.AddHours(-1).AddMinutes(3), TimeOnPage = 120 },
            
            // Session 5
            new PageView { Id = 9, VisitorId = 4, SessionId = 5, PageUrl = "/home", 
                         PageTitle = "Home Page", ViewTime = DateTime.Now.AddHours(-4), TimeOnPage = 10 },
            
            // Session 6
            new PageView { Id = 10, VisitorId = 5, SessionId = 6, PageUrl = "/home", 
                         PageTitle = "Home Page", ViewTime = DateTime.Now.AddHours(-1).AddMinutes(30), TimeOnPage = 20 }
        };


        var popularPages = pageViews
            .GroupBy(p => p.PageUrl)
            .Select(g => new
            {
                PageUrl = g.Key,
                PageTitle = g.First().PageTitle,
                ViewCount = g.Count(),
                UniqueVisitors = g.Select(p => p.VisitorId).Distinct().Count(),
                AverageTimeOnPage = Math.Round(g.Average(p => p.TimeOnPage), 1),
                TotalTime = g.Sum(p => p.TimeOnPage)
            })
            .OrderByDescending(p => p.ViewCount)
            .ToList();

        Console.WriteLine("=== Most Popular Pages ===");
        foreach (var page in popularPages)
        {
            Console.WriteLine($"{page.PageTitle} ({page.PageUrl}):");
            Console.WriteLine($"  Views: {page.ViewCount}, Unique Visitors: {page.UniqueVisitors}");
            Console.WriteLine($"  Avg Time: {page.AverageTimeOnPage}s, Total Time: {page.TotalTime}s");
        }

         var sessionAnalysis = sessions
            .Select(s => new
            {
                SessionId = s.Id,
                s.VisitorId,
                s.StartTime,
                s.EndTime,
                SessionDuration = s.EndTime.HasValue ? 
                    (s.EndTime.Value - s.StartTime).TotalMinutes : 0,
                PageViews = pageViews.Count(p => p.SessionId == s.Id),
                IsBounce = pageViews.Count(p => p.SessionId == s.Id) == 1 // یک صفحه دیده
            })
            .Join(visitors,
                  session => session.VisitorId,
                  visitor => visitor.Id,
                  (session, visitor) => new
                  {
                      session.SessionId,
                      VisitorCountry = visitor.Country,
                      visitor.DeviceType,
                      visitor.Browser,
                      session.StartTime,
                      session.SessionDuration,
                      session.PageViews,
                      session.IsBounce
                  })
            .OrderByDescending(s => s.SessionDuration)
            .ToList();

        Console.WriteLine("\n=== Session Analysis ===");
        foreach (var session in sessionAnalysis.Take(5))
        {
            Console.WriteLine($"Session {session.SessionId}:");
            Console.WriteLine($"  Duration: {session.SessionDuration:F1} minutes");
            Console.WriteLine($"  Page Views: {session.PageViews}");
            Console.WriteLine($"  From: {session.VisitorCountry}, Device: {session.DeviceType}");
            Console.WriteLine($"  Bounce: {(session.IsBounce ? "Yes" : "No")}");
        }


    }
}

}