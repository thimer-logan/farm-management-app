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

        public async Task<FarmDto> UpdateAsync(Guid userId, UpdateFarmDto input)
        {
            if (!await _farmAccessRepository.HasAccessAsync(input.Id, userId, Domain.Enums.AccessType.Editor))
            {
                throw new ForbiddenException("You don't have write access to this farm");
            }

            var geometry = _geoJsonReader.Read<Geometry>(input.Location);
            var farm = new Domain.Entities.Farm
            {
                Id = input.Id,
                Name = input.Name,
                Location = (Point)geometry
            };

            var updatedFarm = await _farmRepository.UpdateAsync(farm);
            return updatedFarm.ToDto();
        }
    }
}
