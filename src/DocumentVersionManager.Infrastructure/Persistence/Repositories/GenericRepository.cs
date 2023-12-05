using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.DomainBase.Base;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        // private readonly DbSet<T> _dbSet;
        private readonly DocumentVersionManagerContext _ctx;
        public GenericRepository(DocumentVersionManagerContext ctx)
        {
            //_dbSet = ctx.Set<T>();
            //Guid guid = Guid.NewGuid();
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
        //async Task<Either<GeneralFailures, Task<IReadOnlyList<T>>>> IGenericRepository<T>.GetAllAsync(CancellationToken cancellationToken)
        //{

        //    try
        //    {
        //        var list = _ctx.Set<T>().ToList();
        //        var result = await _ctx.Set<T>().ToListAsync();
        //        var x = result as IReadOnlyList<T>;
        //        return Task.FromResult(x);
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log this error properly
        //        return GeneralFailures.ErrorRetrievingListDataFromRepository;
        //    }

        //}


        //public async Task<Either<GeneralFailures, T>> GetMatch(Expression<Func<T, bool>> match, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var entity = await _ctx.Set<T>().AsNoTracking().FirstOrDefaultAsync(match, cancellationToken);
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

                return await _ctx.SaveChangesAsync(cancellationToken);


                //aternative to the above
                //_ctx.Set<T>().Attach(entity);
                // _ctx.Entry(entity).State = EntityState.Modified;
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

                // above implies that the entity was passed in as a reference 
                //alternatively
                // if the id was passed in as a string
                //var entity = await _ctx.Set<T>().FindAsync(id);
                //if (entity == null)
                //_ctx.Set<T>().Remove(entity);
                //return await _ctx.SaveChangesAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                //Log this error properly
                return GeneralFailures.ProblemDeletingEntityFromRepository;
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

        public async Task<Either<GeneralFailures, Task<IReadOnlyList<T>>>> GetAllAsync(Expression<Func<T, bool>> expression = null, List<string> includes = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, CancellationToken cancellationToken = default)
        {
            try
            {
                IQueryable<T> query = _ctx.Set<T>();
                if (expression != null)
                {
                    query = query.Where(expression);
                }
                if (includes != null)
                {
                    foreach (var includeProperty in includes)
                    {
                        query = query.Include(includeProperty);
                    }
                }
                if (orderBy != null)
                {
                    // return Task.FromResult(orderBy(query).ToListAsync(cancellationToken));
                    query = orderBy(query);
                }
                var result = await query.AsNoTracking().ToListAsync(cancellationToken);
                var entity = result as IReadOnlyList<T>;
                return Task.FromResult(entity);// != null ? entity : GeneralFailures.DataNotFoundInRepository;

            }
            catch (Exception)
            {

                //Log this error properly
                return GeneralFailures.ErrorRetrievingListDataFromRepository;
            }







        }

        public async Task<Either<GeneralFailures, T>> GetMatch(Expression<Func<T, bool>> expression, List<string> includes = null, CancellationToken cancellationToken = default)
        {
            try
            {
                IQueryable<T> query = _ctx.Set<T>();
                if (includes != null)
                {
                    foreach (var includeProperty in includes)
                    {
                        query = query.Include(includeProperty);
                    }
                }
                var entity = await query.AsNoTracking().FirstOrDefaultAsync(expression, cancellationToken);
                return entity != null ? entity : GeneralFailures.DataNotFoundInRepository;

            }
            catch (Exception)
            {

                //Log this error properly
                return GeneralFailures.ErrorRetrievingListDataFromRepository;
            }



        }


    }
}
