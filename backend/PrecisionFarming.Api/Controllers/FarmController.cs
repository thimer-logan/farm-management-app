using Microsoft.AspNetCore.Mvc;
using PrecisionFarming.Application.Farm.DTO;
using PrecisionFarming.Application.Farm.Interfaces;
using System.Security.Claims;

namespace PrecisionFarming.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        private readonly ICreateFarmService _createFarmService;
        private readonly IGetFarmService _getFarmService;
        private readonly IDeleteFarmService _deleteFarmService;
        private readonly IUpdateFarmService _updateFarmService;

        public FarmController(ICreateFarmService createFarmService, IGetFarmService getFarmService, IDeleteFarmService deleteFarmService, IUpdateFarmService updateFarmService)
        {
            _createFarmService = createFarmService;
            _getFarmService = getFarmService;
            _deleteFarmService = deleteFarmService;
            _updateFarmService = updateFarmService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetFarm(Guid id)
        {
            // Get the user id from the JWT token
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var farm = await _getFarmService.GetByIdAsync(Guid.Parse(userId), id);
            return Ok(farm);
        }

        [HttpGet]
        public async Task<IActionResult> GetFarms()
        {
            // Get the user id from the JWT token
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var farms = await _getFarmService.GetAllAsync(Guid.Parse(userId));
            return Ok(farms);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFarm([FromBody] CreateFarmDto input)
        {
            // Get the user id from the JWT token
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                string errorMessages = string.Join(" | ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                return Problem(errorMessages);
            }

            if (input.OwnerId == Guid.Empty)
            {
                input.OwnerId = Guid.Parse(userId);
            }

            var farm = await _createFarmService.CreateAsync(input);
            return CreatedAtAction(nameof(GetFarm), new { id = farm.Id }, farm);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarm(Guid id)
        {
            // Get the user id from the JWT token
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var result = await _deleteFarmService.DeleteAsync(Guid.Parse(userId), id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFarm([FromRoute] Guid id, [FromBody] UpdateFarmDto input)
        {
            // Get the user id from the JWT token
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                string errorMessages = string.Join(" | ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                return Problem(errorMessages);
            }

            var farm = await _updateFarmService.UpdateAsync(Guid.Parse(userId), id, input);
            return Ok(farm);
        }
    }
}
