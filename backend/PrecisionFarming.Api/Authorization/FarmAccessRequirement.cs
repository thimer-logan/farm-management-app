using Microsoft.AspNetCore.Authorization;

namespace PrecisionFarming.Api.Authorization
{
    /// <summary>
    /// Represents the requirement needed for a user to access a Farm
    /// with a particular access level.
    /// </summary>
    public class FarmAccessRequirement : IAuthorizationRequirement
    {
    }
}
