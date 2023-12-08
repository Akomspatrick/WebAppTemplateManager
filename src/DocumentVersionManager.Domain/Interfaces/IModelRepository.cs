using DocumentVersionManager.Domain.Entities;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
namespace DocumentVersionManager.Domain.Interfaces
{
    public interface IModelRepository : IGenericRepository<Model>
    {
        Task<Either<GeneralFailure, List<Model>>> GetAllWithIncludes(CancellationToken cancellationToken);
    }
}