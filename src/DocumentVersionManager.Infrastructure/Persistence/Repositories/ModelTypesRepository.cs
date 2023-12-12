using DocumentVersionManager.Domain.Entities;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public class ModelTypesRepository : GenericRepository<ModelType>, IModelTypesRepository
    {

        DocumentVersionManagerContext _ctx;
        public ModelTypesRepository(DocumentVersionManagerContext ctx) : base(ctx)
        {

            _ctx = ctx;
        }

        public Task<Either<GeneralFailure, ModelType>> GetModelTypeByGuidId(Guid modelTypesId)
        {
            //return await _ctx.ModelType

            //.GetMatch(s => (s.ModelName == request.modelRequestDTO.ModelName), cancellationToken))
            throw new NotImplementedException();
        }

        public async Task<Either<GeneralFailure, List<ModelType>>> GetAllWithIncludes(CancellationToken cancellationToken)
        {
            try
            {

                var result = await _ctx.ModelType.Include(model => model.Models).AsNoTracking().ToListAsync(cancellationToken);


                return result;


            }
            catch (NotSupportedException ex)
            {
                return GeneralFailures.ExceptionThrown(typeof(ModelTypesRepository).Name, ex.Message, ex.StackTrace);
            }
            catch (Exception ex)
            {
                return GeneralFailures.ErrorRetrievingListDataFromRepository(ex.ToString());
            }
        }



    }
}
