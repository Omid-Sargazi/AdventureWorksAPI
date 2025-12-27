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

public class ManageContacts
    {
        public static void Execute()
        {
             var contacts = new List<Contact>
        {
            new Contact { Id = 1, FirstName = "Ali", LastName = "Rezaei", Phone = "09123456789", 
                         Email = "ali@email.com", Company = "TechCo", JobTitle = "Developer",
                         AddedDate = DateTime.Now.AddDays(-30), LastContacted = DateTime.Now.AddDays(-5) },
            
            new Contact { Id = 2, FirstName = "Sara", LastName = "Mohammadi", Phone = "09129876543", 
                         Email = "sara@email.com", Company = "DesignPro", JobTitle = "Designer",
                         AddedDate = DateTime.Now.AddDays(-15), LastContacted = DateTime.Now.AddDays(-2) },
            
            new Contact { Id = 3, FirstName = "Reza", LastName = "Ahmadi", Phone = "09121122334", 
                         Email = "reza@email.com", Company = "BusinessCorp", JobTitle = "Manager",
                         AddedDate = DateTime.Now.AddDays(-60), LastContacted = DateTime.Now.AddDays(-10) },
            
            new Contact { Id = 4, FirstName = "Maryam", LastName = "Hosseini", Phone = "09123344556", 
                         Email = "maryam@email.com", Company = "HealthCare", JobTitle = "Doctor",
                         AddedDate = DateTime.Now.AddDays(-7), LastContacted = DateTime.Now.AddDays(-1) },
            
            new Contact { Id = 5, FirstName = "Hassan", LastName = "Karimi", Phone = "09124455667", 
                         Email = "hassan@email.com", Company = "EducationInc", JobTitle = "Teacher",
                         AddedDate = DateTime.Now.AddDays(-45), LastContacted = DateTime.Now.AddDays(-20) },
            
            new Contact { Id = 6, FirstName = "Fatemeh", LastName = "Alavi", Phone = "09125566778", 
                         Email = "fatemeh@email.com", Company = "TechCo", JobTitle = "QA Engineer",
                         AddedDate = DateTime.Now.AddDays(-3), LastContacted = null }
        };

        var groups = new List<ContactGroup>
        {
            new ContactGroup { Id = 1, Name = "Work", Description = "Colleagues and business contacts" },
            new ContactGroup { Id = 2, Name = "Friends", Description = "Personal friends" },
            new ContactGroup { Id = 3, Name = "Family", Description = "Family members" },
            new ContactGroup { Id = 4, Name = "Tech Community", Description = "Tech industry contacts" }
        };

        var groupMembers = new List<ContactGroupMember>
        {
            new ContactGroupMember { Id = 1, ContactId = 1, GroupId = 1 }, // Ali - Work
            new ContactGroupMember { Id = 2, ContactId = 1, GroupId = 4 }, // Ali - Tech Community
            new ContactGroupMember { Id = 3, ContactId = 2, GroupId = 1 }, // Sara - Work
            new ContactGroupMember { Id = 4, ContactId = 2, GroupId = 2 }, // Sara - Friends
            new ContactGroupMember { Id = 5, ContactId = 3, GroupId = 1 }, // Reza - Work
            new ContactGroupMember { Id = 6, ContactId = 4, GroupId = 2 }, // Maryam - Friends
            new ContactGroupMember { Id = 7, ContactId = 4, GroupId = 3 }, // Maryam - Family
            new ContactGroupMember { Id = 8, ContactId = 5, GroupId = 2 }, // Hassan - Friends
            new ContactGroupMember { Id = 9, ContactId = 6, GroupId = 1 }, // Fatemeh - Work
            new ContactGroupMember { Id = 10, ContactId = 6, GroupId = 4 } // Fatemeh - Tech Community
        };

        var interactions = new List<Interaction>
        {
            new Interaction { Id = 1, ContactId = 1, InteractionDate = DateTime.Now.AddDays(-5), 
                            Type = "Call", Notes = "Discussed project details", Duration = 15 },
            new Interaction { Id = 2, ContactId = 1, InteractionDate = DateTime.Now.AddDays(-20), 
                            Type = "Email", Notes = "Sent project proposal", Duration = 0 },
            new Interaction { Id = 3, ContactId = 2, InteractionDate = DateTime.Now.AddDays(-2), 
                            Type = "Meeting", Notes = "Coffee meeting", Duration = 45 },
            new Interaction { Id = 4, ContactId = 3, InteractionDate = DateTime.Now.AddDays(-10), 
                            Type = "Call", Notes = "Follow up call", Duration = 10 },
            new Interaction { Id = 5, ContactId = 4, InteractionDate = DateTime.Now.AddDays(-1), 
                            Type = "Message", Notes = "Birthday wishes", Duration = 0 },
            new Interaction { Id = 6, ContactId = 2, InteractionDate = DateTime.Now.AddDays(-15), 
                            Type = "Email", Notes = "Sent design files", Duration = 0 }
        };
        }
    }
}