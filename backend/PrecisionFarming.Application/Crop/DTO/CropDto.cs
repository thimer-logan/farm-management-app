using PrecisionFarming.Application.Crop.Extensions;

namespace PrecisionFarming.Application.Crop.DTO
{
    public class CropDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<CropVarietyBriefDto> Varieties { get; set; }
    }

    public static class CropDtoExtensions
    {
        public static CropDto ToDto(this Domain.Entities.Crop crop)
        {
            return new CropDto
            {
                Id = crop.Id,
                Name = crop.Name,
                Varieties = crop.Varieties.Select(v => v.ToBriefDto())
            };
        }
    }
}
