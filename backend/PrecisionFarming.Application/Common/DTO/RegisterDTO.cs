using System.ComponentModel.DataAnnotations;

namespace PrecisionFarming.Application.Common.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Email cannot be blank")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        //[Remote(action: "IsEmailInUse", controller: "Account", ErrorMessage = "Email is already in use")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "First name cannot be blank")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name cannot be blank")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number cannot be blank")]
        [RegularExpression(@"^(\d{3}-\d{3}-\d{4})$", ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password cannot be blank")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirm Password cannot be blank")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Role cannot be blank")]
        [RegularExpression(@"^(Admin|Farmer|Agronomist)$", ErrorMessage = "Invalid role")]
        public string? Role { get; set; }
    }
}
