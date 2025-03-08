using Microsoft.AspNetCore.Mvc;
using PrecisionFarming.Application.Crop.Interfaces;

namespace PrecisionFarming.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CropController : ControllerBase
    {
        private readonly IGetCropService _getCropService;
        private readonly IGetCropVarietyService _getCropVarietyService;

        public CropController(IGetCropService getCropService, IGetCropVarietyService getCropVarietyService)
        {
            _getCropService = getCropService;
            _getCropVarietyService = getCropVarietyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCrops()
        {
            var crops = await _getCropService.GetAllAsync();
            return Ok(crops);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCrop(Guid id)
        {
            var crop = await _getCropService.GetByIdAsync(id);
            return Ok(crop);
        }

        [HttpGet("varieties")]
        public async Task<IActionResult> GetCropVarieties()
        {
            var cropVarieties = await _getCropVarietyService.GetAllAsync();
            return Ok(cropVarieties);
        }

        [HttpGet("varieties/{id:guid}")]
        public async Task<IActionResult> GetCropVariety(Guid id)
        {
            var cropVariety = await _getCropVarietyService.GetByIdAsync(id);
            return Ok(cropVariety);
        }
    }
}
