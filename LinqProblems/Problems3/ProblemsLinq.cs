namespace LinqProblems.Problems3
{
    public class ProblemsLinq
    {
        
    }

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
}