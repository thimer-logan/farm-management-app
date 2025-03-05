using PrecisionFarming.Application.FieldCrop.Interfaces;
using PrecisionFarming.Domain.Exceptions;
using PrecisionFarming.Domain.Interfaces.Repositories;

namespace PrecisionFarming.Application.FieldCrop.Services
{
    public class DeleteFieldCropService : IDeleteFieldCropService
    {
        private readonly IFieldCropRepository _fieldCropRepository;

        public DeleteFieldCropService(IFieldCropRepository fieldCropRepository)
        {
            _fieldCropRepository = fieldCropRepository;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Field crop id is required");
            }

            if (!await _fieldCropRepository.ExistsAsync(id))
            {
                throw new NotFoundException($"Field crop not found with id {id}");
            }

            return await _fieldCropRepository.DeleteAsync(id);
        }
    }
}
