using BSATask.DAL.Context;

namespace BSATask.DAL.Services.Repositories
{
    public class UsersRepository : BaseRepository
    {
        public UsersRepository(BSATaskContext bSATaskContext) : base(bSATaskContext) { }
    }
}
