using PrecisionFarming.Application.Crop.DTO;
using PrecisionFarming.Application.Crop.Extensions;
using PrecisionFarming.Application.Crop.Interfaces;
using PrecisionFarming.Domain.Interfaces.Repositories;

namespace PrecisionFarming.Application.Crop.Services
{
    public class GetCropVarietyService : IGetCropVarietyService
    {
        private readonly ICropVarietyRepository _cropVarietyRepository;

        public GetCropVarietyService(ICropVarietyRepository cropVarietyRepository)
        {
            _cropVarietyRepository = cropVarietyRepository;
        }

        public async Task<IEnumerable<CropVarietyDto>> GetAllAsync()
        {
            var varieties = await _cropVarietyRepository.GetAllAsync("Crop");
            return varieties.Select(v => v.ToDto());
        }

        public async Task<CropVarietyDto?> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return null;
            }

            var variety = await _cropVarietyRepository.GetAsync(id, "crop");
            return variety?.ToDto();
        }
    }
}
