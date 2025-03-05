using PrecisionFarming.Application.FieldCrop.DTO;

namespace PrecisionFarming.Application.FieldCrop.Interfaces
{
    public interface IUpdateFieldCropService
    {
        Task<FieldCropDto> UpdateAsync(Guid id, UpdateFieldCropDto item);
    }
}
