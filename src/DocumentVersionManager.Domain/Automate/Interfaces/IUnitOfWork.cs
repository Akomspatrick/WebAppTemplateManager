using LanguageExt;
using DocumentVersionManager.Domain.Errors;
namespace DocumentVersionManager.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<Either<GeneralFailure, int>> CommitAllChanges(CancellationToken cancellationToken);
        ICapacityDocumentRepository CapacityDocumentRepository { get; }
        ICapacityTestPointRepository CapacityTestPointRepository { get; }
        IDocumentRepository DocumentRepository { get; }
        IDocumentBasePathRepository DocumentBasePathRepository { get; }
        IDocumentDocumentTypeRepository DocumentDocumentTypeRepository { get; }
        IDocumentTypeRepository DocumentTypeRepository { get; }
        IModelRepository ModelRepository { get; }
        IModelTypesRepository ModelTypesRepository { get; }
        IModelVersionRepository ModelVersionRepository { get; }
        IProductRepository ProductRepository { get; }
        IRevisionRepository RevisionRepository { get; }
        IRevisionCapacityIntervalRepository RevisionCapacityIntervalRepository { get; }
        IShellMaterialRepository ShellMaterialRepository { get; }
        ISpecificationRepository SpecificationRepository { get; }
    }
}