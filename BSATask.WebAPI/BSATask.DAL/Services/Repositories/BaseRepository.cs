using BSATask.DAL.Context;
using BSATask.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BSATask.DAL.Services.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly BSATaskContext _bSATaskContext;
        public BaseRepository(BSATaskContext bSATaskContext)
        {
            _bSATaskContext = bSATaskContext;   
        }
        public async Task DeleteAsync<T>(int id) where T : class, IEntityBase, new()
        {
            var entity = await _bSATaskContext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _bSATaskContext.Set<T>().Remove(entity);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class, IEntityBase, new()
        {
            return await _bSATaskContext.Set<T>().ToListAsync();
        }

        public async Task InsertAsync<T>(T entity) where T : class, IEntityBase, new()
        {
            await _bSATaskContext.Set<T>().AddAsync(entity);
        }

        public async Task<T> GetByIdAsync<T>(int id) where T : class, IEntityBase, new()
        {
            return await _bSATaskContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync<T>(T entity) where T : class, IEntityBase, new()
        {
            var existingEntity = await _bSATaskContext.Set<T>().FindAsync(entity.Id);

            if (existingEntity == null)
            {
                throw new ArgumentException($"Entity with ID {entity.Id} not found in the database.");
            }

            _bSATaskContext.Entry(existingEntity).CurrentValues.SetValues(entity);
        }
    }
}
