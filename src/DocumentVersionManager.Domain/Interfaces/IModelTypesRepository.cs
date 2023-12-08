using DocumentVersionManager.Domain.Entities;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
namespace DocumentVersionManager.Domain.Interfaces
{
    public interface IModelTypesRepository : IGenericRepository<ModelTypes>
    {

        Task<Either<GeneralFailure, ModelTypes>> GetModelTypeByGuidId(Guid modelTypesId);
        Task<Either<GeneralFailure, List<ModelTypes>>> GetAllWithIncludes(CancellationToken cancellationToken);

    }
}