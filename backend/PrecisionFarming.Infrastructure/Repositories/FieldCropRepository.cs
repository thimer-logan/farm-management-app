using Microsoft.EntityFrameworkCore;
using PrecisionFarming.Domain.Entities;
using PrecisionFarming.Domain.Exceptions;
using PrecisionFarming.Domain.Interfaces.Repositories;
using PrecisionFarming.Infrastructure.DbContext;

namespace PrecisionFarming.Infrastructure.Repositories
{
    public class FieldCropRepository : IFieldCropRepository
    {
        private readonly AppDbContext _context;

        public FieldCropRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FieldCrop> CreateAsync(FieldCrop item)
        {
            item.CreatedAt = DateTime.UtcNow;
            _context.FieldsCrops.Add(item);
            await _context.SaveChangesAsync();

            // Load related entities
            await _context.Entry(item)
                          .Reference(fc => fc.Variety)
                          .LoadAsync();

            await _context.Entry(item.Variety)
                          .Reference(cv => cv.Crop)
                          .LoadAsync();

            return item;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _context.FieldsCrops.FirstOrDefaultAsync(f => f.Id == id);
            if (result == null)
            {
                throw new NotFoundException($"Field crop not found with id {id}");
            }

            _context.FieldsCrops.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.FieldsCrops.AnyAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<FieldCrop>> GetAllAsync(params string[] includes)
        {
            IQueryable<FieldCrop> query = _context.FieldsCrops;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<FieldCrop>> GetAllByFieldIdAsync(Guid fieldId, params string[] includes)
        {
            IQueryable<FieldCrop> query = _context.FieldsCrops.Where(f => f.FieldId == fieldId);
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<FieldCrop?> GetAsync(Guid id, params string[] includes)
        {
            IQueryable<FieldCrop> query = _context.FieldsCrops;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<FieldCrop> UpdateAsync(FieldCrop item)
        {
            item.UpdatedAt = DateTime.UtcNow;
            _context.FieldsCrops.Update(item);

            await _context.SaveChangesAsync();

            // Load related entities
            await _context.Entry(item)
                          .Reference(fc => fc.Variety)
                          .LoadAsync();

            await _context.Entry(item.Variety)
                          .Reference(cv => cv.Crop)
                          .LoadAsync();

            return item;
        }
    }
}
