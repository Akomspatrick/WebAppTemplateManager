using DocumentVersionManager.Domain.Base;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        //Task<T> AddAsync(T entity,CancellationToken cancellationToken);
        Task<Either<ModelFailures, int>> AddAsync(T entity, CancellationToken cancellationToken);
        Task<Either<ModelFailures, Task<IReadOnlyList<T>>>>  GetAllAsync(CancellationToken cancellationToken);
        Task<Either<ModelFailures, int>> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task<Either<ModelFailures, int>> DeleteAsync(T entity, CancellationToken cancellationToken);
         Task<Either<ModelFailures, T>> GetByIdAsync(string Id, CancellationToken cancellationToken);
      
       // Task<IReadOnlyList<T>> GetAll();



    }
}
