using Microsoft.AspNetCore.Authorization;
using PrecisionFarming.Domain.Interfaces.Repositories;
using System.Security.Claims;

namespace PrecisionFarming.Api.Authorization
{
    /// <summary>
    /// The authorization handler that checks if the current user 
    /// has the required access level for the requested farm.
    /// </summary>
    public class FarmAccessHandler : AuthorizationHandler<FarmAccessRequirement>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IFarmAccessRepository _farmAccessRepository;

        public FarmAccessHandler(IHttpContextAccessor contextAccessor, IFarmAccessRepository farmAccessRepository)
        {
            _contextAccessor = contextAccessor;
            _farmAccessRepository = farmAccessRepository;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            FarmAccessRequirement requirement)
        {
            // Grab the endpoint
            var endpoint = _contextAccessor.HttpContext?.GetEndpoint();
            if (endpoint == null)
            {
                return;
            }

            // Retrieve FarmAccessAttribute from the endpoint's metadata
            var farmAccessAttribute = endpoint.Metadata.GetMetadata<FarmAccessAttribute>();
            if (farmAccessAttribute == null)
            {
                return;
            }

            var requiredAccess = farmAccessAttribute.RequiredAccess;
            var routeParamName = farmAccessAttribute.RouteParamName;

            var userIdString = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userIdString, out Guid userId))
            {
                return;
            }

            // Extract the farmId from route data
            var routeData = _contextAccessor.HttpContext?.GetRouteData();
            if (routeData?.Values[routeParamName] is not string farmIdString ||
                !Guid.TryParse(farmIdString, out Guid farmId))
            {
                return;
            }

            var hasAccess = await _farmAccessRepository.HasAccessAsync(farmId, userId, requiredAccess);

            if (hasAccess)
            {
                context.Succeed(requirement);
            }
        }
    }
}
