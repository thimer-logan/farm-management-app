using PrecisionFarming.Application.FieldCrop.DTO;

namespace PrecisionFarming.Application.FieldCrop.Interfaces
{
    public interface IGetFieldCropService
    {
        Task<FieldCropDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<FieldCropDto>> GetAllAsync(Guid fieldId);
    }
}
