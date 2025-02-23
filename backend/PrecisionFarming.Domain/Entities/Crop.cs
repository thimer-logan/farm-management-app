using PrecisionFarming.Domain.Common;

namespace PrecisionFarming.Domain.Entities
{
    public class Crop : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<CropVariety> Varieties { get; set; }
    }
}
