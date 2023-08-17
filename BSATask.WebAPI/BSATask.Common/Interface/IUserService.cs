using BSATask.Common.DTO;

namespace BSATask.Common.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);

        Task<UserDTO> AddUserAsync(UserDTO userDTO);
        Task UpdateUserAsync(UserDTO userDTO);

        Task DeleteUserAsync(int id);
    }
}
