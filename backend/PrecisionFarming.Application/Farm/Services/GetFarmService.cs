using PrecisionFarming.Application.Farm.DTO;
using PrecisionFarming.Application.Farm.Interfaces;
using PrecisionFarming.Domain.Exceptions;
using PrecisionFarming.Domain.Interfaces.Repositories;

namespace PrecisionFarming.Application.Farm.Services
{
    public class GetFarmService : IGetFarmService
    {
        private readonly IFarmRepository _farmRepository;

        public GetFarmService(IFarmRepository farmRepository)
        {
            _farmRepository = farmRepository;
        }

        public async Task<List<FarmDto>> GetAllAsync(Guid userId)
        {
            var farms = await _farmRepository.GetAllForUserAsync(userId);
            return farms.Select(f => f.ToDto()).ToList();
        }

        public async Task<FarmDto?> GetByIdAsync(Guid id)
        {
            var farm = await _farmRepository.GetAsync(id);
            if (farm == null)
            {
                throw new NotFoundException($"Farm not found with id {id}");
            }

            return farm?.ToDto();
        }
    }
}
