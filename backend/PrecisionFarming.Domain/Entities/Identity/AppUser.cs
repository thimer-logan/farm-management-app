﻿using Microsoft.AspNetCore.Identity;

namespace PrecisionFarming.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
