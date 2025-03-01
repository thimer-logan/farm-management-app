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

        public async Task<bool> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Farm id is required");
            }

            var farm = await _farmRepository.GetAsync(id);
            if (farm == null)
            {
                throw new NotFoundException($"Farm not found with id {id}");
            }

            return await _farmRepository.DeleteAsync(id);
        }
    }
}
