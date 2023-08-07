using BSATask.Common.Sevices;
using BSATask.UI.Interfaces;
using BSATask.UI.Services;
using Task = System.Threading.Tasks.Task;

namespace BSATask.UI
{
    public class UserInterface
    {
        private readonly IDisplayService _displayService;
        private Dictionary<int, Func<Task>> methodDictionary;
        private string key;
        public UserInterface(IDisplayService displayService)
        {
            _displayService = displayService;
            methodDictionary = GetInitializedMenuItems(); 
        }

        private Dictionary<int, Func<Task>> GetInitializedMenuItems()
        {
            return new Dictionary<int, Func<Task>>
            {
                {1, DisplayProjects},
                {2, DisplayProjectById},
                {3, DeleteProject},

                {4, DisplayTasks},
                {5, DisplayTaskById},
                {6, DeleteTask},

                {7, DisplayTeams},
                {8, DisplayTeamById},
                {9, DeleteTeam},

                {10, DisplayUsers},
                {11, DisplayUserById},
                {12, DeleteUser},
                {13, RunBackgroundTasks}
            };
        }

        private async Task DeleteUser()
        {
            await _displayService.DeleteUser();
        }

        private async Task DisplayUserById()
        {
            await _displayService.DisplayUserById();
        }

        private async Task DisplayUsers()
        {
            await _displayService.DisplayUsers();
        }

        private async Task DeleteTeam()
        {
            await _displayService.DeleteTeam();
        }

        private async Task DisplayTeamById()
        {
            await _displayService.DisplayTeamById();
        }

        private async Task DisplayTeams()
        {
            await _displayService.DisplayTeams();
        }

        private async Task DeleteTask()
        {
            await _displayService.DeleteTask();
        }

        private async Task DisplayTaskById()
        {
            await _displayService.DisplayTaskById();
        }

        private async Task DisplayTasks()
        {
           await _displayService.DisplayTasks();
        }

        private async Task DisplayProjects()
        {
            await _displayService.DisplayProjects();
        }

        private async Task DisplayProjectById()
        {
            await _displayService.DisplayProjectById();
        }

        private async Task DeleteProject()
        {
            await _displayService.DeleteProject();
        }

        private void ChangedColor(ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
        }

        private async Task RunBackgroundTasks()
        {
            var queries = new BSATask.UI.Services.TaskService(new ApiService(), new DisplayService(new ApiService()));
            var markedTaskId = await queries.MarkRandomTaskWithDelay(1000);
        }
        public void RunApplication()
        {
            _displayService.DisplayInfo();

            do
            {
                key = Console.ReadLine();

                if (Validation.IsValidMenuItem(key, methodDictionary.Count))
                {
                    methodDictionary[int.Parse(key)].Invoke();
                }
                else if (key != "e")
                {
                    Console.WriteLine("Invalid value specified!");
                }

                ChangedColor(ConsoleColor.Red);
                Console.WriteLine("\n\tEXIT THE APPLICATION - 'e'\n");
                ChangedColor(ConsoleColor.White);

            } while (key != "e");
        }
    }
}
