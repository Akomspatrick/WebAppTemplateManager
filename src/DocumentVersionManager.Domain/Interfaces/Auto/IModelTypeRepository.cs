using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Domain.Interfaces
{
    public interface IModelTypeRepository : IGenericRepository<ModelType>
    {
        //   Task<Either<GeneralFailure, List<ModelType>>> GetAllWithIncludes(CancellationToken cancellationToken);

    }
}