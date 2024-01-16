using LanguageExt;
using DocumentVersionManager.Domain.Errors;
namespace DocumentVersionManager.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<Either<GeneralFailure, int>> CommitAllChanges(CancellationToken cancellationToken);
        IDocumentRepository DocumentRepository { get; }
        IDocumentBasePathRepository DocumentBasePathRepository { get; }
        IDocumentDocumentTypeRepository DocumentDocumentTypeRepository { get; }
        IDocumentTypeRepository DocumentTypeRepository { get; }
        IModelRepository ModelRepository { get; }
        IModelTypeRepository ModelTypeRepository { get; }
        IModelTypeGroupRepository ModelTypeGroupRepository { get; }
        IModelVersionRepository ModelVersionRepository { get; }
        IProductRepository ProductRepository { get; }
        IShellMaterialRepository ShellMaterialRepository { get; }
        ITestPointRepository TestPointRepository { get; }
    }
}