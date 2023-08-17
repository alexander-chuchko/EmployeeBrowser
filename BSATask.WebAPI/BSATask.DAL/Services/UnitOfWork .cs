using BSATask.DAL.Context;
using BSATask.DAL.Interfaces;
using BSATask.DAL.Services.Repositories;

namespace BSATask.DAL.Services
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly BSATaskContext _bSATaskContext;
        private UsersRepository _users;
        private TasksRepository _tasks;
        private ProjectsRepository _projects;
        private TeamsRepository _teams;
        private bool disposed = false;

        public UnitOfWork(BSATaskContext bSATaskContext)
        {
            _bSATaskContext = bSATaskContext;
        }

        public UsersRepository Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UsersRepository(_bSATaskContext);
                }
                return _users;
            }
        }

        public TasksRepository Tasks
        {
            get
            {
                if (_tasks == null)
                {
                    _tasks = new TasksRepository(_bSATaskContext);
                }
                return _tasks;
            }
        }

        public ProjectsRepository Projects
        {
            get
            {
                if (_projects == null)
                {
                    _projects = new ProjectsRepository(_bSATaskContext);
                }
                return _projects;
            }
        }

        public TeamsRepository Teams
        {
            get
            {
                if (_teams == null)
                {
                    _teams = new TeamsRepository(_bSATaskContext);
                }
                return _teams;
            }
        }

        public async Task CommitAsync()
        {
           await _bSATaskContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _bSATaskContext.Dispose();
                }
                disposed = true;
            }
        }
    }
}
