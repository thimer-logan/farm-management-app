using PrecisionFarming.Domain.Entities;
using PrecisionFarming.Domain.Enums;

namespace PrecisionFarming.Domain.Interfaces.Repositories
{
    public interface IFarmAccessRepository : IRepository<FarmAccess>
    {
        Task<bool> ExistsAsync(Guid farmId, Guid userId);

        Task<bool> HasAccessAsync(Guid farmId, Guid userId, AccessType accessType);
    }
}
