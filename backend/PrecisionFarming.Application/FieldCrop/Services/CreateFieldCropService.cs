using PrecisionFarming.Application.FieldCrop.DTO;
using PrecisionFarming.Application.FieldCrop.Interfaces;
using PrecisionFarming.Domain.Exceptions;
using PrecisionFarming.Domain.Interfaces.Repositories;

namespace PrecisionFarming.Application.FieldCrop.Services
{
    public class CreateFieldCropService : ICreateFieldCropService
    {
        private readonly IFieldCropRepository _fieldCropRepository;
        private readonly IFieldRepository _fieldRepository;

        public CreateFieldCropService(IFieldCropRepository fieldCropRepository, IFieldRepository fieldRepository)
        {
            _fieldCropRepository = fieldCropRepository;
            _fieldRepository = fieldRepository;
        }

        public async Task<FieldCropDto> CreateAsync(CreateFieldCropDto item)
        {
            if (!await _fieldRepository.ExistsAsync(item.FieldId))
            {
                throw new NotFoundException($"Field with id {item.FieldId} not found");
            }

            //if (!await _cropVarietyRepository.ExistsAsync(item.CropVarietyId))
            //{
            //    throw new NotFoundException($"Crop variety with id {item.CropVarietyId} not found");
            //}

            var fieldCrop = new Domain.Entities.FieldCrop
            {
                FieldId = item.FieldId,
                CropVarietyId = item.CropVarietyId,
                SowingDate = item.SowingDate,
                HarvestDate = item.HarvestDate,
                Yield = item.Yield
            };

            var newFieldCrop = await _fieldCropRepository.CreateAsync(fieldCrop);
            return newFieldCrop.ToDto();
        }
    }
}
