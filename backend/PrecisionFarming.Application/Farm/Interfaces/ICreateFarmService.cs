using PrecisionFarming.Application.Farm.DTO;

namespace PrecisionFarming.Application.Farm.Interfaces
{
    public interface ICreateFarmService
    {
        Task<FarmDto> CreateAsync(CreateFarmDto input);
    }
}
