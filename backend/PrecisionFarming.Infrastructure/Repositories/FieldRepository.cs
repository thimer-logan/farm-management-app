using Microsoft.EntityFrameworkCore;
using PrecisionFarming.Domain.Entities;
using PrecisionFarming.Domain.Exceptions;
using PrecisionFarming.Domain.Interfaces.Repositories;
using PrecisionFarming.Infrastructure.DbContext;

namespace PrecisionFarming.Infrastructure.Repositories
{
    public class FieldRepository : IFieldRepository
    {
        private readonly AppDbContext _context;

        public FieldRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Field> CreateAsync(Field item)
        {
            item.CreatedAt = DateTime.UtcNow;
            _context.Fields.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _context.Fields.FirstOrDefaultAsync(f => f.Id == id);
            if (result == null)
            {
                throw new NotFoundException($"Field not found with id {id}");
            }

            _context.Fields.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.Fields.AnyAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Field>> GetAllAsync(params string[] includes)
        {
            IQueryable<Field> query = _context.Fields;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Field>> GetAllByFarmIdAsync(Guid farmId, params string[] includes)
        {
            // Get all fields for a farm
            IQueryable<Field> query = _context.Fields.Where(f => f.FarmId == farmId);
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public async Task<Field?> GetAsync(Guid id, params string[] includes)
        {
            IQueryable<Field> query = _context.Fields;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Field> UpdateAsync(Field item)
        {
            item.UpdatedAt = DateTime.UtcNow;
            _context.Fields.Update(item);

            await _context.SaveChangesAsync();
            return item;
        }
    }
}
