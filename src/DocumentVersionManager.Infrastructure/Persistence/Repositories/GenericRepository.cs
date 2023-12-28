using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.DomainBase.Base;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Linq.Expressions;

namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DocumentVersionManagerContext _ctx;
        public GenericRepository(DocumentVersionManagerContext ctx)
        {
            _ctx = ctx;
        }

        async Task<Either<GeneralFailure, int>> IGenericRepository<T>.AddAsync(T entity, CancellationToken cancellationToken)
        {
            //try
            //{
            //    await _ctx.AddAsync<T>(entity, cancellationToken);
            //    return await _ctx.SaveChangesAsync(cancellationToken);
            //}
            //catch (Exception ex)
            //{
            //    //Log this error properly
            //    return GeneralFailures.ProblemAddingEntityIntoDbContext(entity.GuidId.ToString());
            //}

            try
            {
                //var x = _ctx.Add<T>(entity);
                //var p = _ctx.SaveChanges();

                //var t = Task.FromResult(p);
                //return await t;

                await _ctx.AddAsync<T>(entity, cancellationToken);
                return await _ctx.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                //Log this error properly
               // throw ex;
                return GeneralFailures.ExceptionThrown("GenericRepository-AddAsync","Problem Adding Entity with Guid"+ entity.GuidId, ex?.InnerException?.Message);
            }
            catch (Exception ex)
            {
                //Log this error properly
                throw ex;
               // return GeneralFailures.ProblemAddingEntityIntoDbContext(entity.GuidId.ToString());
            }


        }
        //async Task<Either<GeneralFailure, Task<IReadOnlyList<T>>>> IGenericRepository<T>.GetAllAsync(CancellationToken cancellationToken)
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
        //        return GeneralFailure.ErrorRetrievingListDataFromRepository;
        //    }

        //}


        //public async Task<Either<GeneralFailure, T>> GetMatch(Expression<Func<T, bool>> match, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var entity = await _ctx.Set<T>().AsNoTracking().FirstOrDefaultAsync(match, cancellationToken);
        //        return entity != null ? entity : GeneralFailure.DataNotFoundInRepository;
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log this error properly
        //        return GeneralFailure.ErrorRetrievingListDataFromRepository;
        //    }

        //}


        async Task<Either<GeneralFailure, int>> IGenericRepository<T>.UpdateAsync(T entity, CancellationToken cancellationToken)
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
                return GeneralFailures.ProblemUpdatingEntityInRepository(entity.GuidId.ToString());
            }

        }
        async Task<Either<GeneralFailure, int>> IGenericRepository<T>.DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            try
            {
                var result = _ctx.Remove(entity);
                return await _ctx.SaveChangesAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                //Log this error properly
                return GeneralFailures.ProblemDeletingEntityFromRepository(entity.GuidId.ToString());
            }

        }



        public async Task<Either<GeneralFailure, T>> GetByGuidAsync(Guid guid, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _ctx.Set<T>().AsNoTracking().FirstOrDefaultAsync(s => (s.GuidId.Equals(guid)), cancellationToken);
                return entity != null ? entity : GeneralFailures.DataNotFoundInRepository(entity.GuidId.ToString());
            }
            catch (Exception ex)
            {
                //Log this error properly
                return GeneralFailures.ErrorRetrievingSingleDataFromRepository(guid.ToString());
            }
        }

        public async Task<Either<GeneralFailure, Task<IReadOnlyList<T>>>> GetAllAsyncUsingReadOnly(Expression<Func<T, bool>> expression = null, List<string> includes = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, CancellationToken cancellationToken = default)
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
                return Task.FromResult(entity);// != null ? entity : GeneralFailure.DataNotFoundInRepository;

            }
            catch (Exception ex)
            {

                //Log this error properly
                return GeneralFailures.ErrorRetrievingListDataFromRepository(ex.ToString());
            }


        }



        public async Task<Either<GeneralFailure, T>> GetMatch(Expression<Func<T, bool>> expression, List<string> includes = null, CancellationToken cancellationToken = default)
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
                return entity != null ? entity : GeneralFailures.DataNotFoundInRepository(expression.ToString());

            }
            catch (MySqlException ex)
            {

                //Log this error properly
                return GeneralFailures.ExceptionThrown("GenericRepo-Add", ex.Message,ex.StackTrace);
            }
            catch (Exception ex)
            {

                //Log this error properly
                return GeneralFailures.ErrorRetrievingListDataFromRepository(ex.ToString());
            }



        }



        async Task<Either<GeneralFailure, List<T>>> IGenericRepository<T>.GetAllAsync(Expression<Func<T, bool>> expression, List<string> includes, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, CancellationToken cancellationToken)
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

                return result;// != null ? entity : GeneralFailure.DataNotFoundInRepository;

            }

            catch (Exception ex)
            {

                //Log this error properly
                return GeneralFailures.ErrorRetrievingListDataFromRepository(ex.ToString());
            }


        }
    }
}
