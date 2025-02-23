using NetTopologySuite.Geometries;
using PrecisionFarming.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrecisionFarming.Domain.Entities
{
    public class Farm : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "geography")]
        public Point Location { get; set; }

        public Guid OwnerId { get; set; }

        public virtual ICollection<Field> Fields { get; set; }
    }
}
