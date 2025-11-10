namespace Domain.Ports.Secondary
{
    public interface IRepository<TEntity>
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<TEntity?> GetByIdAsync(int id);
        public TEntity? Create(TEntity entity);
        public TEntity? Update(TEntity entity);
        public TEntity? Delete(int id);
        public Task SaveChangesAsync();
    }
}
