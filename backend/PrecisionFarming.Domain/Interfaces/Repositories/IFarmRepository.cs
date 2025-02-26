using PrecisionFarming.Domain.Entities;

namespace PrecisionFarming.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Repository for managing farms
    /// </summary>
    public interface IFarmRepository : IRepository<Farm>
    {
        Task<IEnumerable<Farm>> GetAllForUserAsync(Guid userId, params string[] includes);
    }
}
