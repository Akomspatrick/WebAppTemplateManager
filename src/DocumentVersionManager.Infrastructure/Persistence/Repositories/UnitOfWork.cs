﻿using AutoMapper;
using DocumentVersionManager.Domain.Base;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using LanguageExt;
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

        public UnitOfWork(DocumentVersionManagerContext ctx)
        {
            _ctx = ctx;

        }

        public IModelRepository ModelRepository => _modelRepository ??= new ModelRepository(_ctx);

        public IModelTypesRepository ModelTypesRepository => _modelTypesRepository ??= new ModelTypesRepository(_ctx);

        //public IGenericRepository<T> asyncRepository<T>() where T : BaseEntity
        //{
        //    return new GenericRepository<T>(_ctx);
        //}

        public async Task<Either<ModelFailures, int>> CommitAllChanges(CancellationToken cancellationToken)
        {
            _ctx.SavingChanges += (s, e) =>
            {

                Console.WriteLine("Saving Changes.....");
                Console.WriteLine("Saving Changes.....");
            };
            try
            {
                return await _ctx.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                //log this problem into dbase
                return ModelFailures.ProblemAddingEntityIntoDbContext;
            }

        }

        public void Dispose()
        {
            _ctx?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
