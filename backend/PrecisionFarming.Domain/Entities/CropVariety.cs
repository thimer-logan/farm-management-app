using PrecisionFarming.Domain.Common;

namespace PrecisionFarming.Domain.Entities
{
    /// <summary>
    /// Represents a variety of a seed. Each seed can have multiple varieties.
    /// </summary>
    public class CropVariety : BaseEntity
    {
        /// <summary>
        /// Name of the variety
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Distributor of the variety
        /// </summary>
        public string Distributor { get; set; }

        /// <summary>
        /// Description of the variety
        /// </summary>
        public string Description { get; set; }


        public Guid CropId { get; set; }
        public virtual Crop Crop { get; set; }
    }
}
