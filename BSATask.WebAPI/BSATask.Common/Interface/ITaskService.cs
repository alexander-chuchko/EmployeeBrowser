using BSATask.Common.DTO;

namespace BSATask.Common.Interface
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDTO>> GetTasksAsync();
        Task<TaskDTO> GetTaskByIdAsync(int id);

        Task<TaskDTO> AddTaskAsync(TaskDTO taskDTO);
        Task UpdateTaskAsync(TaskDTO taskDTO);

        Task DeleteTaskAsync(int id);
    }
}
