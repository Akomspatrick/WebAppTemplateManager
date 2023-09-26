using DocumentVersionManager.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        Task<int> CommitAllChanges( CancellationToken cancellationToken);
        //IGenericRepository<T> asyncRepository<T>() where T :BaseEntity;
        IModelRepository modelRepository { get; }
        IModelTypesRepository modelTypesRepository { get; }
    }
}
