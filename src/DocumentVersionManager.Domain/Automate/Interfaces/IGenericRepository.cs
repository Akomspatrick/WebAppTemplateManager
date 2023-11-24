using LanguageExt;
using DocumentVersionManager.DomainBase.Base;
using DocumentVersionManager.Domain.Errors;
namespace DocumentVersionManager.Domain.Interfaces
{

    public interface IGenericRepository<T> where T : BaseEntity

    {
        Task<Either<GeneralFailures, int>> AddAsync(T entity, CancellationToken cancellationToken);
        Task<Either<GeneralFailures, int>> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task<Either<GeneralFailures, int>> DeleteAsync(T entity, CancellationToken cancellationToken);
         Task<Either<GeneralFailures, Task<IReadOnlyList<T>>>> GetAllAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression= null,List<string> includes = null,Func<IQueryable<T>,IOrderedQueryable<T>> orderBy= null,CancellationToken cancellationToken =default);
        Task<Either<GeneralFailures, T>> GetMatch(System.Linq.Expressions.Expression<Func<T, bool>> expression,List<string> includes= null , CancellationToken cancellationToken= default);
        Task<Either<GeneralFailures, T>> GetByGuidAsync(Guid guid, CancellationToken cancellationToken=default);
    }
}