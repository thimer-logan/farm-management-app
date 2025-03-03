namespace PrecisionFarming.Application.Field.Interfaces
{
    public interface IDeleteFieldService
    {
        Task<bool> DeleteAsync(Guid id);
    }
}
