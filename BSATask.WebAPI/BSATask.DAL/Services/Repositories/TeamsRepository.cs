using BSATask.DAL.Context;

namespace BSATask.DAL.Services.Repositories
{
    public class TeamsRepository : BaseRepository
    {
        public TeamsRepository(BSATaskContext bSATaskContext) : base(bSATaskContext) { }
    }
}
