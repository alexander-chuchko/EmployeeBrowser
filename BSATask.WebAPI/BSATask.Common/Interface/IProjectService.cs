using BSATask.Common.DTO;

namespace BSATask.Common.Interface
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDTO>> GetProjectsAsync();
        Task<ProjectDTO> GetProjectByIdAsync(int id);

        Task<ProjectDTO> AddProjectAsync(ProjectDTO projectDTO);

        Task UpdateProjectAsync(ProjectDTO projectDTO);

        Task DeleteProjectAsync(int id);
    }
}
