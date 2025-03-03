using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PrecisionFarming.Domain.Interfaces.Repositories;

namespace PrecisionFarming.Api.Filters
{
    /// <summary>
    /// A resource filter that checks if a farm with the given farmId
    /// route parameter exists in the database.
    /// If not, returns a 404 Not Found.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ValidateFarmExistsAttribute : Attribute, IAsyncResourceFilter
    {
        /// <summary>
        /// The name of the route parameter that holds the farm ID.
        /// Defaults to "farmId" if not provided.
        /// </summary>
        public string RouteParamName { get; }

        public ValidateFarmExistsAttribute(string routeParamName = "farmId")
        {
            RouteParamName = routeParamName;
        }

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            var routeValues = context.RouteData.Values;

            if (!routeValues.TryGetValue(RouteParamName, out var farmIdObj) ||
                !Guid.TryParse(farmIdObj?.ToString(), out Guid farmId))
            {
                // If we can't parse the ID, short-circuit with 404 or 400
                context.Result = new NotFoundResult();
                return;
            }

            var farmRepository = context.HttpContext.RequestServices.GetService<IFarmRepository>();
            if (farmRepository == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                return;
            }

            bool farmExists = await farmRepository.ExistsAsync(farmId);

            if (!farmExists)
            {
                context.Result = new NotFoundResult();
                return;
            }

            await next();
        }
    }
}
