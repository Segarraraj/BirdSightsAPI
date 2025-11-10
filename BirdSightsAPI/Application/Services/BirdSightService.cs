using Application.Interfaces;
using Domain.Entities;
using Domain.Ports.Secondary;

namespace Application.Services
{
    public class BirdSightService : IService<BirdSight>
    {
        private IRepository<BirdSight> _repository;

        private IMapper<BirdSight, BirdSight> _birdSightUpdateMapper;

        public BirdSightService(IRepository<BirdSight> repository,
            IMapper<BirdSight, BirdSight> birdSightUpdateMapper) 
        { 
            _repository = repository; 
            _birdSightUpdateMapper = birdSightUpdateMapper;
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
            var birdSight = await _repository.GetByIdAsync(id);

            if (birdSight == null)
                return null;

            birdSight = _birdSightUpdateMapper.Map(entity, birdSight);
            birdSight = _repository.Update(entity);

            await _repository.SaveChangesAsync();

            return birdSight;
        }

        public async Task<BirdSight?> DeleteAsync(int id)
        {
            var birdSight = await _repository.GetByIdAsync(id);

            if (birdSight == null)
                return null;

            _repository.Delete(id);
            await _repository.SaveChangesAsync();

            return birdSight;
        }
    }
}
