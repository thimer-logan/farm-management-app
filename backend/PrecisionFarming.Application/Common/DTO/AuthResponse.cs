namespace PrecisionFarming.Application.Common.DTO
{
    public class AuthResponse
    {
        public string? FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public string? Token { get; set; } = string.Empty;

        public string? RefreshToken { get; set; } = string.Empty;

        public DateTime Expiration { get; set; }

        public DateTime RefreshExpiration { get; set; }
    }
}
