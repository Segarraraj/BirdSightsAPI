using Application.Interfaces;
using Domain.Entities;
using Domain.Ports.Secondary;
using Microsoft.EntityFrameworkCore;
using RepositoryComponent.Models;

namespace RepositoryComponent.Repositories
{
    public class BirdRepository : IRepository<Bird>
    {
        private BirdSightsDBContext _context;

        private IMapper<BirdModel, Bird> _birdEntityMapper;
        private IMapper<Bird, BirdModel> _birdModelMapper;

        public BirdRepository(BirdSightsDBContext context, 
            IMapper<BirdModel, Bird> birdEntityMapper,
            IMapper<Bird, BirdModel> birdModelMapper)
        {
            _context = context;
           
            _birdEntityMapper = birdEntityMapper;
            _birdModelMapper = birdModelMapper;
        }

        public async Task<IEnumerable<Bird>> GetAllAsync()
        {
            return await _context.Birds.Select(x => _birdEntityMapper.Map(x)).ToListAsync();
        }

        public async Task<Bird?> GetByIdAsync(int id)
        {
            var birdModel = await _context.Birds.FirstOrDefaultAsync(x => x.Id == id);

            if (birdModel == null)
                return null;

            return _birdEntityMapper.Map(birdModel);
        }

        public Bird Create(Bird entity)
        {
            var birdModel = _birdModelMapper.Map(entity);
            _context.Birds.Add(birdModel);

            return entity;
        }

        public async Task<Bird?> UpdateAsync(int id, Bird entity)
        {
            var birdModel = await _context.Birds.FirstOrDefaultAsync(_ => _.Id == id);

            if (birdModel == null)
                return null;

            birdModel = _birdModelMapper.Map(entity, birdModel);

            _context.Birds.Attach(birdModel);
            _context.Birds.Entry(birdModel).State = EntityState.Modified;

            return _birdEntityMapper.Map(birdModel);
        }

        public async Task<Bird?> DeleteAsync(int id)
        {
            var birdModel = await _context.Birds.FirstOrDefaultAsync(_ => _.Id == id);

            if (birdModel == null)
                return null;

            _context.Birds.Remove(birdModel);
            return _birdEntityMapper.Map(birdModel);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
