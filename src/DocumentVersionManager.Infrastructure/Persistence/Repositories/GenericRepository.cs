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
    {
        private readonly DbSet<T> _dbSet;

        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
