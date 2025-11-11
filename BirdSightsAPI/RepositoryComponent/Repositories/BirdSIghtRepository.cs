using Application.Interfaces;
using Domain.Entities;
using Domain.Ports.Secondary;
using Microsoft.EntityFrameworkCore;
using RepositoryComponent.Models;

namespace RepositoryComponent.Repositories
{
    public class BirdSightRepository : IRepository<BirdSight>
    {
        private BirdSightsDBContext _context;

        private IMapper<BirdSightModel, BirdSight> _birdSightEntityMapper;
        private IMapper<BirdSight, BirdSightModel> _birdSightModelMapper;

        public BirdSightRepository(BirdSightsDBContext context,
            IMapper<BirdSightModel, BirdSight> birdSightEntityMapper,
            IMapper<BirdSight, BirdSightModel> birdSightModelMapper)
        {
            _context = context;

            _birdSightEntityMapper = birdSightEntityMapper;
            _birdSightModelMapper = birdSightModelMapper;
        }

        public async Task<IEnumerable<BirdSight>> GetAllAsync()
        {
            return await _context.BirdSights.Select(x => _birdSightEntityMapper.Map(x)).ToListAsync();
        }

        public async Task<BirdSight?> GetByIdAsync(int id)
        {
            var birdSightModel = await _context.BirdSights.FirstOrDefaultAsync(x => x.Id == id);

            if (birdSightModel == null)
                return null;

            return _birdSightEntityMapper.Map(birdSightModel);
        }

        public BirdSight? Create(BirdSight entity)
        {
            var birdSightModel = _birdSightModelMapper.Map(entity);
            _context.BirdSights.Add(birdSightModel);

            return entity;
        }

        public async Task<BirdSight?> UpdateAsync(int id, BirdSight entity)
        {
            var birdSightModel = await _context.BirdSights.FirstOrDefaultAsync(x => x.Id == id);

            if (birdSightModel == null)
                return null;

            birdSightModel = _birdSightModelMapper.Map(entity, birdSightModel);

            _context.BirdSights.Attach(birdSightModel);
            _context.BirdSights.Entry(birdSightModel).State = EntityState.Modified;

            return _birdSightEntityMapper.Map(birdSightModel);
        }

        public async Task<BirdSight?> DeleteAsync(int id)
        {
            var birdSightModel = await _context.BirdSights.FirstOrDefaultAsync(x => x.Id == id);

            if (birdSightModel == null)
                return null;

            _context.BirdSights.Remove(birdSightModel);
            return _birdSightEntityMapper.Map(birdSightModel);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
