
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.DomainBase.Base;
using LanguageExt;

namespace DocumentVersionManager.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<Either<GeneralFailure, int>> AddAsync(T entity, CancellationToken cancellationToken);



        Task<Either<GeneralFailure, int>> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task<Either<GeneralFailure, int>> DeleteAsync(T entity, CancellationToken cancellationToken);
        // Task<Either<GeneralFailure, T>> GetMatch(System.Linq.Expressions.Expression<Func<T, bool>> match, CancellationToken cancellationToken);
        //Task<Either<GeneralFailure, Task<IReadOnlyList<T>>>> GetAllAsync(CancellationToken cancellationToken);
        Task<Either<GeneralFailure, Task<IReadOnlyList<T>>>> GetAllAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression = null,
                                                                            List<string> includes = null,
                                                                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                                            CancellationToken cancellationToken = default);
        Task<Either<GeneralFailure, T>> GetMatch(System.Linq.Expressions.Expression<Func<T, bool>> expression,
                                                                     List<string> includes = null
            , CancellationToken cancellationToken = default);

        Task<Either<GeneralFailure, T>> GetByGuidAsync(Guid guid, CancellationToken cancellationToken = default);





        //  Task<Either<GeneralFailure, int>> DeleteByGuidAsync(Guid Id, CancellationToken cancellationToken);
        //  Task<Either<GeneralFailure, int>> DeleteByIdAsync(string Id, CancellationToken cancellationToken);
        // EitherAsync<GeneralFailure, Task<IReadOnlyList<T>>>  GetAllAsync2Async(CancellationToken cancellationToken);
        //Task<Either<GeneralFailure, T>> GetByIdAsync(string Id, CancellationToken cancellationToken);
        //Task<T> FindAsTrackingAsync(System.Linq.Expressions.Expression<Func<T, bool>> match);
        //Task<T> FindAsync(System.Linq.Expressions.Expression<Func<T, bool>> match);
    }
}
