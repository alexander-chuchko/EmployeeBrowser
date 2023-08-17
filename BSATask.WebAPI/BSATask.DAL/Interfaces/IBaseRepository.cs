namespace BSATask.DAL.Interfaces
{
    public interface IBaseRepository
    {
        Task DeleteAsync<T>(int id) where T : class, IEntityBase, new();

        Task<IEnumerable<T>> GetAllAsync<T>() where T : class, IEntityBase, new();

        Task InsertAsync<T>(T entity) where T : class, IEntityBase, new();

        Task UpdateAsync<T>(T entity) where T : class, IEntityBase, new();

        Task<T> GetByIdAsync<T>(int id) where T : class, IEntityBase, new();
    }
}

