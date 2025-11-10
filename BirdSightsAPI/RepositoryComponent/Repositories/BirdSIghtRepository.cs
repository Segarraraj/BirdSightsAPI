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

        public Task<BirdSight?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public BirdSight? Create(BirdSight entity)
        {
            throw new NotImplementedException();
        }

        public BirdSight? Update(BirdSight entity)
        {
            throw new NotImplementedException();
        }

        public BirdSight? Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
