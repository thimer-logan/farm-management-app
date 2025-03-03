using PrecisionFarming.Application.Field.DTO;

namespace PrecisionFarming.Application.Field.Interfaces
{
    public interface ICreateFieldService
    {
        Task<FieldDto> CreateAsync(Guid farmId, CreateFieldDto input);
    }
}
