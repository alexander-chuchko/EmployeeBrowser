namespace BSATask.DAL.Entities;

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Teams")]
public class Team : EntityBase
{
    public Team()
    {
        Users = new List<User>();
        Projects = new List<Project>();
    }
    [StringLength(64, MinimumLength = 3)]
    public string? Name { get; set; }

    public DateTime CreatedAt { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<Project> Projects { get; set; }
}

