using PrecisionFarming.Application.Field.DTO;

namespace PrecisionFarming.Application.Field.Interfaces
{
    public interface IUpdateFieldService
    {
        Task<FieldDto> UpdateAsync(Guid id, UpdateFieldDto input);
    }
}
