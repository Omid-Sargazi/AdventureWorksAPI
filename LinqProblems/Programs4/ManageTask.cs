namespace LinqProblems.Programs4
{
    public class ManageTasks
    {
        public static void Execute()
        {
            
        }
    }

    public class DailyTask
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Category { get; set; } // "Work", "Personal", "Health", "Home"
    public string Priority { get; set; } // "Low", "Medium", "High"
    public bool IsRecurring { get; set; }
    public string Recurrence { get; set; } // "Daily", "Weekly", "Monthly"
    public TimeSpan? EstimatedTime { get; set; }
}

public class CompletionRecord
{
    public int Id { get; set; }
    public int TaskId { get; set; }
    public DateTime CompletionDate { get; set; }
    public TimeSpan? ActualTime { get; set; }
    public string Notes { get; set; }
}
}