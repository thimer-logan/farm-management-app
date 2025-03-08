using PrecisionFarming.Application.FieldCrop.DTO;
using PrecisionFarming.Application.FieldCrop.Interfaces;
using PrecisionFarming.Domain.Interfaces.Repositories;

namespace PrecisionFarming.Application.FieldCrop.Services
{
    public class GetFieldCropService : IGetFieldCropService
    {
        private readonly IFieldCropRepository _fieldCropRepository;

        public GetFieldCropService(IFieldCropRepository fieldCropRepository)
        {
            _fieldCropRepository = fieldCropRepository;
        }

        public async Task<IEnumerable<FieldCropDto>> GetAllAsync(Guid fieldId)
        {
            if (fieldId == Guid.Empty)
            {
                throw new ArgumentException("Field id cannot be empty");
            }

            var fieldCrops = await _fieldCropRepository.GetAllByFieldIdAsync(fieldId, "Variety", "Variety.Crop");
            return fieldCrops.Select(fc => fc.ToDto());
        }

        public async Task<FieldCropDto?> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Field crop id cannot be empty");
            }

            var fieldCrop = await _fieldCropRepository.GetAsync(id, "Variety", "Variety.Crop");
            return fieldCrop?.ToDto();
        }
    }
}
