using PrecisionFarming.Application.FieldCrop.DTO;

namespace PrecisionFarming.Application.FieldCrop.Interfaces
{
    public interface ICreateFieldCropService
    {
        public Task<FieldCropDto> CreateAsync(CreateFieldCropDto item);
    }
}
