using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.ModelAggregateRoot.Entities;
using LanguageExt;
using System.Threading;

namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public class ModelTypesRepository : GenericRepository<ModelTypes>, IModelTypesRepository
    {
        // private readonly IMapper _mapper;
        DocumentVersionManagerContext _ctx;
        public ModelTypesRepository(DocumentVersionManagerContext ctx) : base(ctx)
        {
            // _mapper = mapper;
            _ctx = ctx;
        }

        public Task<Either<GeneralFailures, ModelTypes>> GetModelTypeByGuidId(Guid modelTypesId)
        {
            //return await _ctx.ModelType

            //.GetMatch(s => (s.ModelName == request.modelRequestDTO.ModelName), cancellationToken))
            throw new NotImplementedException();
        }

        //public async Task<Either<GeneralFailures, ModelTypes>> GetModelTypeByGuidId(Guid modelTypesId)
        //{
        //    try
        //    {
        //        return await _ctx.ModelType.F(modelTypeId);
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log this error properly
        //        return GeneralFailures.ErrorRetrievingListDataFromRepository;
        //    }
        //}

        public async Task<Either<GeneralFailures, ModelTypes>> GetModelTypeById(string modelTypeId)
        {
            try
            {
                return await _ctx.ModelType.FindAsync(modelTypeId);
            }
            catch (Exception ex)
            {
                //Log this error properly
                return GeneralFailures.ErrorRetrievingListDataFromRepository;
            }
        }


    }
}
