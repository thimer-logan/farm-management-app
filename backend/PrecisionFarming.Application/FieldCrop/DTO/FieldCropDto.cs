namespace PrecisionFarming.Application.FieldCrop.DTO
{
    public class FieldCropDto
    {
        public Guid Id { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid FieldId { get; set; }

        public Guid CropVarietyId { get; set; }

        public DateTime? SowingDate { get; set; }

        public DateTime? HarvestDate { get; set; }

        public decimal? Yield { get; set; }
    }

    public static class FieldCropDtoExtensions
    {
        public static FieldCropDto ToDto(this PrecisionFarming.Domain.Entities.FieldCrop fieldCrop)
        {
            return new FieldCropDto
            {
                Id = fieldCrop.Id,
                CreatedAt = fieldCrop.CreatedAt,
                UpdatedAt = fieldCrop.UpdatedAt,
                FieldId = fieldCrop.FieldId,
                CropVarietyId = fieldCrop.CropVarietyId,
                SowingDate = fieldCrop.SowingDate,
                HarvestDate = fieldCrop.HarvestDate,
                Yield = fieldCrop.Yield
            };
        }
    }
}
