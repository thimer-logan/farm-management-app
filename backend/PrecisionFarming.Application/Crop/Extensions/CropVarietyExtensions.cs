using PrecisionFarming.Application.Crop.DTO;
using PrecisionFarming.Domain.Entities;

namespace PrecisionFarming.Application.Crop.Extensions
{
    public static class CropVarietyExtensions
    {
        public static CropVarietyDto ToDto(this CropVariety cropVariety)
        {
            return new CropVarietyDto
            {
                Id = cropVariety.Id,
                Name = cropVariety.Name,
                Distributor = cropVariety.Distributor,
                Description = cropVariety.Description,
                Type = cropVariety.Crop.Name
            };
        }

        public static CropVarietyBriefDto ToBriefDto(this CropVariety cropVariety)
        {
            return new CropVarietyBriefDto
            {
                Id = cropVariety.Id,
                Name = cropVariety.Name,
                Type = cropVariety.Crop.Name
            };
        }
    }
}
