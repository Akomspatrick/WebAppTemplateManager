using DocumentVersionManager.Domain.Base;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Task<int> CommitAllChanges(CancellationToken cancellationToken);
        Task<Either<GeneralFailures, int>> CommitAllChanges(CancellationToken cancellationToken);
        IGenericRepository<T> AsyncRepository<T>() where T :BaseEntity;
        IModelRepository ModelRepository { get; }
        IModelTypesRepository ModelTypesRepository { get; }

    }
}
