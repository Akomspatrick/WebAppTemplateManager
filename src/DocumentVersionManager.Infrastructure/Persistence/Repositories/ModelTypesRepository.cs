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
