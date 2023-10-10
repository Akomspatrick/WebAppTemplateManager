﻿using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.ModelAggregateRoot.Entities;
using LanguageExt;

namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public class ModelTypesRepository : GenericRepository<ModelType>, IModelTypesRepository
    {
        // private readonly IMapper _mapper;
        DocumentVersionManagerContext _ctx;
        public ModelTypesRepository(DocumentVersionManagerContext ctx) : base(ctx)
        {
            // _mapper = mapper;
            _ctx = ctx; 
        }

        public async Task<Either<GeneralFailures, ModelType>> GetModelType(string modelTypeName)
        {
            try
            {
                return await _ctx.ModelType.FindAsync(modelTypeName);
            }
            catch (Exception ex)
            {
                //Log this error properly
                return GeneralFailures.ErrorRetrievingListDataFromRepository;
            }
        }







        //public async Task<ModelType> AddAsync(ModelType entity, CancellationToken cancellationToken)
        //{

        //    //var model = entity.ToModel();
        //    await base.AddAsync(entity, cancellationToken);

        //    return entity;
        //}

        //public Task<ModelType> DeleteAsync(ModelType entity)
        //{
        //    //  var model = entity.ToModel();
        //    base.DeleteAsync(entity);

        //    return Task.FromResult(entity);
        //}

        //public Task<ModelType> UpdateAsync(ModelType entity)
        //{
        //    // var model = entity.ToModel();
        //    base.UpdateAsync(entity);

        //    return Task.FromResult(entity);
        //}

        //Task<IReadOnlyList<Domain.ModelAggregateRoot.Entities.ModelType>> IGenericRepository<Domain.ModelAggregateRoot.Entities.ModelType>.GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<Domain.ModelAggregateRoot.Entities.ModelType>> IGenericRepository<Domain.ModelAggregateRoot.Entities.ModelType>GetAll()
        //{


        //    var result = await base.GetAll();
        //    //var model = _mapper.Map<IReadOnlyList<Domain.ModelAggregateRoot.Entities.ModelType>>(result);
        //    var model = result.Select(p => p.ToEntity());
        //    return model;
        //}

        //async Task<IReadOnlyList<Domain.ModelAggregateRoot.Entities.ModelType>> IGenericRepository<Domain.ModelAggregateRoot.Entities.ModelType>.GetAll()
        //{

        //    var result = await base.GetAll();
        //    //var model = _mapper.Map<IReadOnlyList<Domain.ModelAggregateRoot.Entities.ModelType>>(result);
        //    var model = result.Select(p => p.ToEntity());
        //    return nulll;
        //}
    }
}
