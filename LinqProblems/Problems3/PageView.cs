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
}
}