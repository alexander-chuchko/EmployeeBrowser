using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using BSATask.Common.DTO;
using BSATask.UI.Interfaces;

namespace BSATask.UI.Services
{
    public class ApiService : IApiService
    {
        private HttpClient _client;
        public ApiService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7245/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #region  --- Project interface implementation  ---

        public async Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync()
        {
            IEnumerable<ProjectDTO>? projects = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync(Constants.WEB_API_PROJECTS);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                {
                    projects = await response.Content.ReadFromJsonAsync<IEnumerable<ProjectDTO>>();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"\tHTTP Request Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"\tJSON Deserialization Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
            }

            return projects;
        }

        public async Task<ProjectDTO> GetByIdProjectAsync(string id)
        {
            ProjectDTO? project = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync($"{Constants.WEB_API_PROJECTS}/{id}");

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                {
                    project = await response.Content.ReadFromJsonAsync<ProjectDTO>();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"\tHTTP Request Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"\tJSON Deserialization Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tError:{ex.Message}");
            }

            return project;
        }

        public async Task<ProjectDTO> AddProjectAsync(ProjectDTO projectDTO)
        {
            ProjectDTO? addedProjectDTO = null;

            try
            {
                HttpResponseMessage response = await _client.PostAsJsonAsync(Constants.WEB_API_PROJECTS, projectDTO);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.Created)
                {
                    addedProjectDTO = await response.Content.ReadFromJsonAsync<ProjectDTO>();
                }

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"\tHTTP Request Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"\tJSON Deserialization Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tError:{ex.Message}");
            }

            return addedProjectDTO;
        }

        public async Task<ProjectDTO> UpdateProjectAsync(ProjectDTO projectDTO)
        {
            ProjectDTO? updatedProjectDTO = null;

            try
            {
                if (projectDTO != null) 
                {
                    HttpResponseMessage response = await _client.PutAsJsonAsync(Constants.WEB_API_PROJECTS, projectDTO);

                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.Created)
                    {
                        updatedProjectDTO = await response.Content.ReadFromJsonAsync<ProjectDTO>();
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"\tHTTP Request Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"\tJSON Deserialization Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tError:{ex.Message}");
            }

            return updatedProjectDTO;
        }

        public async Task DeleteProjectAsync(string id)
        {
            try
            {
                HttpResponseMessage response = await _client.DeleteAsync($"{Constants.WEB_API_PROJECTS}/{id}");

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode && response.IsSuccessStatusCode)
                {
                    ShowStatusCode(response.StatusCode, nameof(DeleteProjectAsync));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tError:{ex.Message}");
            }
        }


        public async Task<IEnumerable<TaskDTO>> GetAllTasksAsync()
        {
            IEnumerable<TaskDTO>? taskts = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync(Constants.WEB_API_TASKS);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                {
                    taskts = await response.Content.ReadFromJsonAsync<IEnumerable<TaskDTO>>();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"\tHTTP Request Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"\tJSON Deserialization Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
            }

            return taskts;
        }

        public async Task<TaskDTO> GetByIdTaskAsync(string id)
        {
            TaskDTO? taskDTO = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync($"{Constants.WEB_API_TASKS}/{id}");

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                {
                    taskDTO = await response.Content.ReadFromJsonAsync<TaskDTO>();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"\tHTTP Request Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"\tJSON Deserialization Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tError:{ex.Message}");
            }

            return taskDTO;
        }

        public async Task<TaskDTO> AddTaskAsync(TaskDTO taskDTO)
        {
            TaskDTO? addedTaskDTO = null;

            try
            {
                HttpResponseMessage response = await _client.PostAsJsonAsync(Constants.WEB_API_TASKS, taskDTO);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.Created)
                {
                    addedTaskDTO = await response.Content.ReadFromJsonAsync<TaskDTO>();
                }

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"\tHTTP Request Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"\tJSON Deserialization Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tError:{ex.Message}");
            }

            return addedTaskDTO;
        }

