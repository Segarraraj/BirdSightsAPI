namespace Domain.Ports.Secondary
{
    public interface IRepository<TEntity>
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<TEntity> GetByIdAsync(int id);
        public TEntity CreateAsync(TEntity entity);
        public Task<TEntity> UpdateAsync(int id, TEntity entity);
        public Task<TEntity> DeleteAsync(int id);
        public Task SaveChangesAsync();
    }
}
