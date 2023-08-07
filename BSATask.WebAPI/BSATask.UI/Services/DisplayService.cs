using BSATask.UI.Interfaces;

namespace BSATask.UI.Services
{
    public class DisplayService : IDisplayService
    {
        private readonly IApiService _apiService;
        public DisplayService(IApiService apiService)
        {
            _apiService = apiService;   
        }
        public async Task DeleteUser()
        {
            ClearConsole();
            DisplayInfo();

            Console.WriteLine("\tEnter user id");
            string? id = Console.ReadLine();

            if (Validation.IsValidNumber(id))
            {
                await _apiService.DeleteUserAsync(id);
            }
            else
            {
                Console.WriteLine("\tEnter incorrect data");
            }
        }

        public async Task DisplayUserById()
        {
            ClearConsole();
            DisplayInfo();

            Console.WriteLine("\tEnter user ID:");
            string? id = Console.ReadLine();

            if (Validation.IsValidNumber(id))
            {
                var user = await _apiService.GetByIdUserAsync(id);
                if (user is not null)
                {
                    Console.WriteLine($"\t{nameof(user.Id)} : {user.Id}\n\t" +
                        $"{nameof(user.FirstName)} : {user.FirstName}\n\t" +
                        $"{nameof(user.LastName)} : {user.LastName}\n\t" +
                        $"{nameof(user.Email)} : {user.Email}\n\t" +
                        $"{nameof(user.BirthDay)} : {user.BirthDay}\n\t" +
                        $"{nameof(user.RegisteredAt)} : {user.RegisteredAt.ToString("yyyy-MM-dd")}\n\t");
                }
                else
                {
                    Console.WriteLine($"\tProject ID {id} has no tasks");
                }
            }
            else
            {
                Console.WriteLine("\tEnter incorrect data");
            }
        }

        public async Task DisplayUsers()
        {
            ClearConsole();
            DisplayInfo();

            var result = await _apiService.GetAllUsersAsync();
            if (result.Count() is not 0)
            {
                Console.WriteLine("\tList of users:");

                result.ToList().ForEach(users =>
                {
                    Console.WriteLine($"\t{nameof(users.Id)} : {users.Id}\n\t" +
                        $"{nameof(users.FirstName)} : {users.FirstName}\n\t" +
                        $"{nameof(users.LastName)} : {users.LastName}\n\t" +
                        $"{nameof(users.Email)} : {users.Email}\n\t" +
                        $"{nameof(users.BirthDay)} : {users.BirthDay}\n\t" +
                        $"{nameof(users.RegisteredAt)} : {users.RegisteredAt.ToString("yyyy-MM-dd")}\n\t");
                });
            }
            else
            {
                Console.WriteLine($"\tNo projects");
            }
        }

        public async Task DeleteTeam()
        {
            ClearConsole();
            DisplayInfo();

            Console.WriteLine("\tEnter team id");
            string? id = Console.ReadLine();

            if (Validation.IsValidNumber(id))
            {
                await _apiService.DeleteTeamAsync(id);
            }
            else
            {
                Console.WriteLine("\tEnter incorrect data");
            }
        }

        public async Task DisplayTeamById()
        {
            ClearConsole();
            DisplayInfo();

            Console.WriteLine("\tEnter team ID:");
            string? id = Console.ReadLine();

            if (Validation.IsValidNumber(id))
            {
                var team = await _apiService.GetByIdTeamAsync(id);
                if (team is not null)
                {
                    Console.WriteLine($"\t{nameof(team.Id)} : {team.Id}\n\t" +
                        $"{nameof(team.Name)} : {team.Name}\n\t" +
                        $"{nameof(team.CreatedAt)} : {team.CreatedAt.ToString("yyyy-MM-dd")}\n\t");
                }
                else
                {
                    Console.WriteLine($"\tProject ID {id} has no tasks");
                }
            }
            else
            {
                Console.WriteLine("\tEnter incorrect data");
            }
        }

