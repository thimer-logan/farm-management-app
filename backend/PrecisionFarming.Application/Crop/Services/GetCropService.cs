using PrecisionFarming.Application.Crop.DTO;
using PrecisionFarming.Application.Crop.Interfaces;
using PrecisionFarming.Domain.Interfaces.Repositories;

namespace PrecisionFarming.Application.Crop.Services
{
    public class GetCropService : IGetCropService
    {
        private readonly ICropRepository _cropRepository;

        public GetCropService(ICropRepository cropRepository)
        {
            _cropRepository = cropRepository;
        }

        public async Task<IEnumerable<CropDto>> GetAllAsync()
        {
            var crops = await _cropRepository.GetAllAsync("Varieties");
            return crops.Select(c => c.ToDto());
        }

        public async Task<CropDto?> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return null;
            }

            var crop = await _cropRepository.GetAsync(id, "Varieties");
            return crop?.ToDto();
        }
    }
}
