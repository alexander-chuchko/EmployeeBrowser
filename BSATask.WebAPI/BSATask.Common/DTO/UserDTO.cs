
namespace BSATask.Common.DTO
{
    public class UserDTO : EntityBaseDTO
    {
        public int? TeamId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
