using PrecisionFarming.Application.FieldCrop.DTO;
using PrecisionFarming.Application.FieldCrop.Interfaces;
using PrecisionFarming.Domain.Exceptions;
using PrecisionFarming.Domain.Interfaces.Repositories;

namespace PrecisionFarming.Application.FieldCrop.Services
{
    public class UpdateFieldCropService : IUpdateFieldCropService
    {
        private readonly IFieldCropRepository _fieldCropRepository;

        public UpdateFieldCropService(IFieldCropRepository fieldCropRepository)
        {
            _fieldCropRepository = fieldCropRepository;
        }

        public async Task<FieldCropDto> UpdateAsync(Guid id, UpdateFieldCropDto item)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Field crop id cannot be empty");
            }

            if (!await _fieldCropRepository.ExistsAsync(id))
            {
                throw new NotFoundException($"Field crop not found with id {id}");
            }

            var fieldCrop = await _fieldCropRepository.GetAsync(id);
            fieldCrop.CropVarietyId = item.CropVarietyId;
            fieldCrop.FieldId = item.FieldId;
            fieldCrop.SowingDate = item.SowingDate;
            fieldCrop.HarvestDate = item.HarvestDate;
            fieldCrop.Yield = item.Yield;

            var updatedFieldCrop = await _fieldCropRepository.UpdateAsync(fieldCrop);
            return updatedFieldCrop.ToDto();
        }
    }
}
