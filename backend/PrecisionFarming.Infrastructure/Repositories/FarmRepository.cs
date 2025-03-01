using Microsoft.EntityFrameworkCore;
using PrecisionFarming.Domain.Entities;
using PrecisionFarming.Domain.Exceptions;
using PrecisionFarming.Domain.Interfaces.Repositories;
using PrecisionFarming.Infrastructure.DbContext;

namespace PrecisionFarming.Infrastructure.Repositories
{
    public class FarmRepository : IFarmRepository
    {
        private readonly AppDbContext _context;

        public FarmRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Farm> CreateAsync(Farm item)
        {
            item.CreatedAt = DateTime.UtcNow;
            _context.Farms.Add(item);

            // Add a FarmAccess for the owner
            var farmAccess = new FarmAccess
            {
                FarmId = item.Id,
                UserId = item.OwnerId,
                AccessType = Domain.Enums.AccessType.Admin
            };
            _context.FarmAccesses.Add(farmAccess);

            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _context.Farms.FirstOrDefaultAsync(f => f.Id == id);
            if (result == null)
            {
                throw new NotFoundException($"Farm not found with id {id}");
            }

            _context.Farms.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Farm>> GetAllAsync(params string[] includes)
        {
            IQueryable<Farm> query = _context.Farms;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Farm>> GetAllForUserAsync(Guid userId, params string[] includes)
        {
            IQueryable<Farm> query = _context.Farms.Where(f => f.OwnerId == userId
                                                            || f.FarmAccesses.Any(fa => fa.UserId == userId));
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<Farm?> GetAsync(Guid id, params string[] includes)
        {
            IQueryable<Farm> query = _context.Farms;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Farm> UpdateAsync(Farm item)
        {
            item.UpdatedAt = DateTime.UtcNow;
            _context.Farms.Update(item);

            await _context.SaveChangesAsync();
            return item;
        }
    }
}