        public async Task DisplayTeams()
        {
            ClearConsole();
            DisplayInfo();

            var result = await _apiService.GetAllTeamsAsync();
            if (result.Count() is not 0)
            {
                Console.WriteLine("\tList of teams:");

                result.ToList().ForEach(teams =>
                {
                    Console.WriteLine($"\t{nameof(teams.Id)} : {teams.Id}\n\t" +
                        $"{nameof(teams.Name)} : {teams.Name}\n\t" +
                        $"{nameof(teams.Name)} : {teams.Name}\n\t" +
                        $"{nameof(teams.CreatedAt)} : {teams.CreatedAt.ToString("yyyy-MM-dd")}\n\t");
                });
            }
            else
            {
                Console.WriteLine($"\tNo projects");
            }
        }

        public async Task DeleteTask()
        {
            ClearConsole();
            DisplayInfo();

            Console.WriteLine("\tEnter task id");
            string? id = Console.ReadLine();

            if (Validation.IsValidNumber(id))
            {
                await _apiService.DeleteTaskAsync(id);
            }
            else
            {
                Console.WriteLine("\tEnter incorrect data");
            }
        }

        public async Task DisplayTaskById()
        {
            //ClearConsole();
            //DisplayInfo();

            Console.WriteLine("\tEnter task ID:");
            string? id = Console.ReadLine();

            if (Validation.IsValidNumber(id))
            {
                var task = await _apiService.GetByIdTaskAsync(id);
                if (task is not null)
                {
                    Console.WriteLine($"\t{nameof(task.Id)} : {task.Id}\n\t" +
                        $"{nameof(task.ProjectId)} : {task.ProjectId}\n\t" +
                        $"{nameof(task.UserId)} : {task.UserId}" +
                        $"{nameof(task.Name)} : {task.Name}\n\t" +
                        $"{nameof(task.Description)} : {task.Description}\n\t" +
                        $"{nameof(task.State)} : {task.State}\n\t" +
                        $"{nameof(task.CreatedAt)} : {task.CreatedAt.ToString("yyyy-MM-dd")}\n\t" +
                        $"{nameof(task.FinishedAt)} : {task.FinishedAt?.ToString("yyyy-MM-dd")}\n\t");
                }
                else
                {
                    Console.WriteLine($"\tProject ID {id} has no tasks");
                }
            }
            else
            {
                Console.WriteLine("\tEnter incorrect data");
            }
        }

        public async Task DisplayTasks()
        {
            //ClearConsole();
            //DisplayInfo();

            var result = await _apiService.GetAllTasksAsync();
            if (result.Count() is not 0)
            {
                Console.WriteLine("\tList of tasks:");

                result.ToList().ForEach(tasks =>
                {
                    Console.WriteLine($"\t{nameof(tasks.Id)} : {tasks.Id}\n\t" +
                        $"{nameof(tasks.ProjectId)} : {tasks.ProjectId}\n\t" +
                        $"{nameof(tasks.UserId)} : {tasks.UserId}" +
                        $"{nameof(tasks.Name)} : {tasks.Name}\n\t" +
                        $"{nameof(tasks.Description)} : {tasks.Description}\n\t" +
                        $"{nameof(tasks.State)} : {tasks.State}\n\t" +
                        $"{nameof(tasks.CreatedAt)} : {tasks.CreatedAt.ToString("yyyy-MM-dd")}\n\t" +
                        $"{nameof(tasks.FinishedAt)} : {tasks.FinishedAt?.ToString("yyyy-MM-dd")}\n\t");
                });
            }
            else
            {
                Console.WriteLine($"\tNo projects");
            }
        }

