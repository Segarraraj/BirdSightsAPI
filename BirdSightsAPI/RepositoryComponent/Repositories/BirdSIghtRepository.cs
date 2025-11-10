using Domain.Entities;
using Domain.Ports.Secondary;

namespace RepositoryComponent.Repositories
{
    public class BirdSIghtRepository : IRepository<BirdSight>
    {
        public Task<IEnumerable<BirdSight>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BirdSight> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public BirdSight CreateAsync(BirdSight entity)
        {
            throw new NotImplementedException();
        }

        public Task<BirdSight> UpdateAsync(int id, BirdSight entity)
        {
            throw new NotImplementedException();
        }

        public Task<BirdSight> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
