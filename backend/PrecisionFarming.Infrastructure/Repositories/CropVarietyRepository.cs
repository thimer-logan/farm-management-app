using Microsoft.EntityFrameworkCore;
using PrecisionFarming.Domain.Entities;
using PrecisionFarming.Domain.Exceptions;
using PrecisionFarming.Domain.Interfaces.Repositories;
using PrecisionFarming.Infrastructure.DbContext;

namespace PrecisionFarming.Infrastructure.Repositories
{
    public class CropVarietyRepository : ICropVarietyRepository
    {
        private readonly AppDbContext _context;

        public CropVarietyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CropVariety> CreateAsync(CropVariety item)
        {
            item.CreatedAt = DateTime.UtcNow;
            _context.CropVarieties.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _context.CropVarieties.FirstOrDefaultAsync(f => f.Id == id);
            if (result == null)
            {
                throw new NotFoundException($"Crop variety not found with id {id}");
            }

            _context.CropVarieties.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.CropVarieties.AnyAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<CropVariety>> GetAllAsync(params string[] includes)
        {
            IQueryable<CropVariety> query = _context.CropVarieties;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<CropVariety?> GetAsync(Guid id, params string[] includes)
        {
            IQueryable<CropVariety> query = _context.CropVarieties.Where(f => f.Id == id);
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<CropVariety> UpdateAsync(CropVariety item)
        {
            item.UpdatedAt = DateTime.UtcNow;
            _context.CropVarieties.Update(item);

            await _context.SaveChangesAsync();
            return item;
        }
    }
}
