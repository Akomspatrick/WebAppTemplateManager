using DocumentVersionManager.Domain.Base;
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
        Task<T> AddAsync(T entity,CancellationToken cancellationToken);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<IReadOnlyList<T>> GetAll();
        
            
    }
}
