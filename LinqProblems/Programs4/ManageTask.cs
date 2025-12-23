namespace LinqProblems.Programs4
{
    public class ManageTasks
    {
        public static void Execute()
        {
            var dailyTasks = new List<DailyTask>
        {
            new DailyTask { Id = 1, Title = "Check emails", Category = "Work", 
                          Priority = "Medium", IsRecurring = true, Recurrence = "Daily",
                          EstimatedTime = TimeSpan.FromMinutes(30) },
            
            new DailyTask { Id = 2, Title = "Morning exercise", Category = "Health", 
                          Priority = "High", IsRecurring = true, Recurrence = "Daily",
                          EstimatedTime = TimeSpan.FromMinutes(45) },
            
            new DailyTask { Id = 3, Title = "Grocery shopping", Category = "Home", 
                          Priority = "High", IsRecurring = false, Recurrence = null,
                          EstimatedTime = TimeSpan.FromHours(1) },
            
            new DailyTask { Id = 4, Title = "Finish project report", Category = "Work", 
                          Priority = "High", IsRecurring = false, Recurrence = null,
                          EstimatedTime = TimeSpan.FromHours(2) },
            
            new DailyTask { Id = 5, Title = "Read book", Category = "Personal", 
                          Priority = "Low", IsRecurring = true, Recurrence = "Daily",
                          EstimatedTime = TimeSpan.FromMinutes(30) },
            
            new DailyTask { Id = 6, Title = "Water plants", Category = "Home", 
                          Priority = "Medium", IsRecurring = true, Recurrence = "Weekly",
                          EstimatedTime = TimeSpan.FromMinutes(15) },
            
            new DailyTask { Id = 7, Title = "Call parents", Category = "Personal", 
                          Priority = "Medium", IsRecurring = true, Recurrence = "Weekly",
                          EstimatedTime = TimeSpan.FromMinutes(20) }
        };

        // سوابق انجام کارها (برای هفته گذشته)
        var completionRecords = new List<CompletionRecord>
        {
            // دیروز
            new CompletionRecord { Id = 1, TaskId = 1, CompletionDate = DateTime.Now.AddDays(-1).AddHours(9),
                                 ActualTime = TimeSpan.FromMinutes(25), Notes = "Quick check" },
            new CompletionRecord { Id = 2, TaskId = 2, CompletionDate = DateTime.Now.AddDays(-1).AddHours(7),
                                 ActualTime = TimeSpan.FromMinutes(40), Notes = "Good workout" },
            new CompletionRecord { Id = 3, TaskId = 5, CompletionDate = DateTime.Now.AddDays(-1).AddHours(21),
                                 ActualTime = TimeSpan.FromMinutes(35), Notes = "Chapter 5" },
            
            // امروز
            new CompletionRecord { Id = 4, TaskId = 1, CompletionDate = DateTime.Now.AddHours(-2),
                                 ActualTime = TimeSpan.FromMinutes(20), Notes = "Urgent emails" },
            new CompletionRecord { Id = 5, TaskId = 2, CompletionDate = DateTime.Now.AddHours(-4),
                                 ActualTime = TimeSpan.FromMinutes(50), Notes = "Intense session" }
        };

        Console.WriteLine("=== Today's Tasks ===");
        
        // کارهای روزانه تکرارشونده
        var dailyRecurringTasks = dailyTasks
            .Where(t => t.IsRecurring && t.Recurrence == "Daily")
            .Select(t => new
            {
                t.Title,
                t.Category,
                t.Priority,
                IsCompleted = completionRecords.Any(cr => 
                    cr.TaskId == t.Id && cr.CompletionDate.Date == DateTime.Today),
                Estimated = t.EstimatedTime?.TotalMinutes ?? 0
            })
            .ToList();

        // کارهای غیرتکرارشونده برای امروز
        var nonRecurringTasks = dailyTasks
            .Where(t => !t.IsRecurring)
            .Select(t => new
            {
                t.Title,
                t.Category,
                t.Priority,
                IsCompleted = completionRecords.Any(cr => 
                    cr.TaskId == t.Id && cr.CompletionDate.Date == DateTime.Today),
                Estimated = t.EstimatedTime?.TotalMinutes ?? 0
            })
            .ToList();

        var allTodayTasks = dailyRecurringTasks.Concat(nonRecurringTasks).ToList();

        // نمایش بر اساس اولویت
        foreach (var priorityGroup in allTodayTasks
            .GroupBy(t => t.Priority)
            .OrderBy(g => g.Key == "High" ? 1 : g.Key == "Medium" ? 2 : 3))
        {
            Console.WriteLine($"\n{priorityGroup.Key} Priority:");
            foreach (var task in priorityGroup)
            {
                string status = task.IsCompleted ? "✅" : "⏳";
                string timeInfo = task.Estimated > 0 ? $" ({task.Estimated} min)" : "";
                Console.WriteLine($"  {status} {task.Title} [{task.Category}]{timeInfo}");
            }
        }

        var completedToday = completionRecords
            .Where(cr => cr.CompletionDate.Date == DateTime.Today)
            .Select(cr => new
            {
                Task = dailyTasks.First(t => t.Id == cr.TaskId).Title,
                Time = cr.ActualTime?.TotalMinutes ?? 0,
                cr.Notes,
                CompletedAt = cr.CompletionDate.ToString("HH:mm")
            })
            .OrderBy(c => c.CompletedAt)
            .ToList();

        Console.WriteLine("\n=== Completed Today ===");
        if (completedToday.Any())
        {
            foreach (var task in completedToday)
            {
                string timeInfo = task.Time > 0 ? $" in {task.Time} min" : "";
                Console.WriteLine($"✓ {task.Task} at {task.CompletedAt}{timeInfo}");
                if (!string.IsNullOrEmpty(task.Notes))
                    Console.WriteLine($"  Note: {task.Notes}");
            }
        }
        else
        {
            Console.WriteLine("No tasks completed yet today.");
        }

        var startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
        var weeklyStats = dailyTasks
            .SelectMany(task => completionRecords
                .Where(cr => cr.TaskId == task.Id && cr.CompletionDate >= startOfWeek)
                .Select(cr => new { task.Category, task.Priority, cr.ActualTime }))
            .GroupBy(x => x.Category)
            .Select(g => new
            {
                Category = g.Key,
                TasksCompleted = g.Count(),
                TotalTime = Math.Round(g.Sum(x => x.ActualTime?.TotalMinutes ?? 0), 0)
            })
            .OrderByDescending(s => s.TasksCompleted)
            .ToList();

        Console.WriteLine("\n=== Weekly Statistics (This Week) ===");
        foreach (var stat in weeklyStats)
        {
            Console.WriteLine($"{stat.Category}: {stat.TasksCompleted} tasks, {stat.TotalTime} min");
        }

        var remainingTasks = allTodayTasks
            .Where(t => !t.IsCompleted)
            .ToList();

        Console.WriteLine("\n=== Remaining Tasks for Today ===");
        if (remainingTasks.Any())
        {
            var totalEstimated = remainingTasks.Sum(t => t.Estimated);
            Console.WriteLine($"Total: {remainingTasks.Count} tasks, ~{totalEstimated} minutes");
            
            foreach (var task in remainingTasks.OrderBy(t => t.Priority == "High" ? 1 : t.Priority == "Medium" ? 2 : 3))
            {
                Console.WriteLine($"  {task.Priority}: {task.Title} (~{task.Estimated} min)");
            }
        }
        else
        {
            Console.WriteLine("All tasks completed! 🎉");
        }

        var recurringTasks = dailyTasks
            .Where(t => t.IsRecurring)
            .GroupBy(t => t.Recurrence)
            .Select(g => new
            {
                Frequency = g.Key,
                Tasks = g.Select(t => new
                {
                    t.Title,
                    t.Category,
                    LastCompleted = completionRecords
                        .Where(cr => cr.TaskId == t.Id)
                        .OrderByDescending(cr => cr.CompletionDate)
                        .FirstOrDefault()?.CompletionDate.ToString("MMM dd") ?? "Never"
                }).ToList()
            })
            .ToList();

        Console.WriteLine("\n=== Recurring Tasks ===");
        foreach (var group in recurringTasks)
        {
            Console.WriteLine($"\n{group.Frequency}:");
            foreach (var task in group.Tasks)
            {
                Console.WriteLine($"  {task.Title} [{task.Category}] - Last: {task.LastCompleted}");
            }
        }


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