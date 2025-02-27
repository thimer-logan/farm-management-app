namespace PrecisionFarming.Application.Farm.Interfaces
{
    public interface IDeleteFarmService
    {
        Task<bool> DeleteAsync(Guid userId, Guid id);
    }
}
