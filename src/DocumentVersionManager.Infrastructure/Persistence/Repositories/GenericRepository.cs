using DocumentVersionManager.Domain.Base;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        // private readonly DbSet<T> _dbSet;
        private readonly DocumentVersionManagerContext _ctx;
        public GenericRepository(DocumentVersionManagerContext ctx)
        {
            //_dbSet = ctx.Set<T>();
            Guid guid = Guid.NewGuid();
            _ctx = ctx;
        }
        async Task<Either<GeneralFailures, int>> IGenericRepository<T>.AddAsync(T entity, CancellationToken cancellationToken)
        {
            try
            {
                await _ctx.AddAsync<T>(entity, cancellationToken);
                return await _ctx.SaveChangesAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                //Log this error properly
                return GeneralFailures.ProblemAddingEntityIntoDbContext;
            }

        }
        async Task<Either<GeneralFailures, Task<IReadOnlyList<T>>>> IGenericRepository<T>.GetAllAsync(CancellationToken cancellationToken)
        {

            try
            {
                var list = _ctx.Set<T>().ToList();
                var result = await _ctx.Set<T>().ToListAsync();
                var x = result as IReadOnlyList<T>;
                return Task.FromResult(x);
            }
            catch (Exception ex)
            {
                //Log this error properly
                return GeneralFailures.ErrorRetrievingListDataFromRepository;
            }

        }
        //public async Task<T> FindAsTrackingAsync(Expression<Func<T, bool>> match)
        //{
        //    return await _ctx.Set<T>().FirstOrDefaultAsync(match);
        //}
        //public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        //{
        //    return await _ctx.Set<T>().AsNoTracking().FirstOrDefaultAsync(match);
        //}

        //async Task<Either<GeneralFailures, T>> IGenericRepository<T>.GetByIdAsync(string Id,CancellationToken cancellationToken)
        //{

        //    try
        //    {
        //        var entity = await _ctx.FindAsync<T>(Id, cancellationToken);

        //        return entity != null ? entity : GeneralFailures.DataNotFoundInRepository;

        //    }
        //    catch (Exception ex)
        //    {
        //        //Log this error properly
        //        return GeneralFailures.ErrorRetrievingListDataFromRepository;
        //    }

        //}

        async Task<Either<GeneralFailures, int>> IGenericRepository<T>.UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            try
            {
                _ctx.Update(entity);
                //  _ctx.Entry(entity).State = EntityState.Modified;
                return await _ctx.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                //Log this error properly
                return GeneralFailures.ProblemUpdatingEntityInRepository;
            }

        }
        async Task<Either<GeneralFailures, int>> IGenericRepository<T>.DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            try
            {
                var result = _ctx.Remove(entity);
                return await _ctx.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                //Log this error properly
                return GeneralFailures.ProblemDeletingEntityFromRepository;
            }

        }

        public async Task<Either<GeneralFailures, T>> GetMatch(Expression<Func<T, bool>> match, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _ctx.Set<T>().AsNoTracking().FirstOrDefaultAsync(match, cancellationToken);
                return entity != null ? entity : GeneralFailures.DataNotFoundInRepository;
            }
            catch (Exception ex)
            {
                //Log this error properly
                return GeneralFailures.ErrorRetrievingListDataFromRepository;
            }

        }

        public async Task<Either<GeneralFailures, T>> GetByGuidAsync(Guid guid, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _ctx.Set<T>().AsNoTracking().FirstOrDefaultAsync(s => (s.GuidId.Equals(guid)), cancellationToken);
                return entity != null ? entity : GeneralFailures.DataNotFoundInRepository;
            }
            catch (Exception ex)
            {
                //Log this error properly
                return GeneralFailures.ErrorRetrievingListDataFromRepository;
            }
        }
    }
}
