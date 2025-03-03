using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using PrecisionFarming.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrecisionFarming.Domain.Entities
{
    public class Field : BaseEntity
    {
        public string Name { get; set; }

        public Guid FarmId { get; set; }

        [Column(TypeName = "geography")]
        public Polygon Boundary { get; set; }

        [Precision(10, 2)]
        public decimal Area { get; set; }

        [ForeignKey(nameof(FarmId))]
        public virtual Farm Farm { get; set; }

        public virtual ICollection<FieldCrop> FieldCrops { get; set; }
    }
}
