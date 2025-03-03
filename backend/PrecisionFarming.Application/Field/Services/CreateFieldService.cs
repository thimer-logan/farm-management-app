using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using PrecisionFarming.Application.Field.DTO;
using PrecisionFarming.Application.Field.Interfaces;
using PrecisionFarming.Domain.Interfaces.Repositories;

namespace PrecisionFarming.Application.Field.Services
{
    public class CreateFieldService : ICreateFieldService
    {
        private readonly IFieldRepository _fieldRepository;
        private readonly GeoJsonReader _geoJsonReader;

        public CreateFieldService(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
            _geoJsonReader = new GeoJsonReader();
        }

        public async Task<FieldDto> CreateAsync(Guid farmId, CreateFieldDto input)
        {
            var geometry = _geoJsonReader.Read<Geometry>(input.Boundary);
            var field = new Domain.Entities.Field
            {
                FarmId = farmId,
                Name = input.Name,
                Area = input.Area,
                Boundary = (Polygon)geometry
            };

            var newField = await _fieldRepository.CreateAsync(field);

            return newField.ToDto();
        }
    }
}
