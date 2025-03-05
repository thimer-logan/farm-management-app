using PrecisionFarming.Domain.Entities;

namespace PrecisionFarming.Domain.Interfaces.Repositories
{
    public interface IFieldCropRepository : IRepository<FieldCrop>
    {
        Task<IEnumerable<FieldCrop>> GetAllByFieldIdAsync(Guid fieldId, params string[] includes);
    }
}
