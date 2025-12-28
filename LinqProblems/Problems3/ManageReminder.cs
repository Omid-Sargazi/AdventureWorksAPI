namespace LinqProblems.Problems3
{
    public class ManageReminder
    {
        public static void Execute()
        {
            var reminders = new List<Reminder>
        {
            new Reminder { Id = 1, Title = "Doctor appointment", Description = "Annual checkup", 
                         Category = "Health", DueDate = DateTime.Today.AddHours(14), 
                         CompletionDate = null, Priority = "High", IsRecurring = false, 
                         Recurrence = null, CreatedDate = DateTime.Now.AddDays(-5) },
            
            new Reminder { Id = 2, Title = "Pay electricity bill", Description = "Due this week", 
                         Category = "Personal", DueDate = DateTime.Today.AddDays(2), 
                         CompletionDate = null, Priority = "Medium", IsRecurring = true, 
                         Recurrence = "Monthly", CreatedDate = DateTime.Now.AddDays(-30) },
            
            new Reminder { Id = 3, Title = "Team meeting", Description = "Weekly sync", 
                         Category = "Work", DueDate = DateTime.Today.AddHours(10), 
                         CompletionDate = DateTime.Today.AddHours(11), Priority = "Medium", 
                         IsRecurring = true, Recurrence = "Weekly", CreatedDate = DateTime.Now.AddDays(-60) },
            
            new Reminder { Id = 4, Title = "Buy groceries", Description = "Milk, eggs, bread", 
                         Category = "Personal", DueDate = DateTime.Today.AddDays(-1), 
                         CompletionDate = null, Priority = "Medium", IsRecurring = false, 
                         Recurrence = null, CreatedDate = DateTime.Now.AddDays(-3) },
            
            new Reminder { Id = 5, Title = "Call mom", Description = "Birthday call", 
                         Category = "Family", DueDate = DateTime.Today.AddDays(3), 
                         CompletionDate = null, Priority = "High", IsRecurring = false, 
                         Recurrence = null, CreatedDate = DateTime.Now.AddDays(-2) },
            
            new Reminder { Id = 6, Title = "Gym session", Description = "Evening workout", 
                         Category = "Health", DueDate = DateTime.Today.AddHours(18), 
                         CompletionDate = null, Priority = "Low", IsRecurring = true, 
                         Recurrence = "Daily", CreatedDate = DateTime.Now.AddDays(-15) },
            
            new Reminder { Id = 7, Title = "Submit report", Description = "Monthly report", 
                         Category = "Work", DueDate = DateTime.Today.AddDays(5), 
                         CompletionDate = null, Priority = "High", IsRecurring = true, 
                         Recurrence = "Monthly", CreatedDate = DateTime.Now.AddDays(-90) }
        };

        var notifications = new List<Notification>
        {
            new Notification { Id = 1, ReminderId = 1, NotificationTime = DateTime.Today.AddHours(10), 
                             IsSent = true, SentMethod = "App" },
            new Notification { Id = 2, ReminderId = 1, NotificationTime = DateTime.Today.AddHours(13), 
                             IsSent = false, SentMethod = "App" },
            new Notification { Id = 3, ReminderId = 3, NotificationTime = DateTime.Today.AddHours(9), 
                             IsSent = true, SentMethod = "Email" },
            new Notification { Id = 4, ReminderId = 6, NotificationTime = DateTime.Today.AddHours(17), 
                             IsSent = false, SentMethod = "App" },
            new Notification { Id = 5, ReminderId = 2, NotificationTime = DateTime.Today, 
                             IsSent = true, SentMethod = "SMS" }
        };

         var todayReminders = reminders
            .Where(r => r.DueDate.Date == DateTime.Today)
            .OrderBy(r => r.DueDate)
            .Select(r => new
            {
                r.Title,
                Time = r.DueDate.ToString("HH:mm"),
                r.Priority,
                r.Category,
                IsCompleted = r.CompletionDate.HasValue,
                HoursUntil = Math.Round((r.DueDate - DateTime.Now).TotalHours, 1)
            })
            .ToList();

        Console.WriteLine("=== Today's Reminders ===");
        if (todayReminders.Any())
        {
            foreach (var reminder in todayReminders)
            {
                string status = reminder.IsCompleted ? "✅" : 
                               reminder.HoursUntil > 0 ? "⏰" : "⚠️";
                string timeStatus = reminder.HoursUntil > 0 ? 
                    $"in {reminder.HoursUntil}h" : "NOW";
                
                Console.WriteLine($"{status} {reminder.Time} - {reminder.Title}");
                Console.WriteLine($"  Category: {reminder.Category}, Priority: {reminder.Priority}");
                Console.WriteLine($"  Status: {(reminder.IsCompleted ? "Completed" : $"Due {timeStatus}")}");
            }
        }
        else
        {
            Console.WriteLine("No reminders for today! 🎉");
        }


         var upcomingReminders = reminders
            .Where(r => r.DueDate > DateTime.Now && 
                       r.DueDate <= DateTime.Now.AddDays(7) && 
                       !r.CompletionDate.HasValue)
            .OrderBy(r => r.DueDate)
            .Select(r => new
            {
                r.Title,
                DueDate = r.DueDate.ToString("ddd, MMM dd"),
                Time = r.DueDate.ToString("HH:mm"),
                r.Priority,
                r.Category,
                DaysUntil = (r.DueDate.Date - DateTime.Today).Days
            })
            .ToList();

        Console.WriteLine("\n=== Upcoming Reminders (Next 7 Days) ===");
        if (upcomingReminders.Any())
        {
            foreach (var reminder in upcomingReminders)
            {
                string dayInfo = reminder.DaysUntil == 0 ? "Today" :
                                reminder.DaysUntil == 1 ? "Tomorrow" :
                                $"In {reminder.DaysUntil} days";
                
                Console.WriteLine($"{reminder.DueDate} {reminder.Time} - {reminder.Title}");
                Console.WriteLine($"  {dayInfo} | Category: {reminder.Category} | Priority: {reminder.Priority}");
            }
        }
        else
        {
            Console.WriteLine("No upcoming reminders in the next 7 days.");
        }

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