using PrecisionFarming.Application.Field.Interfaces;
using PrecisionFarming.Domain.Exceptions;
using PrecisionFarming.Domain.Interfaces.Repositories;

namespace PrecisionFarming.Application.Field.Services
{
    public class DeleteFieldService : IDeleteFieldService
    {
        private readonly IFieldRepository _fieldRepository;

        public DeleteFieldService(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Field id is required");
            }

            var field = await _fieldRepository.GetAsync(id);
            if (field == null)
            {
                throw new NotFoundException($"Field not found with id {id}");
            }

            return await _fieldRepository.DeleteAsync(id);
        }
    }
}
