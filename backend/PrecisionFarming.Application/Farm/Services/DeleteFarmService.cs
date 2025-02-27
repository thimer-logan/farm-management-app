using PrecisionFarming.Application.Farm.Interfaces;
using PrecisionFarming.Domain.Exceptions;
using PrecisionFarming.Domain.Interfaces.Repositories;

namespace PrecisionFarming.Application.Farm.Services
{
    public class DeleteFarmService : IDeleteFarmService
    {
        private readonly IFarmRepository _farmRepository;
        private readonly IFarmAccessRepository _farmAccessRepository;

        public DeleteFarmService(IFarmRepository farmRepository, IFarmAccessRepository farmAccessRepository)
        {
            _farmRepository = farmRepository;
            _farmAccessRepository = farmAccessRepository;
        }

        public async Task<bool> DeleteAsync(Guid userId, Guid id)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentException("User id is required");
            }

            if (id == Guid.Empty)
            {
                throw new ArgumentException("Farm id is required");
            }

            var farm = await _farmRepository.GetAsync(id);
            if (farm == null)
            {
                throw new NotFoundException($"Farm not found with id {id}");
            }

            if (!await _farmAccessRepository.HasAccessAsync(id, userId, Domain.Enums.AccessType.Admin))
            {
                throw new ForbiddenException("You are not allowed to delete this farm");
            }

            return await _farmRepository.DeleteAsync(id);
        }
    }
}
