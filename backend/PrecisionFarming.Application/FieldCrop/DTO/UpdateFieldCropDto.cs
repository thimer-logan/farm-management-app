using System.ComponentModel.DataAnnotations;

namespace PrecisionFarming.Application.FieldCrop.DTO
{
    public class UpdateFieldCropDto
    {
        [Required]
        public Guid FieldId { get; set; }

        [Required]
        public Guid CropVarietyId { get; set; }

        public DateTime? SowingDate { get; set; }

        public DateTime? HarvestDate { get; set; }

        public decimal Yield { get; set; } = 0;
    }
}
