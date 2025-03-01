using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using PrecisionFarming.Application.Farm.DTO;
using PrecisionFarming.Application.Farm.Interfaces;
using PrecisionFarming.Domain.Exceptions;
using PrecisionFarming.Domain.Interfaces.Repositories;

namespace PrecisionFarming.Application.Farm.Services
{
    public class UpdateFarmService : IUpdateFarmService
    {
        private readonly IFarmRepository _farmRepository;
        private readonly IFarmAccessRepository _farmAccessRepository;
        private readonly GeoJsonReader _geoJsonReader;

        public UpdateFarmService(IFarmRepository farmRepository, IFarmAccessRepository farmAccessRepository)
        {
            _farmRepository = farmRepository;
            _geoJsonReader = new GeoJsonReader();
            _farmAccessRepository = farmAccessRepository;
        }

        public async Task<FarmDto> UpdateAsync(Guid id, UpdateFarmDto input)
        {
            var existingFarm = await _farmRepository.GetAsync(id);
            if (existingFarm == null)
            {
                throw new NotFoundException($"Farm not found with id {id}");
            }

            var geometry = _geoJsonReader.Read<Geometry>(input.Location);
            existingFarm.Location = (Point)geometry;
            existingFarm.Name = input.Name;

            var updatedFarm = await _farmRepository.UpdateAsync(existingFarm);
            return updatedFarm.ToDto();
        }
    }
}
