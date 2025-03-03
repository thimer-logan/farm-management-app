using System.ComponentModel.DataAnnotations;

namespace PrecisionFarming.Application.Field.DTO
{
    public class CreateFieldDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Area { get; set; }

        [Required]
        public string Boundary { get; set; }
    }
}
