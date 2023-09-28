using DocumentVersionManager.Domain.Base;
using DocumentVersionManager.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {    private readonly DbSet<T> _dbSet;
        public GenericRepository( DocumentVersionManagerContext ctx)
        {
            _dbSet = ctx.Set<T>();     
        }
       

        public  async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity,cancellationToken);
            return  (entity);
        }

        //public Task<T> AddAsync(T entity)
        //{
        //    _dbSet.Add(entity);
        //    return Task.FromResult(entity);
        //}

        public Task<T> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
