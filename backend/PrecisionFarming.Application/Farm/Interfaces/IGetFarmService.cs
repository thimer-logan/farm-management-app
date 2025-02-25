using PrecisionFarming.Application.Farm.DTO;

namespace PrecisionFarming.Application.Farm.Interfaces
{
    public interface IGetFarmService
    {
        Task<FarmDto?> GetByIdAsync(Guid id);
        Task<List<FarmDto>> GetAllAsync();
    }
}
