
namespace BSATask.UI.Interfaces
{
    public interface IDisplayService
    {
        Task DeleteUser();
        Task DisplayUserById();
        Task DisplayUsers();
        Task DeleteTeam();
        Task DisplayTeamById();
        Task DisplayTeams();
        Task DeleteTask();
        Task DisplayTaskById();
        Task DisplayTasks();
        Task DisplayProjects();
        Task DisplayProjectById();
        Task DeleteProject();
        Task DisplayInfoTask(string id);
        void DisplayInfo();
    }
}
