using System.ComponentModel.DataAnnotations;

namespace PrecisionFarming.Domain.Common
{
    public abstract class BaseEntity
    {
        private DateTime? _createdAt;

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

        [Key]
        public Guid Id { get; set; }

        public DateTime? CreatedAt
        {
            get => _createdAt;
            set => _createdAt = value ?? DateTime.UtcNow;
        }

        public DateTime? UpdatedAt { get; set; }
    }
}
