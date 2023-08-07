using BSATask.DAL.Context;

namespace BSATask.DAL.Services.Repositories
{
    public class TasksRepository : BaseRepository
    {
        public TasksRepository(BSATaskContext bSATaskContext) : base(bSATaskContext) { }
    }
}
