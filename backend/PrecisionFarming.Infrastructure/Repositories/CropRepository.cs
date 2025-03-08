using Microsoft.EntityFrameworkCore;
using PrecisionFarming.Domain.Entities;
using PrecisionFarming.Domain.Exceptions;
using PrecisionFarming.Domain.Interfaces.Repositories;
using PrecisionFarming.Infrastructure.DbContext;

namespace PrecisionFarming.Infrastructure.Repositories
{
    public class CropRepository : ICropRepository
    {
        private readonly AppDbContext _context;

        public CropRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Crop> CreateAsync(Crop item)
        {
            item.CreatedAt = DateTime.UtcNow;
            _context.Crops.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _context.Crops.FirstOrDefaultAsync(f => f.Id == id);
            if (result == null)
            {
                throw new NotFoundException($"Crop not found with id {id}");
            }

            _context.Crops.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.Crops.AnyAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Crop>> GetAllAsync(params string[] includes)
        {
            IQueryable<Crop> query = _context.Crops;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<Crop?> GetAsync(Guid id, params string[] includes)
        {
            IQueryable<Crop> query = _context.Crops.Where(f => f.Id == id);
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Crop> UpdateAsync(Crop item)
        {
            item.UpdatedAt = DateTime.UtcNow;
            _context.Crops.Update(item);

            await _context.SaveChangesAsync();
            return item;
        }
    }
}
