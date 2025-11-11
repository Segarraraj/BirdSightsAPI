using Application.Interfaces;
using Domain.Entities;
using Domain.Ports.Secondary;

namespace Application.Services
{
    public class BirdService : IService<Bird>
    {
        private IRepository<Bird> _repository;

        private IMapper<Bird, Bird> _birdUpdateMapper;

        public BirdService(IRepository<Bird> repository, 
            IMapper<Bird, Bird> birdUpdateMapper)
        {
            _repository = repository;
            _birdUpdateMapper = birdUpdateMapper;
        }

        public async Task<IEnumerable<Bird>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Bird?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Bird?> CreateAsync(Bird entity)
        {
            var bird = _repository.Create(entity);
            await _repository.SaveChangesAsync();

            return bird;
        }

        public async Task<Bird?> UpdateAsync(int id, Bird entity)
        {
            var bird = await _repository.UpdateAsync(id, entity);

            if (bird == null)
                return null;
            
            await _repository.SaveChangesAsync();
            return bird;
        }

        public async Task<Bird?> DeleteAsync(int id)
        {
            var bird = await _repository.DeleteAsync(id);

            if (bird == null)
                return null;
            
            await _repository.SaveChangesAsync();            
            return bird;
        }
    }
}
