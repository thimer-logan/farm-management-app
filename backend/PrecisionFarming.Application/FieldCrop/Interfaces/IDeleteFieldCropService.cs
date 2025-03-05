namespace PrecisionFarming.Application.FieldCrop.Interfaces
{
    public interface IDeleteFieldCropService
    {
        Task<bool> DeleteAsync(Guid id);
    }
}
