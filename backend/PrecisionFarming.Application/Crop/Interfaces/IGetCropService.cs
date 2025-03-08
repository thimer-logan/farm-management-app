using PrecisionFarming.Application.Crop.DTO;

namespace PrecisionFarming.Application.Crop.Interfaces
{
    public interface IGetCropService
    {
        Task<CropDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<CropDto>> GetAllAsync();
    }
}
