
using DocumentVersionManager.Domain.Errors;
using LanguageExt;

namespace DocumentVersionManager.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        Task<Either<GeneralFailure, int>> CommitAllChanges(CancellationToken cancellationToken);
        //  IGenericRepository<T> AsyncRepository<T>() where T : BaseEntity;
        // I ditched IGenericRepository for individual model generic so that i can use the instance in Unitofwork implementation IModelRepository and IModelTypesRepository
        IModelRepository ModelRepository { get; }
        IModelTypesRepository ModelTypesRepository { get; }
        IDocumentRepository DocumentRepository { get; }
        IDocumentTypeRepository DocumentTypeRepository { get; }


    }
}
