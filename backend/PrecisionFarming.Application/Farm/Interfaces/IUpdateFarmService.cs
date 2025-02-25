using PrecisionFarming.Application.Farm.DTO;

namespace PrecisionFarming.Application.Farm.Interfaces
{
    public interface IUpdateFarmService
    {
        Task<FarmDto> UpdateAsync(Guid id, UpdateFarmDto input);
    }
}
