using PrecisionFarming.Domain.Common;
using PrecisionFarming.Domain.Entities.Identity;
using PrecisionFarming.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrecisionFarming.Domain.Entities
{
    public class FarmAccess : BaseEntity
    {
        [ForeignKey(nameof(Farm))]
        public Guid FarmId { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public AccessType AccessType { get; set; }

        public virtual Farm Farm { get; set; }

        public virtual AppUser User { get; set; }
    }
}
