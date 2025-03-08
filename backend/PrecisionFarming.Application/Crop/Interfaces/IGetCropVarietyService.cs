using PrecisionFarming.Application.Crop.DTO;

namespace PrecisionFarming.Application.Crop.Interfaces
{
    public interface IGetCropVarietyService
    {
        Task<CropVarietyDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<CropVarietyDto>> GetAllAsync();
    }
}
