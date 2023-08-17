namespace BSATask.DAL.Entities;

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Tasks")]
public class Task : DAL.EntityBase
{
    public int ProjectId { get; set; }
    public int? UserId { get; set; }
    [StringLength(64, MinimumLength = 3)]
    public string? Name { get; set; }
    public string? Description { get; set; }
    public TaskState State { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? FinishedAt { get; set; }
    public User? User { get; set; }
    public Project? Project { get; set; }
}
