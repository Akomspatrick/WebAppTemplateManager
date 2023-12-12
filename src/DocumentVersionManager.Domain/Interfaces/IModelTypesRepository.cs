using DocumentVersionManager.Domain.Entities;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
namespace DocumentVersionManager.Domain.Interfaces
{
    public interface IModelTypesRepository : IGenericRepository<ModelType>
    {

        //  Task<Either<GeneralFailure, ModelType>> GetModelTypeByGuidId(Guid modelTypesId);
        Task<Either<GeneralFailure, List<ModelType>>> GetAllWithIncludes(CancellationToken cancellationToken);

    }
}