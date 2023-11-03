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
        
        Task<Either<GeneralFailures, int>> CommitAllChanges(CancellationToken cancellationToken);
      //  IGenericRepository<T> AsyncRepository<T>() where T : BaseEntity;
      // I ditched IGenericRepository for individual model generic so that i can use the instance in Unitofwork implementation IModelRepository and IModelTypesRepository
        IModelRepository ModelRepository { get; }
        IModelTypesRepository ModelTypesRepository { get; }
        IDocumentRepository DocumentRepository { get; }
        IDocumentTypeRepository DocumentTypeRepository { get; }
        

    }
}