        public async Task DisplayProjects()
        {
            ClearConsole();
            DisplayInfo();

            var result = await _apiService.GetAllProjectsAsync();
            if (result.Count() is not 0)
            {
                Console.WriteLine("\tList of projects:");

                result.ToList().ForEach(projects =>
                {
                    Console.WriteLine($"\t{nameof(projects.Id)} : {projects.Id}\n\t" +
                        $"{nameof(projects.TeamId)} : {projects.TeamId}\n\t" +
                        $"{nameof(projects.Name)} : {projects.Name}" +
                        $"{nameof(projects.Description)} : {projects.Description}\n\t" +
                        $"{nameof(projects.CreatedAt)} : {projects.CreatedAt}\n\t" +
                        $"{nameof(projects.Deadline)} : {projects.Deadline}\n\t");
                });
            }
            else
            {
                Console.WriteLine($"\tNo projects");
            }
        }

        public async Task DisplayProjectById()
        {
            ClearConsole();
            DisplayInfo();

            Console.WriteLine("\tEnter user ID:");
            string? id = Console.ReadLine();

            if (Validation.IsValidNumber(id))
            {
                var project = await _apiService.GetByIdProjectAsync(id);
                if (project is not null)
                {
                    Console.WriteLine($"\t{nameof(project.Id)} : {project.Id}\n\t" +
                    $"{nameof(project.TeamId)} : {project.TeamId}\n\t" +
                    $"{nameof(project.Name)} : {project.Name}" +
                    $"{nameof(project.Description)} : {project.Description}\n\t" +
                    $"{nameof(project.CreatedAt)} : {project.CreatedAt}\n\t" +
                    $"{nameof(project.Deadline)} : {project.Deadline}\n\t");
                }
                else
                {
                    Console.WriteLine($"\tProject ID {id} has no tasks");
                }
            }
            else
            {
                Console.WriteLine("\tEnter incorrect data");
            }
        }

        public async Task DeleteProject()
        {
            ClearConsole();
            DisplayInfo();

            Console.WriteLine("\tEnter project id");
            string? id = Console.ReadLine();

            if (Validation.IsValidNumber(id))
            {
                await _apiService.DeleteProjectAsync(id);
            }
            else
            {
                Console.WriteLine("\tEnter incorrect data");
            }
        }

        public async Task DisplayInfoTask(string id)
        {
            var task = await _apiService.GetByIdTaskAsync(id);
            if (task is not null)
            {
                Console.WriteLine($"\t{nameof(task.Id)} : {task.Id}\n\t" +
                    $"{nameof(task.ProjectId)} : {task.ProjectId}\n\t" +
                    $"{nameof(task.UserId)} : {task.UserId}" +
                    $"{nameof(task.Name)} : {task.Name}\n\t" +
                    $"{nameof(task.Description)} : {task.Description}\n\t" +
                    $"{nameof(task.State)} : {task.State}\n\t" +
                    $"{nameof(task.CreatedAt)} : {task.CreatedAt.ToString("yyyy-MM-dd")}\n\t" +
                    $"{nameof(task.FinishedAt)} : {task.FinishedAt?.ToString("yyyy-MM-dd")}\n\t");
            }
            else
            {
                Console.WriteLine($"\tProject ID {id} has no tasks");
            }
        }

        private void ClearConsole()
        {
            Console.Clear();
        }

        private void ChangedColor(ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
        }

        public void DisplayInfo()
        {
            ClearConsole();
            ChangedColor(ConsoleColor.Red);

            Console.WriteLine("\n\t\t\t\tProject Async-Await");
            ChangedColor(ConsoleColor.Yellow);

            Console.WriteLine("\n\tMENU");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n\t" +
                "1 - Display Projects \n\t" +
                "2 - Display Project By Id\n\t" +
                "3 - Delete Id\n\t" +
                "4 - Display Tasks\n\t" +
                "5 - Display Task By Id\n\t" +
                "6 - Delete Task\n\t" +
                "7 - Display Teams\n\t" +
                "8 - Display Team By Id\n\t" +
                "9 - Delete Team\n\t" +
                "10 - Display Users\n\t" +
                "11 - Display User By Id\n\t" +
                "12 - Delete User\n\t"+
                "13 - Run Background Tasks \n\t");

            ChangedColor(ConsoleColor.Yellow);
            Console.WriteLine("\n\tSelect the desired item:\n");
            ChangedColor(ConsoleColor.White);
        }

    }
}
