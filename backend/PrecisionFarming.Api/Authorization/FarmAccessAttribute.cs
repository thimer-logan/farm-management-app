using Microsoft.AspNetCore.Authorization;
using PrecisionFarming.Domain.Enums;

namespace PrecisionFarming.Api.Authorization
{
    /// <summary>
    /// A custom authorization attribute that indicates 
    /// the user must have a certain farm access level.
    /// </summary>
    public class FarmAccessAttribute : AuthorizeAttribute
    {
        public AccessType RequiredAccess { get; }

        public string RouteParamName { get; set; } = "id";

        /// <summary>
        /// Constructor sets the policy name and the required access level.
        /// </summary>
        /// <param name="requiredAccess"></param>
        public FarmAccessAttribute(AccessType requiredAccess)
        {
            // The Policy name must match what we configure in Startup/Program
            Policy = "FarmAccess";
            RequiredAccess = requiredAccess;
        }

        public FarmAccessAttribute(AccessType requiredAccess, string routeParamName)
        {
            // The Policy name must match what we configure in Startup/Program
            Policy = "FarmAccess";
            RequiredAccess = requiredAccess;
            RouteParamName = routeParamName;
        }
    }
}
