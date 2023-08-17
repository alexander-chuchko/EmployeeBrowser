using BSATask.DAL.Entities;

namespace BSATask.DAL.Interfaces
{
    public interface IMock
    {
        public IEnumerable<Project> GetProjects();
        public IEnumerable<DAL.Entities.Task> GetTasks();
        public IEnumerable<Team> GetTeams();
        public IEnumerable<User> GetUsers();
    }
}
