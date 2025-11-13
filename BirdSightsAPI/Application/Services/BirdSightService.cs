using Application.Interfaces;
using Domain.Entities;
using Domain.Ports.Secondary;

namespace Application.Services
{
    public class BirdSightService : IService<BirdSight>
    {
        private IRepository<BirdSight> _repository;

        public BirdSightService(IRepository<BirdSight> repository) 
        { 
            _repository = repository;
        }

        public async Task<IEnumerable<BirdSight>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<BirdSight?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<BirdSight?> CreateAsync(BirdSight entity)
        {
            var bird = _repository.Create(entity);
            await _repository.SaveChangesAsync();

            return bird;
        }

        public async Task<BirdSight?> UpdateAsync(int id, BirdSight entity)
        {
            var birdSight = await _repository.UpdateAsync(id, entity);
            
            if (birdSight == null)
                return null;

            await _repository.SaveChangesAsync();
            return birdSight;
        }

        public async Task<BirdSight?> DeleteAsync(int id)
        {
            var birdSight = await _repository.DeleteAsync(id);
            
            if (birdSight == null) 
                return null;

            await _repository.SaveChangesAsync();
            return birdSight;
        }
    }
}
