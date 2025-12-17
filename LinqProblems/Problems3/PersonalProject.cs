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

public class ManageProjects
    {
        public static void Execute()
        {
            var projects = new List<PersonalProject>
        {
            new PersonalProject { Id = 1, Title = "Learn C# Advanced", Description = "Master advanced C# concepts",
                                 Category = "Learning", StartDate = DateTime.Now.AddDays(-30), DueDate = DateTime.Now.AddDays(30),
                                 Priority = 4, Status = "In Progress", Budget = 0 },
            new PersonalProject { Id = 2, Title = "Home Renovation", Description = "Renovate living room",
                                 Category = "Personal", StartDate = DateTime.Now.AddDays(-15), DueDate = DateTime.Now.AddDays(45),
                                 Priority = 3, Status = "In Progress", Budget = 50000000 },
            new PersonalProject { Id = 3, Title = "Fitness Plan", Description = "Lose 5kg and build muscle",
                                 Category = "Health", StartDate = DateTime.Now.AddDays(-60), DueDate = null,
                                 Priority = 2, Status = "In Progress", Budget = 2000000 },
            new PersonalProject { Id = 4, Title = "Build Portfolio Website", Description = "Create personal portfolio",
                                 Category = "Work", StartDate = DateTime.Now.AddDays(-10), DueDate = DateTime.Now.AddDays(20),
                                 Priority = 5, Status = "Not Started", Budget = 0 }
        };

        var tasks = new List<ProjectTask>
        {
            // Project 1 tasks
            new ProjectTask { Id = 1, ProjectId = 1, Title = "Study LINQ", Description = "Complete LINQ tutorial",
                            DueDate = DateTime.Now.AddDays(5), Status = "In Progress", EstimatedHours = 10, ActualHours = 6 },
            new ProjectTask { Id = 2, ProjectId = 1, Title = "Learn Async/Await", Description = "Understand async programming",
                            DueDate = DateTime.Now.AddDays(15), Status = "Todo", EstimatedHours = 8, ActualHours = 0 },
            new ProjectTask { Id = 3, ProjectId = 1, Title = "Build Sample Project", Description = "Create practical project",
                            DueDate = DateTime.Now.AddDays(25), Status = "Todo", EstimatedHours = 20, ActualHours = 0 },
            
            // Project 2 tasks
            new ProjectTask { Id = 4, ProjectId = 2, Title = "Buy Materials", Description = "Purchase paint and tools",
                            DueDate = DateTime.Now.AddDays(-5), Status = "Done", EstimatedHours = 4, ActualHours = 3 },
            new ProjectTask { Id = 5, ProjectId = 2, Title = "Paint Walls", Description = "Paint living room walls",
                            DueDate = DateTime.Now.AddDays(10), Status = "In Progress", EstimatedHours = 12, ActualHours = 5 },
            new ProjectTask { Id = 6, ProjectId = 2, Title = "Install Lights", Description = "Install new lighting",
                            DueDate = DateTime.Now.AddDays(20), Status = "Todo", EstimatedHours = 8, ActualHours = 0 },
            
            // Project 3 tasks
            new ProjectTask { Id = 7, ProjectId = 3, Title = "Gym Membership", Description = "Sign up for gym",
                            DueDate = DateTime.Now.AddDays(-50), Status = "Done", EstimatedHours = 2, ActualHours = 1 },
            new ProjectTask { Id = 8, ProjectId = 3, Title = "Weekly Workout Plan", Description = "Create workout schedule",
                            DueDate = DateTime.Now.AddDays(-40), Status = "Done", EstimatedHours = 3, ActualHours = 2 },
            new ProjectTask { Id = 9, ProjectId = 3, Title = "Diet Plan", Description = "Prepare healthy meal plan",
                            DueDate = DateTime.Now.AddDays(-30), Status = "In Progress", EstimatedHours = 5, ActualHours = 2 },
            
            // Project 4 tasks
            new ProjectTask { Id = 10, ProjectId = 4, Title = "Design Website", Description = "Create website mockup",
                             DueDate = DateTime.Now.AddDays(5), Status = "Todo", EstimatedHours = 15, ActualHours = 0 },
            new ProjectTask { Id = 11, ProjectId = 4, Title = "Develop Frontend", Description = "Code HTML/CSS/JS",
                             DueDate = DateTime.Now.AddDays(15), Status = "Todo", EstimatedHours = 25, ActualHours = 0 }
        };

        var notes = new List<Note>
        {
            new Note { Id = 1, ProjectId = 1, Content = "LINQ is very powerful for data manipulation",
                      CreatedDate = DateTime.Now.AddDays(-5), UpdatedDate = null, 
                      Tags = new[] { "C#", "LINQ", "Learning" } },
            new Note { Id = 2, ProjectId = 1, Content = "Need to practice more with GroupBy and Join operations",
                      CreatedDate = DateTime.Now.AddDays(-3), UpdatedDate = DateTime.Now.AddDays(-2),
                      Tags = new[] { "Practice", "Examples" } },
            new Note { Id = 3, ProjectId = 2, Content = "Wall color: Light Blue, Paint brand: Pars",
                      CreatedDate = DateTime.Now.AddDays(-10), UpdatedDate = null,
                      Tags = new[] { "Materials", "Colors" } },
            new Note { Id = 4, ProjectId = 3, Content = "Weekly goal: 3 gym sessions, 2 cardio days",
                      CreatedDate = DateTime.Now.AddDays(-20), UpdatedDate = DateTime.Now.AddDays(-15),
                      Tags = new[] { "Fitness", "Schedule" } }
        };

        var timeLogs = new List<TimeLog>
        {
            new TimeLog { Id = 1, TaskId = 1, StartTime = DateTime.Now.AddDays(-5).AddHours(10), 
                        EndTime = DateTime.Now.AddDays(-5).AddHours(12), Description = "Studied LINQ basics" },
            new TimeLog { Id = 2, TaskId = 1, StartTime = DateTime.Now.AddDays(-3).AddHours(14), 
                        EndTime = DateTime.Now.AddDays(-3).AddHours(16), Description = "Practiced LINQ queries" },
            new TimeLog { Id = 3, TaskId = 1, StartTime = DateTime.Now.AddDays(-1).AddHours(9), 
                        EndTime = DateTime.Now.AddDays(-1).AddHours(11), Description = "Worked on complex queries" },
            new TimeLog { Id = 4, TaskId = 4, StartTime = DateTime.Now.AddDays(-8).AddHours(13), 
                        EndTime = DateTime.Now.AddDays(-8).AddHours(16), Description = "Shopping for materials" },
            new TimeLog { Id = 5, TaskId = 5, StartTime = DateTime.Now.AddDays(-2).AddHours(8), 
                        EndTime = DateTime.Now.AddDays(-2).AddHours(11), Description = "Prepared walls for painting" },
            new TimeLog { Id = 6, TaskId = 5, StartTime = DateTime.Now.AddDays(-1).AddHours(14), 
                        EndTime = DateTime.Now.AddDays(-1).AddHours(17), Description = "First coat of paint" },
            new TimeLog { Id = 7, TaskId = 9, StartTime = DateTime.Now.AddDays(-7).AddHours(10), 
                        EndTime = DateTime.Now.AddDays(-7).AddHours(11), Description = "Researched healthy recipes" },
            new TimeLog { Id = 8, TaskId = 9, StartTime = DateTime.Now.AddDays(-5).AddHours(15), 
                        EndTime = DateTime.Now.AddDays(-5).AddHours(16), Description = "Created meal plan draft" }
        };

        var activeProjects = projects
            .Where(p => p.Status == "In Progress")
            .OrderByDescending(p => p.Priority)
            .ThenBy(p => p.DueDate)
            .Select(p => new
            {
                p.Title,
                p.Category,
                p.Priority,
                DaysSinceStart = (DateTime.Now - p.StartDate).Days,
                DaysUntilDue = p.DueDate.HasValue ? (p.DueDate.Value - DateTime.Now).Days : (int?)null,
                TaskCount = tasks.Count(t => t.ProjectId == p.Id),
                CompletedTasks = tasks.Count(t => t.ProjectId == p.Id && t.Status == "Done")
            })
            .ToList();

        Console.WriteLine("=== Active Projects ===");
        foreach (var project in activeProjects)
        {
            string priorityStars = new string('★', project.Priority) + new string('☆', 5 - project.Priority);
            Console.WriteLine($"{project.Title} ({project.Category})");
            Console.WriteLine($"  Priority: {priorityStars}");
            Console.WriteLine($"  Started: {project.DaysSinceStart} days ago");
            if (project.DaysUntilDue.HasValue)
                Console.WriteLine($"  Due in: {project.DaysUntilDue} days");
            Console.WriteLine($"  Tasks: {project.CompletedTasks}/{project.TaskCount} completed");
        }

        var overdueTasks = tasks
            .Where(t => t.DueDate < DateTime.Now && t.Status != "Done")
            .OrderBy(t => t.DueDate)
            .Select(t => new
            {
                t.Title,
                Project = projects.First(p => p.Id == t.ProjectId).Title,
                DaysOverdue = (DateTime.Now - t.DueDate).Days,
                t.Status,
                t.EstimatedHours,
                t.ActualHours
            })
            .ToList();

        Console.WriteLine("\n=== Overdue Tasks ===");
        if (overdueTasks.Any())
        {
            foreach (var task in overdueTasks)
            {
                Console.WriteLine($"{task.Title} ({task.Project}):");
                Console.WriteLine($"  Overdue by: {task.DaysOverdue} days");
                Console.WriteLine($"  Status: {task.Status}");
                Console.WriteLine($"  Estimated: {task.EstimatedHours}h, Actual: {task.ActualHours}h");
            }
        }
        else
        {
            Console.WriteLine("No overdue tasks! Good job!");
        }

          var projectTimeSpent = projects
            .Select(p => new
            {
                p.Title,
                TotalTimeSpent = timeLogs
                    .Where(tl => tasks.Any(t => t.Id == tl.TaskId && t.ProjectId == p.Id))
                    .Sum(tl => (tl.EndTime - tl.StartTime).TotalHours),
                TaskTimeSpent = tasks
                    .Where(t => t.ProjectId == p.Id)
                    .Sum(t => t.ActualHours),
                EstimatedTime = tasks
                    .Where(t => t.ProjectId == p.Id)
                    .Sum(t => t.EstimatedHours)
            })
            .Where(p => p.TotalTimeSpent > 0 || p.EstimatedTime > 0)
            .OrderByDescending(p => p.TotalTimeSpent)
            .ToList();

        Console.WriteLine("\n=== Time Spent on Projects ===");
        foreach (var project in projectTimeSpent)
        {
            Console.WriteLine($"{project.Title}:");
            Console.WriteLine($"  Logged Time: {project.TotalTimeSpent:F1}h");
            Console.WriteLine($"  Task Time: {project.TaskTimeSpent}h");
            Console.WriteLine($"  Estimated: {project.EstimatedTime}h");
            
            if (project.EstimatedTime > 0)
            {
                var progress = Math.Round(project.TaskTimeSpent / (double)project.EstimatedTime * 100, 1);
                Console.WriteLine($"  Progress: {progress}% of estimated time");
            }
        }

         var projectProgress = projects
            .Select(p => new
            {
                p.Title,
                p.Status,
                TotalTasks = tasks.Count(t => t.ProjectId == p.Id),
                CompletedTasks = tasks.Count(t => t.ProjectId == p.Id && t.Status == "Done"),
                Progress = tasks.Count(t => t.ProjectId == p.Id) > 0 ?
                    Math.Round((double)tasks.Count(t => t.ProjectId == p.Id && t.Status == "Done") / 
                              tasks.Count(t => t.ProjectId == p.Id) * 100, 1) : 0
            })
            .OrderByDescending(p => p.Progress)
            .ToList();

        Console.WriteLine("\n=== Project Progress ===");
        foreach (var project in projectProgress)
        {
            //string progressBar = GenerateProgressBar(project.Progress);
            Console.WriteLine($"{project.Title} ({project.Status}):");
            Console.WriteLine($"  Tasks: {project.CompletedTasks}/{project.TotalTasks} completed");
            Console.WriteLine($"  Progress: {project.Progress}%");
            //Console.WriteLine($"  {progressBar}");
        }


        }
    }
}