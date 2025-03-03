using PrecisionFarming.Application.Field.DTO;

namespace PrecisionFarming.Application.Field.Interfaces
{
    public interface IGetFieldService
    {
        Task<FieldDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<FieldDto>> GetAllAsync(Guid farmId);
    }
}
