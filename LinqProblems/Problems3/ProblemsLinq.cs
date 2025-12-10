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
        }   
    }
}