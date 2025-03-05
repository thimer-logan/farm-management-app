using System.ComponentModel.DataAnnotations;

namespace PrecisionFarming.Application.Field.DTO
{
    public class UpdateFieldDto
    {
        [Required]
        public string Name { get; set; }

        public decimal? Area { get; set; }

        [Required]
        public string Boundary { get; set; }
    }
}
