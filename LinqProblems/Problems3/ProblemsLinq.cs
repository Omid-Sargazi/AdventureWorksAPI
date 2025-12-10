namespace LinqProblems.Problems3
{
    

    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Budget { get; set; }
    }

    public class TeamMember
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public decimal HourlyRate { get; set; }
}

public class Task
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; } // "High", "Medium", "Low"
    public string Status { get; set; } // "Not Started", "In Progress", "Completed"
    public int EstimatedHours { get; set; }
    public int ActualHours { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? CompletedDate { get; set; }
}

public class TaskAssignment
{
    public int Id { get; set; }
    public int TaskId { get; set; }
    public int TeamMemberId { get; set; }
    public DateTime AssignedDate { get; set; }
}

public class ProblemsLinq
    {
        public static void Execute()
        {
             var projects = new List<Project>
        {
            new Project { Id = 1, Name = "Website Redesign", StartDate = DateTime.Now.AddDays(-30), 
                         EndDate = DateTime.Now.AddDays(30), Budget = 50000 },
            new Project { Id = 2, Name = "Mobile App Development", StartDate = DateTime.Now.AddDays(-15), 
                         EndDate = DateTime.Now.AddDays(45), Budget = 80000 }
        };

        var teamMembers = new List<TeamMember>
        {
            new TeamMember { Id = 1, Name = "Ali Developer", Role = "Developer", HourlyRate = 50 },
            new TeamMember { Id = 2, Name = "Sara Designer", Role = "Designer", HourlyRate = 40 },
            new TeamMember { Id = 3, Name = "Reza Tester", Role = "QA Engineer", HourlyRate = 45 },
            new TeamMember { Id = 4, Name = "Maryam PM", Role = "Project Manager", HourlyRate = 60 }
        };

        var tasks = new List<Task>
        {
            // Project 1 tasks
            new Task { Id = 1, ProjectId = 1, Title = "Design Homepage", Description = "Create homepage design", 
                      Priority = "High", Status = "Completed", EstimatedHours = 20, ActualHours = 18, 
                      DueDate = DateTime.Now.AddDays(-5), CompletedDate = DateTime.Now.AddDays(-6) },
            new Task { Id = 2, ProjectId = 1, Title = "Develop Contact Form", Description = "Implement contact form functionality", 
                      Priority = "Medium", Status = "In Progress", EstimatedHours = 15, ActualHours = 10, 
                      DueDate = DateTime.Now.AddDays(5), CompletedDate = null },
            new Task { Id = 3, ProjectId = 1, Title = "SEO Optimization", Description = "Optimize website for search engines", 
                      Priority = "Low", Status = "Not Started", EstimatedHours = 25, ActualHours = 0, 
                      DueDate = DateTime.Now.AddDays(20), CompletedDate = null },
            
            // Project 2 tasks
            new Task { Id = 4, ProjectId = 2, Title = "App UI Design", Description = "Design mobile app interface", 
                      Priority = "High", Status = "In Progress", EstimatedHours = 30, ActualHours = 20, 
                      DueDate = DateTime.Now.AddDays(10), CompletedDate = null },
            new Task { Id = 5, ProjectId = 2, Title = "Backend API", Description = "Develop REST API", 
                      Priority = "High", Status = "Completed", EstimatedHours = 40, ActualHours = 35, 
                      DueDate = DateTime.Now.AddDays(-2), CompletedDate = DateTime.Now.AddDays(-3) },
            new Task { Id = 6, ProjectId = 2, Title = "Testing", Description = "Quality assurance testing", 
                      Priority = "Medium", Status = "Not Started", EstimatedHours = 20, ActualHours = 0, 
                      DueDate = DateTime.Now.AddDays(25), CompletedDate = null }
        };

        var assignments = new List<TaskAssignment>
        {
            new TaskAssignment { Id = 1, TaskId = 1, TeamMemberId = 2, AssignedDate = DateTime.Now.AddDays(-35) },
            new TaskAssignment { Id = 2, TaskId = 2, TeamMemberId = 1, AssignedDate = DateTime.Now.AddDays(-20) },
            new TaskAssignment { Id = 3, TaskId = 3, TeamMemberId = 1, AssignedDate = DateTime.Now.AddDays(-10) },
            new TaskAssignment { Id = 4, TaskId = 4, TeamMemberId = 2, AssignedDate = DateTime.Now.AddDays(-12) },
            new TaskAssignment { Id = 5, TaskId = 5, TeamMemberId = 1, AssignedDate = DateTime.Now.AddDays(-25) },
            new TaskAssignment { Id = 6, TaskId = 6, TeamMemberId = 3, AssignedDate = DateTime.Now.AddDays(-5) },
            new TaskAssignment { Id = 7, TaskId = 4, TeamMemberId = 4, AssignedDate = DateTime.Now.AddDays(-8) } // Multiple assignments
        };

        var projectStatus = tasks
            .GroupBy(t => t.ProjectId)
            .Select(g => new
            {
                ProjectId = g.Key,
                TotalTasks = g.Count(),
                CompletedTasks = g.Count(t => t.Status == "Completed"),
                InProgressTasks = g.Count(t => t.Status == "In Progress"),
                NotStartedTasks = g.Count(t => t.Status == "Not Started"),
                TotalEstimatedHours = g.Sum(t => t.EstimatedHours),
                TotalActualHours = g.Sum(t => t.ActualHours)
            })
            .Join(projects,
                  stat => stat.ProjectId,
                  project => project.Id,
                  (stat, project) => new
                  {
                      project.Name,
                      CompletionPercentage = Math.Round((double)stat.CompletedTasks / stat.TotalTasks * 100, 1),
                      stat.TotalTasks,
                      stat.CompletedTasks,
                      stat.InProgressTasks,
                      stat.NotStartedTasks,
                      stat.TotalEstimatedHours,
                      stat.TotalActualHours,
                      HoursVariance = stat.TotalActualHours - stat.TotalEstimatedHours
                  })
            .OrderByDescending(p => p.CompletionPercentage)
            .ToList();

        Console.WriteLine("=== Project Status Overview ===");
        foreach (var project in projectStatus)
        {
            Console.WriteLine($"{project.Name}: {project.CompletionPercentage}% complete");
            Console.WriteLine($"  Tasks: {project.CompletedTasks}/{project.TotalTasks} completed");
            Console.WriteLine($"  Status: {project.InProgressTasks} in progress, {project.NotStartedTasks} not started");
            Console.WriteLine($"  Hours: Estimated {project.TotalEstimatedHours}h, Actual {project.TotalActualHours}h");
            //Console.WriteLine($"  Variance: {project.HoursVariance}h ({project.HoursVariance > 0 ? "Over" : "Under"} budget)");
        }

        var memberTasks = assignments
            .Join(tasks,
                  assignment => assignment.TaskId,
                  task => task.Id,
                  (assignment, task) => new { assignment, task })
            .Join(teamMembers,
                  x => x.assignment.TeamMemberId,
                  member => member.Id,
                  (x, member) => new
                  {
                      MemberName = member.Name,
                      MemberRole = member.Role,
                      TaskTitle = x.task.Title,
                      TaskStatus = x.task.Status,
                      TaskPriority = x.task.Priority,
                      x.task.EstimatedHours,
                      x.task.ActualHours,
                      x.task.DueDate
                  })
            .GroupBy(x => x.MemberName)
            .Select(g => new
            {
                MemberName = g.Key,
                Role = g.First().MemberRole,
                TotalTasks = g.Count(),
                CompletedTasks = g.Count(t => t.TaskStatus == "Completed"),
                HighPriorityTasks = g.Count(t => t.TaskPriority == "High"),
                TotalEstimatedHours = g.Sum(t => t.EstimatedHours),
                TotalActualHours = g.Sum(t => t.ActualHours)
            })
            .OrderByDescending(m => m.TotalTasks)
            .ToList();

        Console.WriteLine("\n=== Team Member Workload ===");
        foreach (var member in memberTasks)
        {
            Console.WriteLine($"{member.MemberName} ({member.Role}):");
            Console.WriteLine($"  Tasks: {member.TotalTasks} total, {member.CompletedTasks} completed");
            Console.WriteLine($"  High Priority: {member.HighPriorityTasks} tasks");
            Console.WriteLine($"  Hours: Estimated {member.TotalEstimatedHours}h, Actual {member.TotalActualHours}h");
        }


         var overdueTasks = tasks
            .Where(t => t.Status != "Completed" && t.DueDate < DateTime.Now)
            .OrderBy(t => t.DueDate)
            .Select(t => new
            {
                t.Title,
                t.ProjectId,
                OverdueBy = (DateTime.Now - t.DueDate).Days,
                t.Priority,
                t.Status
            })
            .Join(projects,
                  task => task.ProjectId,
                  project => project.Id,
                  (task, project) => new
                  {
                      task.Title,
                      ProjectName = project.Name,
                      task.OverdueBy,
                      task.Priority,
                      task.Status
                  })
            .ToList();

        Console.WriteLine("\n=== Overdue Tasks ===");
        if (overdueTasks.Any())
        {
            foreach (var task in overdueTasks)
            {
                Console.WriteLine($"{task.Title} ({task.ProjectName})");
                Console.WriteLine($"  Overdue by: {task.OverdueBy} days");
                Console.WriteLine($"  Priority: {task.Priority}, Status: {task.Status}");
            }
        }
        else
        {
            Console.WriteLine("No overdue tasks! Great work!");
        }


        var workloadAnalysis = assignments
            .Join(tasks.Where(t => t.Status != "Completed"),
                  assignment => assignment.TaskId,
                  task => task.Id,
                  (assignment, task) => new { assignment, task })
            .GroupBy(x => x.assignment.TeamMemberId)
            .Select(g => new
            {
                TeamMemberId = g.Key,
                TotalAssignedHours = g.Sum(x => x.task.EstimatedHours),
                TaskCount = g.Count(),
                HighPriorityCount = g.Count(x => x.task.Priority == "High")
            })
            .Join(teamMembers,
                  workload => workload.TeamMemberId,
                  member => member.Id,
                  (workload, member) => new
                  {
                      member.Name,
                      member.Role,
                      workload.TotalAssignedHours,
                      workload.TaskCount,
                      workload.HighPriorityCount,
                      WorkloadLevel = workload.TotalAssignedHours switch
                      {
                          > 60 => "Heavy",
                          > 30 => "Moderate",
                          _ => "Light"
                      }
                  })
            .OrderByDescending(w => w.TotalAssignedHours)
            .ToList();

        Console.WriteLine("\n=== Workload Analysis ===");
        foreach (var workload in workloadAnalysis)
        {
            Console.WriteLine($"{workload.Name} ({workload.Role}): {workload.WorkloadLevel} workload");
            Console.WriteLine($"  Assigned Hours: {workload.TotalAssignedHours}h");
            Console.WriteLine($"  Tasks: {workload.TaskCount} ({workload.HighPriorityCount} high priority)");
        }

        var highPriorityTasks = tasks
            .Where(t => t.Priority == "High")
            .OrderBy(t => t.DueDate)
            .Select(t => new
            {
                t.Title,
                t.Status,
                t.DueDate,
                DaysUntilDue = (t.DueDate - DateTime.Now).Days,
                t.EstimatedHours
            })
            .ToList();

        Console.WriteLine("\n=== High Priority Tasks ===");
        foreach (var task in highPriorityTasks)
        {
            string urgency = task.DaysUntilDue switch
            {
                < 0 => "OVERDUE",
                < 3 => "URGENT",
                < 7 => "SOON",
                _ => "PLANNED"
            };
            
            Console.WriteLine($"{task.Title} - {urgency}");
            Console.WriteLine($"  Status: {task.Status}, Due: {task.DueDate:yyyy-MM-dd}");
            Console.WriteLine($"  Days left: {task.DaysUntilDue}, Estimated: {task.EstimatedHours}h");
        }

        var projectCosts = assignments
            .Join(tasks,
                  assignment => assignment.TaskId,
                  task => task.Id,
                  (assignment, task) => new { assignment, task })
            .Join(teamMembers,
                  x => x.assignment.TeamMemberId,
                  member => member.Id,
                  (x, member) => new
                  {
                      x.task.ProjectId,
                      TaskCost = x.task.ActualHours * member.HourlyRate,
                      EstimatedCost = x.task.EstimatedHours * member.HourlyRate
                  })
            .GroupBy(x => x.ProjectId)
            .Select(g => new
            {
                ProjectId = g.Key,
                ActualCost = g.Sum(x => x.TaskCost),
                EstimatedCost = g.Sum(x => x.EstimatedCost)
            })
            .Join(projects,
                  cost => cost.ProjectId,
                  project => project.Id,
                  (cost, project) => new
                  {
                      project.Name,
                      cost.ActualCost,
                      cost.EstimatedCost,
                      project.Budget,
                      CostVariance = project.Budget - cost.ActualCost,
                      BudgetUsage = Math.Round(cost.ActualCost / project.Budget * 100, 1)
                  })
            .ToList();

        Console.WriteLine("\n=== Project Cost Analysis ===");
        foreach (var cost in projectCosts)
        {
            Console.WriteLine($"{cost.Name}:");
            Console.WriteLine($"  Budget: ${cost.Budget}, Actual: ${cost.ActualCost}");
            Console.WriteLine($"  Estimated: ${cost.EstimatedCost}, Usage: {cost.BudgetUsage}%");
            Console.WriteLine($"  Variance: ${cost.CostVariance} ({cost.CostVariance > 0 ? "Under" : "Over"} budget)");
        }
        }
        
    }
}