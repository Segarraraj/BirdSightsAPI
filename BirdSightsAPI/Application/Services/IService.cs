namespace Application.Services
{
    public interface IService<TEntity>
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<TEntity> GetByIdAsync(int id);
        public TEntity CreateAsync(TEntity entity);
        public Task<TEntity> UpdateAsync(int id, TEntity entity);
        public Task<TEntity> DeleteAsync(int id);      
    }
}