        public async Task<TaskDTO> UpdateTaskAsync(TaskDTO taskDTO)
        {
            TaskDTO? updatedTaskDTO = null;

            try
            {
                if (taskDTO != null)
                {
                    HttpResponseMessage response = await _client.PutAsJsonAsync(Constants.WEB_API_TASKS, taskDTO);

                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.Created)
                    {
                        updatedTaskDTO = await response.Content.ReadFromJsonAsync<TaskDTO>();
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"\tHTTP Request Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"\tJSON Deserialization Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tError:{ex.Message}");
            }

            return updatedTaskDTO;
        }

        public async Task DeleteTaskAsync(string id)
        {
            try
            {
                HttpResponseMessage response = await _client.DeleteAsync($"{Constants.WEB_API_TASKS}/{id}");

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode && response.IsSuccessStatusCode)
                {
                    ShowStatusCode(response.StatusCode, nameof(DeleteTaskAsync));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tError:{ex.Message}");
            }
        }

        public async Task<IEnumerable<TeamDTO>> GetAllTeamsAsync()
        {
            IEnumerable<TeamDTO>? teams = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync(Constants.WEB_API_TEAMS);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                {
                    teams = await response.Content.ReadFromJsonAsync<IEnumerable<TeamDTO>>();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"\tHTTP Request Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"\tJSON Deserialization Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
            }

            return teams;
        }

        public async Task<TeamDTO> GetByIdTeamAsync(string id)
        {
            TeamDTO? teamDTO = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync($"{Constants.WEB_API_TEAMS}/{id}");

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                {
                    teamDTO = await response.Content.ReadFromJsonAsync<TeamDTO>();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"\tHTTP Request Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"\tJSON Deserialization Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tError:{ex.Message}");
            }

            return teamDTO;
        }

        public async Task<TeamDTO> AddTeamAsync(TeamDTO teamDTO)
        {
            TeamDTO? addedTeamDTO = null;

            try
            {
                HttpResponseMessage response = await _client.PostAsJsonAsync(Constants.WEB_API_TEAMS, teamDTO);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.Created)
                {
                    addedTeamDTO = await response.Content.ReadFromJsonAsync<TeamDTO>();
                }

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"\tHTTP Request Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"\tJSON Deserialization Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tError:{ex.Message}");
            }

            return addedTeamDTO;
        }

        public async Task<TeamDTO> UpdateTeamAsync(TeamDTO teamDTO)
        {
            TeamDTO? updatedTeamDTO = null;

            try
            {
                if (teamDTO != null)
                {
                    HttpResponseMessage response = await _client.PutAsJsonAsync(Constants.WEB_API_TEAMS, teamDTO);

                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.Created)
                    {
                        updatedTeamDTO = await response.Content.ReadFromJsonAsync<TeamDTO>();
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"\tHTTP Request Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"\tJSON Deserialization Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tError:{ex.Message}");
            }

            return updatedTeamDTO;
        }

        public async Task DeleteTeamAsync(string id)
        {
            try
            {
                HttpResponseMessage response = await _client.DeleteAsync($"{Constants.WEB_API_TEAMS}/{id}");

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode && response.IsSuccessStatusCode)
                {
                    ShowStatusCode(response.StatusCode, nameof(DeleteTeamAsync));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tError:{ex.Message}");
            }
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            IEnumerable<UserDTO>? users = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync(Constants.WEB_API_USERS);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                {
                    users = await response.Content.ReadFromJsonAsync<IEnumerable<UserDTO>>();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"\tHTTP Request Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"\tJSON Deserialization Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
            }

            return users;
        }

        public async Task<UserDTO> GetByIdUserAsync(string id)
        {
            UserDTO? user = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync($"{Constants.WEB_API_USERS}/{id}");

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                {
                    user = await response.Content.ReadFromJsonAsync<UserDTO>();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"\tHTTP Request Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"\tJSON Deserialization Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tError:{ex.Message}");
            }

            return user;
        }

        public async Task<UserDTO> AddUserAsync(UserDTO userDTO)
        {
            UserDTO? addedUserDTO = null;

            try
            {
                HttpResponseMessage response = await _client.PostAsJsonAsync(Constants.WEB_API_USERS, addedUserDTO);

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.Created)
                {
                    addedUserDTO = await response.Content.ReadFromJsonAsync<UserDTO>();
                }

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"\tHTTP Request Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"\tJSON Deserialization Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tError:{ex.Message}");
            }

            return addedUserDTO;
        }

        public async Task<UserDTO> UpdateUserAsync(UserDTO userDTO)
        {
            UserDTO? updatedUserDTO = null;

            try
            {
                if (userDTO != null)
                {
                    HttpResponseMessage response = await _client.PutAsJsonAsync(Constants.WEB_API_USERS, userDTO);

                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.Created)
                    {
                        updatedUserDTO = await response.Content.ReadFromJsonAsync<UserDTO>();
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"\tHTTP Request Error: {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"\tJSON Deserialization Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tError:{ex.Message}");
            }

            return updatedUserDTO;
        }

        public async Task DeleteUserAsync(string id)
        {
            try
            {
                HttpResponseMessage response = await _client.DeleteAsync($"{Constants.WEB_API_USERS}/{id}");

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode && response.IsSuccessStatusCode)
                {
                    ShowStatusCode(response.StatusCode, nameof(DeleteUserAsync));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\tError:{ex.Message}");
            }
        }
        #endregion

        private void ShowStatusCode(HttpStatusCode httpStatusCode, string nameMethod)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\t\tWorked out the method: {nameMethod}\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\t\tStatus code: {httpStatusCode}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
