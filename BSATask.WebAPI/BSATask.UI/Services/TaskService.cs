using BSATask.Common.DTO;
using BSATask.UI.Interfaces;
using BSATask.UI.Models;
using Task = System.Threading.Tasks.Task;

namespace BSATask.UI.Services
{
    public class TaskService
    {
        private Dictionary<int, Action> tasks;
        private System.Timers.Timer _timer;
        private readonly IApiService _apiService;
        private readonly IDisplayService _displayService;
        private List<StateTask> stateTasks = new List<StateTask>();

        public TaskService(IApiService apiService, IDisplayService displayService)
        {
            _apiService = apiService;
            _displayService = displayService;
            _timer = new System.Timers.Timer();
            tasks = GetTasks();
            stateTasks = CreateStateTasks().ToList();  
        }

        private Dictionary<int, Action> GetTasks()
        {
            return new Dictionary<int, Action>
            {
                {1, async () => {
                    var taskDTO = await _apiService.GetByIdTaskAsync(await GetAnyExistingId());
                    Console.WriteLine("\tWork GetByIdTaskAsync\n\n");
                    await _displayService.DisplayInfoTask(taskDTO.Id.ToString());
                }},
                {2, async () => {
                    var tasksDTO = await _apiService.GetAllTasksAsync();
                    Console.WriteLine("\tWork GetAllTasksAsync\n\n");
                    await _displayService.DisplayTasks();
                }},
                {3, async () => {
                    var addedTasksDTO = await _apiService.AddTaskAsync(AddTask());
                    if(addedTasksDTO is not null)
                    {
                        Console.WriteLine("\tWork AddTaskAsync\n\n");
                       await _displayService.DisplayInfoTask(addedTasksDTO.Id.ToString());
                    }
                }},
                {4, async () => {
                    var updateTaskDTO = await _apiService.UpdateTaskAsync(await UpdateTask());
                    Console.WriteLine("\tWork UpdateTaskAsync\n\n");
                    await _displayService.DisplayInfoTask(updateTaskDTO.Id.ToString());
                }},

            };
        }

        public async Task<int> MarkRandomTaskWithDelay(int delayMilliseconds)
        {
            var indexex = 0;
            var tcs = new TaskCompletionSource<int>();
            await Task.Delay(delayMilliseconds);
            RunTasks(delayMilliseconds);

            _timer.Elapsed += (sender, args) =>
            {
                Task.Run(() => 
                {
                    try
                    {
                        var randomTaskId = stateTasks[GetRandomIndex()].Id;
                        var task = stateTasks.Find(t => t.Id == randomTaskId);

                        if (task is not null)
                        {
                            var index = (int)task.Operation + 1;
                            task.IsCompleted = true;
                            tasks[index].Invoke();
                        }

                        tcs.SetResult(randomTaskId);

                        if (!stateTasks.Any(t => t.IsCompleted == false))
                        {
                            _timer.Stop();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                       tcs.SetException(ex);
                    }

                });
            };

            return await tcs.Task; 
        }

        private int GetRandomIndex()
        {
            return new Random().Next(0, stateTasks.Count - 1);
        }

        private void RunTasks(double delayMilliseconds)
        {
            _timer.Interval = delayMilliseconds;
            _timer.AutoReset = true;
            _timer.Start();
        }

        private void ConsoleCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            _timer.Stop();
        }

        private IEnumerable<StateTask> CreateStateTasks() 
        {

            for (int i = 0; i < 10; i++)
            {
                stateTasks.Add(new StateTask() { Id = i + 1 });
            }

            return stateTasks;
        }

        private TaskDTO AddTask()
        {
            return new TaskDTO()
            {
                ProjectId = 1,
                Name = Guid.NewGuid().ToString(),
                Description = $"The task is as follows: {Guid.NewGuid().ToString()} {Guid.NewGuid().ToString()} {Guid.NewGuid().ToString()}",
                State = TaskStateDTO.ToDo,
                CreatedAt = DateTime.Now,
            };
        }

        private async Task<TaskDTO> UpdateTask() 
        {
            var getId = await GetAnyExistingId();
            var taskDTO = await _apiService.GetByIdTaskAsync(getId.ToString());
            if (taskDTO is not null) 
            {
                taskDTO.Description = taskDTO.Description + DateTime.Now.ToString("yyyy:MM:dd:HH:mm:ss:fff");
            }

            return taskDTO;
        }

        private async Task<IEnumerable<int>> GetAllTaskIds()
        {
            var tasksDTO = await _apiService.GetAllTasksAsync();
            return tasksDTO.Select(task => task.Id);
        }

        private async Task<string> GetAnyExistingId() 
        {
            var id = 0;
            var tasksDTO = await _apiService.GetAllTasksAsync();

            if (tasksDTO is not null && tasksDTO.Count() is not 0)
            {
                id = tasksDTO.Select(task => task.Id).ToList()[new Random().Next(0, tasksDTO.Count())];
            }

            return id.ToString();
        }
    }
}
