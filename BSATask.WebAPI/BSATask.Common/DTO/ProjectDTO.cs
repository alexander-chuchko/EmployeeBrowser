namespace BSATask.Common.DTO
{
    public class ProjectDTO : EntityBaseDTO
    {
        public int? UserId { get; set; }
        public int? TeamId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Deadline { get; set; }
    }
}
