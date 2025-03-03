using Microsoft.AspNetCore.Mvc;
using PrecisionFarming.Api.Authorization;
using PrecisionFarming.Application.Field.DTO;
using PrecisionFarming.Application.Field.Interfaces;
using PrecisionFarming.Domain.Enums;

namespace PrecisionFarming.Api.Controllers
{
    [Route("api/farm/{farmId:guid}/[controller]")]
    [ApiController]
    [FarmAccess(AccessType.Viewer, "farmId")]
    public class FieldController : ControllerBase
    {
        private readonly ICreateFieldService _createFieldService;
        private readonly IGetFieldService _getFieldService;
        private readonly IDeleteFieldService _deleteFieldService;
        private readonly IUpdateFieldService _updateFieldService;

        public FieldController(ICreateFieldService createFieldService, IGetFieldService getFieldService, IDeleteFieldService deleteFieldService, IUpdateFieldService updateFieldService)
        {
            _createFieldService = createFieldService;
            _getFieldService = getFieldService;
            _deleteFieldService = deleteFieldService;
            _updateFieldService = updateFieldService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetField(Guid id)
        {
            var field = await _getFieldService.GetByIdAsync(id);
            return Ok(field);
        }

        [HttpGet]
        public async Task<IActionResult> GetFields(Guid farmId)
        {
            var fields = await _getFieldService.GetAllAsync(farmId);
            return Ok(fields);
        }

        [HttpPost]
        [FarmAccess(AccessType.Editor, "farmId")]
        public async Task<IActionResult> CreateField(Guid farmId, [FromBody] CreateFieldDto input)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = string.Join(" | ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                return Problem(errorMessages);
            }

            var field = await _createFieldService.CreateAsync(farmId, input);
            return Ok(field);
        }

        [HttpPut("{id:guid}")]
        [FarmAccess(AccessType.Editor, "farmId")]
        public async Task<IActionResult> UpdateField(Guid id, [FromBody] UpdateFieldDto input)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = string.Join(" | ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                return Problem(errorMessages);
            }
            var field = await _updateFieldService.UpdateAsync(id, input);
            return Ok(field);
        }

        [HttpDelete("{id:guid}")]
        [FarmAccess(AccessType.Editor, "farmId")]
        public async Task<IActionResult> DeleteField(Guid id)
        {
            await _deleteFieldService.DeleteAsync(id);
            return NoContent();
        }
    }
}
