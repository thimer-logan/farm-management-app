using NetTopologySuite.Geometries;

namespace PrecisionFarming.Application.Field.DTO
{
    public class FieldDto
    {
        public Guid Id { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string Name { get; set; }

        public Guid FarmId { get; set; }

        public decimal Area { get; set; }

        public Polygon Boundary { get; set; }
    }

    public static class FieldDtoExtensions
    {
        public static FieldDto ToDto(this PrecisionFarming.Domain.Entities.Field field)
        {
            return new FieldDto
            {
                Id = field.Id,
                CreatedAt = field.CreatedAt,
                UpdatedAt = field.UpdatedAt,
                Name = field.Name,
                FarmId = field.FarmId,
                Area = field.Area,
                Boundary = field.Boundary
            };
        }
    }
}
