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
        Task<Either<GeneralFailures, int>> AddAsync(T entity, CancellationToken cancellationToken);
        Task<Either<GeneralFailures, Task<IReadOnlyList<T>>>> GetAllAsync(CancellationToken cancellationToken);


        Task<Either<GeneralFailures, int>> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task<Either<GeneralFailures, int>> DeleteAsync(T entity, CancellationToken cancellationToken);
        Task<Either<GeneralFailures, T>> GetMatch(System.Linq.Expressions.Expression<Func<T, bool>> match, CancellationToken cancellationToken);

        //  Task<Either<GeneralFailures, int>> DeleteByGuidAsync(Guid Id, CancellationToken cancellationToken);
        //  Task<Either<GeneralFailures, int>> DeleteByIdAsync(string Id, CancellationToken cancellationToken);
        // EitherAsync<GeneralFailures, Task<IReadOnlyList<T>>>  GetAllAsync2Async(CancellationToken cancellationToken);
        //Task<Either<GeneralFailures, T>> GetByIdAsync(string Id, CancellationToken cancellationToken);
        //Task<T> FindAsTrackingAsync(System.Linq.Expressions.Expression<Func<T, bool>> match);
        //Task<T> FindAsync(System.Linq.Expressions.Expression<Func<T, bool>> match);
    }
}
