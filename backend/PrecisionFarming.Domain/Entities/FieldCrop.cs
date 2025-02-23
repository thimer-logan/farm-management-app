using Microsoft.EntityFrameworkCore;
using PrecisionFarming.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrecisionFarming.Domain.Entities
{
    public class FieldCrop : BaseEntity
    {
        public Guid FieldId { get; set; }

        public Guid CropVarietyId { get; set; }

        public DateTime? SowingDate { get; set; }

        public DateTime? HarvestDate { get; set; }

        [Precision(10, 2)]
        public decimal? Yield { get; set; }

        public virtual Field Field { get; set; }


        [ForeignKey(nameof(CropVarietyId))]
        public virtual CropVariety Variety { get; set; }
    }
}
