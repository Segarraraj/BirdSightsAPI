using Application.Interfaces;
using Domain.Entities;
using Domain.Ports.Secondary;

namespace Application.Services
{
    public class BirdService : IService<Bird>
    {
        private IRepository<Bird> _repository;

        public BirdService(IRepository<Bird> repository)
        {
            _repository = repository;
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
            var bird = await _repository.CreateAsync(entity);
            return bird;
        }

        public async Task<Bird?> UpdateAsync(int id, Bird entity)
        {
            var bird = await _repository.UpdateAsync(id, entity);
            return bird;
        }

        public async Task<Bird?> DeleteAsync(int id)
        {
            var bird = await _repository.DeleteAsync(id);           
            return bird;
        }
    }
}
