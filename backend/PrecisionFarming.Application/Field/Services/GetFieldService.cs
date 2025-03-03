using PrecisionFarming.Application.Field.DTO;
using PrecisionFarming.Application.Field.Interfaces;
using PrecisionFarming.Domain.Interfaces.Repositories;

namespace PrecisionFarming.Application.Field.Services
{
    public class GetFieldService : IGetFieldService
    {
        private readonly IFieldRepository _fieldRepository;

        public GetFieldService(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
        }

        public async Task<IEnumerable<FieldDto>> GetAllAsync(Guid farmId)
        {
            var fields = await _fieldRepository.GetAllByFarmIdAsync(farmId);
            return fields.Select(f => f.ToDto());
        }

        public async Task<FieldDto?> GetByIdAsync(Guid id)
        {
            var field = await _fieldRepository.GetAsync(id);
            return field?.ToDto();
        }
    }
}
