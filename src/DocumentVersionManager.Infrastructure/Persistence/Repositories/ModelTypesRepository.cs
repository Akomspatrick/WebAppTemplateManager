using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.ModelAggregateRoot.Entities;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public class ModelTypesRepository : GenericRepository<ModelTypes>, IModelTypesRepository
    {

        DocumentVersionManagerContext _ctx;
        public ModelTypesRepository(DocumentVersionManagerContext ctx) : base(ctx)
        {

            _ctx = ctx;
        }

        public Task<Either<GeneralFailures, ModelTypes>> GetModelTypeByGuidId(Guid modelTypesId)
        {
            //return await _ctx.ModelType

            //.GetMatch(s => (s.ModelName == request.modelRequestDTO.ModelName), cancellationToken))
            throw new NotImplementedException();
        }

        public async Task<Either<GeneralFailures, List<ModelTypes>>> GetAllWithIncludes(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _ctx.ModelType.Include(model => model.Models).AsNoTracking().ToListAsync(cancellationToken);

                return result;


            }
            catch (Exception)
            {
                return GeneralFailures.ErrorRetrievingListDataFromRepository;
            }
        }



    }
}
