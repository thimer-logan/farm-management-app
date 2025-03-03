using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using PrecisionFarming.Application.Field.DTO;
using PrecisionFarming.Application.Field.Interfaces;
using PrecisionFarming.Domain.Exceptions;
using PrecisionFarming.Domain.Interfaces.Repositories;

namespace PrecisionFarming.Application.Field.Services
{
    public class UpdateFieldService : IUpdateFieldService
    {
        private readonly IFieldRepository _fieldRepository;
        private readonly GeoJsonReader _geoJsonReader;

        public UpdateFieldService(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
            _geoJsonReader = new GeoJsonReader();
        }

        public async Task<FieldDto> UpdateAsync(Guid id, UpdateFieldDto input)
        {
            var existingField = await _fieldRepository.GetAsync(id);
            if (existingField == null)
            {
                throw new NotFoundException($"Field not found with id {id}");
            }

            var geometry = _geoJsonReader.Read<Geometry>(input.Boundary);
            existingField.Boundary = (Polygon)geometry;
            existingField.Name = input.Name;
            existingField.Area = input.Area;

            var updatedField = await _fieldRepository.UpdateAsync(existingField);
            return updatedField.ToDto();
        }
    }
}
