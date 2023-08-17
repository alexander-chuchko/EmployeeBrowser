using BSATask.DAL.Context;

namespace BSATask.DAL.Services.Repositories
{
    public class ProjectsRepository : BaseRepository
    {
        public ProjectsRepository(BSATaskContext bSATaskContext) : base(bSATaskContext) { }
    }
}
