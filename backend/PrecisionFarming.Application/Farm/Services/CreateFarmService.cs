using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using PrecisionFarming.Application.Farm.DTO;
using PrecisionFarming.Application.Farm.Interfaces;
using PrecisionFarming.Domain.Interfaces.Repositories;

namespace PrecisionFarming.Application.Farm.Services
{
    public class CreateFarmService : ICreateFarmService
    {
        private readonly IFarmRepository _farmRepository;
        private readonly GeoJsonReader _geoJsonReader;

        public CreateFarmService(IFarmRepository farmRepository)
        {
            _farmRepository = farmRepository;
            _geoJsonReader = new GeoJsonReader();
        }

        public async Task<FarmDto> CreateAsync(CreateFarmDto input)
        {
            var geometry = _geoJsonReader.Read<Geometry>(input.Location);
            var farm = new Domain.Entities.Farm
            {
                Name = input.Name,
                OwnerId = input.OwnerId,
                Location = (Point)geometry
            };

            var newFarm = await _farmRepository.CreateAsync(farm);

            return newFarm.ToDto();
        }
    }
}
