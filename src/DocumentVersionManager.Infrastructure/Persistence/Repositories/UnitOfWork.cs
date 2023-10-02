using AutoMapper;
using DocumentVersionManager.Domain.Base;
using DocumentVersionManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly DocumentVersionManagerContext _ctx;
        private ModelRepository _modelRepository;
        private ModelTypesRepository _modelTypesRepository;
        // private readonly IMapper _mapper;
        public UnitOfWork(DocumentVersionManagerContext ctx)
        {
            _ctx = ctx;
            //   _mapper = mapper;  
        }

        public IModelRepository ModelRepository => _modelRepository ??= new ModelRepository(_ctx);

        public IModelTypesRepository ModelTypesRepository => _modelTypesRepository ??= new ModelTypesRepository(_ctx);

        //public IGenericRepository<T> asyncRepository<T>() where T : BaseEntity
        //{
        //    return new GenericRepository<T>(_ctx);
        //}

        public async Task<int> CommitAllChanges(CancellationToken cancellationToken)
        {
            _ctx.SavingChanges += (s, e) =>
            {

                Console.WriteLine("Saving Changes.....");
                Console.WriteLine("Saving Changes.....");
            };
            return await _ctx.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _ctx?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
