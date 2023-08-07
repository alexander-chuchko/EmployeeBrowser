namespace BSATask.DAL.Entities;

using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Projects")]
public class Project : DAL.EntityBase
{
    public Project()
    {
        Tasks = new List<Entities.Task>();
    }
    public int? UserId { get; set; }

    public int? TeamId { get; set; }
    [StringLength(64, MinimumLength = 3)]
    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? Deadline { get; set; }

    public Team? Team { get; set; }
    public User? User { get; set; }

    public ICollection<Entities.Task> Tasks { get; set; }
}
