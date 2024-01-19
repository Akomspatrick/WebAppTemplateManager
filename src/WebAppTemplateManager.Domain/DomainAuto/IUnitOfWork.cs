using LanguageExt;
using WebAppTemplateManager.Domain.Errors;
namespace WebAppTemplateManager.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<Either<GeneralFailure, int>> CommitAllChanges(CancellationToken cancellationToken);

        IModelTypeRepository ModelTypeRepository { get; }

    }
}