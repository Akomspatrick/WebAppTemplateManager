using DocumentVersionManager.Domain.Entities;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
namespace DocumentVersionManager.Domain.Interfaces
{
    public interface IModelTypesRepository : IGenericRepository<ModelTypes>
    {

        Task<Either<GeneralFailures, ModelTypes>> GetModelTypeByGuidId(Guid modelTypesId);
        Task<Either<GeneralFailures, List<ModelTypes>>> GetAllWithIncludes(CancellationToken cancellationToken);

    }
}