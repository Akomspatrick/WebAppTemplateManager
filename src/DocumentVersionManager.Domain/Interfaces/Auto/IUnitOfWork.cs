using LanguageExt;
using DocumentVersionManager.Domain.Errors;
namespace DocumentVersionManager.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<Either<GeneralFailure, int>> CommitAllChanges(CancellationToken cancellationToken);
        ICapacityDocumentRepository CapacityDocumentRepository { get; }
        IDocumentRepository DocumentRepository { get; }
        IDocumentBasePathRepository DocumentBasePathRepository { get; }
        IDocumentDocumentTypeRepository DocumentDocumentTypeRepository { get; }
        IDocumentTypeRepository DocumentTypeRepository { get; }
        IModelRepository ModelRepository { get; }
        IModelTypeRepository ModelTypeRepository { get; }
        IModelVersionRepository ModelVersionRepository { get; }
        IProductRepository ProductRepository { get; }
        IShellMaterialRepository ShellMaterialRepository { get; }

        ITestFlowTypeRepository TestFlowTypeRepository { get; }
        ITestPointRepository TestPointRepository { get; }
    }
}