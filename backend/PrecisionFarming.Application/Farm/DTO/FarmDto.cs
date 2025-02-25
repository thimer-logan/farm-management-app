using NetTopologySuite.Geometries;

namespace PrecisionFarming.Application.Farm.DTO
{
    public class FarmDto
    {
        public Guid Id { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string Name { get; set; }

        public Guid OwnerId { get; set; }

        public Point? Location { get; set; }
    }

    public static class FarmDtoExtensions
    {
        public static FarmDto ToDto(this PrecisionFarming.Domain.Entities.Farm farm)
        {
            return new FarmDto
            {
                Id = farm.Id,
                CreatedAt = farm.CreatedAt,
                UpdatedAt = farm.UpdatedAt,
                Name = farm.Name,
                OwnerId = farm.OwnerId,
                Location = farm.Location
            };
        }
    }
}
