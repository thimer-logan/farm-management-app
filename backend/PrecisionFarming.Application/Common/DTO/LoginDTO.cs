using System.ComponentModel.DataAnnotations;

namespace PrecisionFarming.Application.Common.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email cannot be blank")]
        [EmailAddress(ErrorMessage = "Email should be in proper format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password cannot be blank")]
        public string Password { get; set; } = string.Empty;
    }
}
