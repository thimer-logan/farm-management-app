using Microsoft.EntityFrameworkCore;
using PrecisionFarming.Domain.Entities;
using PrecisionFarming.Domain.Enums;
using PrecisionFarming.Domain.Exceptions;
using PrecisionFarming.Domain.Interfaces.Repositories;
using PrecisionFarming.Infrastructure.DbContext;

namespace PrecisionFarming.Infrastructure.Repositories
{
    public class FarmAccessRepository : IFarmAccessRepository
    {
        private readonly AppDbContext _context;

        public FarmAccessRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FarmAccess> CreateAsync(FarmAccess item)
        {
            item.CreatedAt = DateTime.UtcNow;
            _context.FarmAccesses.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _context.FarmAccesses.FirstOrDefaultAsync(f => f.Id == id);
            if (result == null)
            {
                throw new NotFoundException($"FarmAccess not found with id {id}");
            }

            _context.FarmAccesses.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(Guid farmId, Guid userId)
        {
            return await _context.FarmAccesses.AnyAsync(f => f.FarmId == farmId && f.UserId == userId);
        }

        public async Task<IEnumerable<FarmAccess>> GetAllAsync(params string[] includes)
        {
            IQueryable<FarmAccess> query = _context.FarmAccesses;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public async Task<FarmAccess?> GetAsync(Guid id, params string[] includes)
        {
            IQueryable<FarmAccess> query = _context.FarmAccesses;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<bool> HasAccessAsync(Guid farmId, Guid userId, AccessType accessType)
        {
            var farmAccess = await _context.FarmAccesses.FirstOrDefaultAsync(f => f.FarmId == farmId && f.UserId == userId);
            if (farmAccess == null)
            {
                return false;
            }

            return farmAccess.AccessType >= accessType;
        }

        public async Task<FarmAccess> UpdateAsync(FarmAccess item)
        {
            var result = await _context.FarmAccesses.FirstOrDefaultAsync(f => f.Id == item.Id);
            if (result == null)
            {
                throw new NotFoundException($"FarmAccess not found with id {item.Id}");
            }

            item.UpdatedAt = DateTime.UtcNow;
            _context.FarmAccesses.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
