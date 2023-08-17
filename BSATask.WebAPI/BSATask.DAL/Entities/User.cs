namespace BSATask.DAL.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Users")]
public class User : EntityBase
{
    public User()
    {
        Projects = new List<Project>();
        Tasks = new List<Entities.Task>();
    }

    public int? TeamId { get; set; }
    [StringLength(64, MinimumLength = 3)]
    public string FirstName { get; set; }
    [StringLength(64, MinimumLength = 3)]
    public string LastName { get; set; }

    public string? Email { get; set; }

    public DateTime RegisteredAt { get; set; }

    public DateTime BirthDay { get; set; }
    public Team Team { get; set; }
    public ICollection<Project> Projects { get; set; }
    public ICollection<Entities.Task> Tasks { get; set; }
}