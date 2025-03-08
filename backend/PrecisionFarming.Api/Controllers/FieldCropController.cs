using Microsoft.AspNetCore.Mvc;
using PrecisionFarming.Api.Authorization;
using PrecisionFarming.Application.FieldCrop.DTO;
using PrecisionFarming.Application.FieldCrop.Interfaces;
using PrecisionFarming.Domain.Enums;

namespace PrecisionFarming.Api.Controllers
{
    [Route("api/farm/{farmId:guid}/field/{fieldId:guid}/crop")]
    [ApiController]
    [FarmAccess(AccessType.Viewer, "farmId")]
    public class FieldCropController : ControllerBase
    {
        private readonly ICreateFieldCropService _createFieldCropService;
        private readonly IGetFieldCropService _getFieldCropService;
        private readonly IDeleteFieldCropService _deleteFieldCropService;
        private readonly IUpdateFieldCropService _updateFieldCropService;

        public FieldCropController(ICreateFieldCropService createFieldCropService, IGetFieldCropService getFieldCropService, IDeleteFieldCropService deleteFieldCropService, IUpdateFieldCropService updateFieldCropService)
        {
            _createFieldCropService = createFieldCropService;
            _getFieldCropService = getFieldCropService;
            _deleteFieldCropService = deleteFieldCropService;
            _updateFieldCropService = updateFieldCropService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetFieldCrop(Guid id)
        {
            var fieldCrop = await _getFieldCropService.GetByIdAsync(id);
            return Ok(fieldCrop);
        }

        [HttpGet]
        public async Task<IActionResult> GetFieldCrops(Guid fieldId)
        {
            var fieldCrops = await _getFieldCropService.GetAllAsync(fieldId);
            return Ok(fieldCrops);
        }

        [HttpPost]
        [FarmAccess(AccessType.Editor, "farmId")]
        public async Task<IActionResult> CreateFieldCrop(Guid fieldId, [FromBody] CreateFieldCropDto input)
        {
            input.FieldId = fieldId;

            if (!ModelState.IsValid)
            {
                string errorMessages = string.Join(" | ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                return Problem(errorMessages);
            }
            var fieldCrop = await _createFieldCropService.CreateAsync(input);
            return Ok(fieldCrop);
        }

        [HttpPut("{id:guid}")]
        [FarmAccess(AccessType.Editor, "farmId")]
        public async Task<IActionResult> UpdateFieldCrop(Guid fieldId, Guid id, [FromBody] UpdateFieldCropDto input)
        {
            input.FieldId = fieldId;

            if (!ModelState.IsValid)
            {
                string errorMessages = string.Join(" | ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                return Problem(errorMessages);
            }
            var fieldCrop = await _updateFieldCropService.UpdateAsync(id, input);
            return Ok(fieldCrop);
        }

        [HttpDelete("{id:guid}")]
        [FarmAccess(AccessType.Editor, "farmId")]
        public async Task<IActionResult> DeleteFieldCrop(Guid id)
        {
            await _deleteFieldCropService.DeleteAsync(id);
            return NoContent();
        }
    }
}
