using PrecisionFarming.Domain.Entities;

namespace PrecisionFarming.Domain.Interfaces.Repositories
{
    public interface IFieldRepository : IRepository<Field>
    {
        Task<IEnumerable<Field>> GetAllByFarmIdAsync(Guid farmId, params string[] includes);
    }
}
