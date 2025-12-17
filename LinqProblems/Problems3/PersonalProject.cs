namespace LinqProblems.Problems3
{
    public class PersonalProject
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; } // "Work", "Personal", "Learning", "Health"
    public DateTime StartDate { get; set; }
    public DateTime? DueDate { get; set; }
    public int Priority { get; set; } // 1-5 (5 is highest)
    public string Status { get; set; } // "Not Started", "In Progress", "Completed", "On Hold"
    public decimal Budget { get; set; }
}

public class ProjectTask
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; } // "Todo", "In Progress", "Done"
    public int EstimatedHours { get; set; }
    public int ActualHours { get; set; }
}

public class Note
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string[] Tags { get; set; }
}

public class TimeLog
{
    public int Id { get; set; }
    public int TaskId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Description { get; set; }
}
}