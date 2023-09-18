using DocumentVersionManager.Domain.Base;
using DocumentVersionManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly DocumentVersionManagerContext _ctx;
        public UnitOfWork(DocumentVersionManagerContext ctx)
        {
                _ctx = ctx;
        }
        public IGenericRepository<T> asyncRepository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(_ctx);
        }

        public async  Task<int> CommitAllChanges()
        {
            _ctx.SavingChanges += (s, e) => { Console.WriteLine("Saving Changes"); };
           return await  _ctx.SaveChangesAsync();
        }
    }
}
