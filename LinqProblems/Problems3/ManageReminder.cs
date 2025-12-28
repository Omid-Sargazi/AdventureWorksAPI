namespace LinqProblems.Problems3
{
    public class ManageReminder
    {
        public static void Execute()
        {
            
        }
    }

    public class Reminder
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; } // "Personal", "Work", "Health", "Family"
    public DateTime DueDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public string Priority { get; set; } // "Low", "Medium", "High"
    public bool IsRecurring { get; set; }
    public string Recurrence { get; set; } // "Daily", "Weekly", "Monthly"
    public DateTime CreatedDate { get; set; }
}

public class Notification
{
    public int Id { get; set; }
    public int ReminderId { get; set; }
    public DateTime NotificationTime { get; set; }
    public bool IsSent { get; set; }
    public string SentMethod { get; set; } // "App", "Email", "SMS"
}

}