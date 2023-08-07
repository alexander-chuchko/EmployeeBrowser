using BSATask.Common.DTO;

namespace BSATask.UI.Interfaces
{
    public interface IApiService
    {
        #region  ---Project interface---

        Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync();

        Task<ProjectDTO> GetByIdProjectAsync(string id);

        Task<ProjectDTO> AddProjectAsync(ProjectDTO projectDTO);

        Task<ProjectDTO> UpdateProjectAsync(ProjectDTO projectDTO);

        Task DeleteProjectAsync(string id);

        #endregion

            
        #region  ---Task interface---

        Task<IEnumerable<TaskDTO>> GetAllTasksAsync();

        Task<TaskDTO> GetByIdTaskAsync(string id);

        Task<TaskDTO> AddTaskAsync(TaskDTO taskDTO);

        Task<TaskDTO> UpdateTaskAsync(TaskDTO taskDTO);

        Task DeleteTaskAsync(string id);
        #endregion

        #region  ---Team interface---

        Task<IEnumerable<TeamDTO>> GetAllTeamsAsync();

        Task<TeamDTO> GetByIdTeamAsync(string id);

        Task<TeamDTO> AddTeamAsync(TeamDTO teamDTO);

        Task<TeamDTO> UpdateTeamAsync(TeamDTO teamDTO);

        Task DeleteTeamAsync(string id);
        #endregion

        #region  ---User interface---

        Task<IEnumerable<UserDTO>> GetAllUsersAsync();

        Task<UserDTO> GetByIdUserAsync(string id);

        Task<UserDTO> AddUserAsync(UserDTO teamDTO);

        Task<UserDTO> UpdateUserAsync(UserDTO teamDTO);

        Task DeleteUserAsync(string id);

        #endregion
    }
}
