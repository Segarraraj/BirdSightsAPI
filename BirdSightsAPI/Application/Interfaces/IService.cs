namespace Application.Interfaces
{
    public interface IService<TEntity>
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<TEntity?> GetByIdAsync(int id);
        public Task<TEntity?> CreateAsync(TEntity entity);
        public Task<TEntity?> UpdateAsync(int id, TEntity entity);
        public Task<TEntity?> DeleteAsync(int id);      
    }
}
