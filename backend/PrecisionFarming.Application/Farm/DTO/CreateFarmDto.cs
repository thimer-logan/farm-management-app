using System.ComponentModel.DataAnnotations;

namespace PrecisionFarming.Application.Farm.DTO
{
    public class CreateFarmDto
    {
        [Required]
        public string Name { get; set; }

        public Guid OwnerId { get; set; } = Guid.Empty;

        [Required]
        public string Location { get; set; }
    }
}
