using AutoMapper;
using BSATask.Common.DTO;
using BSATask.Common.Interface;
using BSATask.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace BSATask.Common.Sevices
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TaskService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskDTO>> GetTasksAsync()
        {
            IEnumerable<TaskDTO> tasksDTO = null;

            var tasks = await _unitOfWork.Tasks.GetAllAsync<DAL.Entities.Task>();
            tasksDTO = _mapper.Map<IEnumerable<TaskDTO>>(tasks);

            return tasksDTO;
        }

        public async Task<TaskDTO> GetTaskByIdAsync(int id)
        {
            TaskDTO taskDTO = null;

            var tasks = await _unitOfWork.Tasks.GetAllAsync<DAL.Entities.Task>();
            var findedByIdTask = tasks.FirstOrDefault(v => v.Id == id);

            if (findedByIdTask is not null)
            {
                taskDTO = _mapper.Map<TaskDTO>(findedByIdTask);
            }

            return taskDTO;
        }

        public async Task<TaskDTO> AddTaskAsync(TaskDTO taskDTO)
        {
            if (taskDTO is not null)
            {
                var task = _mapper.Map<DAL.Entities.Task>(taskDTO);
                await _unitOfWork.Tasks.InsertAsync<DAL.Entities.Task>(task);
                await _unitOfWork.CommitAsync();

                var allTasks = await _unitOfWork.Tasks.GetAllAsync<DAL.Entities.Task>();
                var lastAddedTask = allTasks.LastOrDefault();

                return _mapper.Map<TaskDTO>(lastAddedTask);
            }

            return null;
        }

        public async Task UpdateTaskAsync(TaskDTO taskDTO)
        {
            var foundTask = GetTaskByIdAsync(taskDTO.Id);
            if (foundTask is not null)
            {
                var task = _mapper.Map<DAL.Entities.Task>(taskDTO);
                await _unitOfWork.Tasks.UpdateAsync<DAL.Entities.Task>(task);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await GetTaskByIdAsync(id);
            if (task is not null)
            {
                await _unitOfWork.Tasks.DeleteAsync<DAL.Entities.Task>(id);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
