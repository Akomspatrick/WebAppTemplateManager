using DocumentVersionManager.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAllChanges();
        IGenericRepository<T> asyncRepository<T>() where T :BaseEntity;
        IModelRepository<T> modelRepository<T>() where T : BaseEntity;
    }
}
