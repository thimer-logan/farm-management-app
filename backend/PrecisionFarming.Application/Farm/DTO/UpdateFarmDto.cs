using System.ComponentModel.DataAnnotations;

namespace PrecisionFarming.Application.Farm.DTO
{
    public class UpdateFarmDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }
    }
}
