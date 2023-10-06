using DocumentVersionManager.Domain.Base;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            _ctx = ctx;
        }
        async Task<Either<ModelFailures, int>> IGenericRepository<T>.AddAsync(T entity, CancellationToken cancellationToken)
        {
            try
            {
                //var result = await _dbSet.AddAsync(entity, cancellationToken);
                await _ctx.AddAsync<T>(entity, cancellationToken);
                return await _ctx.SaveChangesAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                //Log this error properly
                return ModelFailures.ProblemAddingEntityIntoDbContext;
            }

        }
        async Task<Either<ModelFailures, Task<IReadOnlyList<T>>>> IGenericRepository<T>.GetAllAsync(CancellationToken cancellationToken)
        {

            try
            {
                var list =   _ctx.Set<T>().ToList();
                var result = await _ctx.Set<T>().ToListAsync();
                var x = result as IReadOnlyList<T>;
                return  Task.FromResult(x) ;
                //return await _ctx.Set<T>().ToListAsync() as Task<IReadOnlyList<T?>>;
            }
            catch (Exception ex)
            {
                //Log this error properly
                return ModelFailures.ErrorRetrievingListDataFromRepository;
            }

        }
        async Task<Either<ModelFailures, T>> IGenericRepository<T>.GetByIdAsync(string Id,CancellationToken cancellationToken)
        {

            try
            {
                var x = await _ctx.Set<T>().FindAsync(Id, cancellationToken);

                return await _ctx.Set<T>().FindAsync(Id, cancellationToken);
            }
            catch (Exception ex)
            {
                //Log this error properly
                return ModelFailures.ErrorRetrievingListDataFromRepository;
            }

        }





        async Task<Either<ModelFailures, int>> IGenericRepository<T>.UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            try
            {
                _ctx.Update(entity);
                _ctx.Entry(entity).State = EntityState.Modified;
                return await _ctx.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                //Log this error properly
                return ModelFailures.ProblemUpdatingEntityInRepository;
            }

        }
        async Task<Either<ModelFailures, int>> IGenericRepository<T>.DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            try
            {
                var result = _ctx.Remove(entity);
                return await _ctx.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                //Log this error properly
                return ModelFailures.ProblemDeletingEntityFromRepository;
            }

        }
        //public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        //{
        //    await _dbSet.AddAsync(entity, cancellationToken);
        //    return (entity);
        //}

        //public Task<T> AddAsync(T entity)
        //{
        //    _dbSet.Add(entity);
        //    return Task.FromResult(entity);
        //}

        //public Task<T> DeleteAsync(T entity)
        //{
        //    throw new NotImplementedException();
        //}


        //  public    Task<IReadOnlyList<T>> GetAll()
        //{
        //    //await _dbSet.AddAsync(entity, cancellationToken);
        //    //return Task.FromResult(_dbSet.ToList() as IReadOnlyList<T>);
        //    // return Task.FromResult(_dbSet.ToList() as IReadOnlyList<T>);
        //    throw new NotImplementedException();
        //}

        //public async Task<IReadOnlyList<T>> GetAllAsync()
        //{           
        //    return await _dbSet.ToListAsync() as IReadOnlyList<T>;
        //}

        //public Task<T> UpdateAsync(T entity)
        //{
        //    throw new NotImplementedException();
        //}







    }
}
