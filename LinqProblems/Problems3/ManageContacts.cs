namespace LinqProblems.Problems3
{
    public class Contact
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Company { get; set; }
    public string JobTitle { get; set; }
    public DateTime AddedDate { get; set; }
    public DateTime? LastContacted { get; set; }
}

public class ContactGroup
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class ContactGroupMember
{
    public int Id { get; set; }
    public int ContactId { get; set; }
    public int GroupId { get; set; }
}

public class Interaction
{
    public int Id { get; set; }
    public int ContactId { get; set; }
    public DateTime InteractionDate { get; set; }
    public string Type { get; set; } // "Call", "Email", "Meeting", "Message"
    public string Notes { get; set; }
    public int Duration { get; set; } // in minutes
}
}