using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Domain.Interfaces
{
    public interface IModelVersionRepository : IGenericRepository<ModelVersion>
    {
        //  Task<Either<GeneralFailure, List<Model>>> GetAllWithIncludes(CancellationToken cancellationToken);

    }
}