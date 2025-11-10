using Domain.Entities;
using Domain.Ports.Secondary;

namespace RepositoryComponent.Repositories
{
    public class BirdRepository : IRepository<Bird>
    {
        private BirdSightsDBContext _context;

        public BirdRepository(BirdSightsDBContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Bird>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Bird?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Bird Create(Bird entity)
        {
            throw new NotImplementedException();
        }

        public Bird? Update(Bird entity)
        {
            throw new NotImplementedException();
        }

        public Bird? Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
