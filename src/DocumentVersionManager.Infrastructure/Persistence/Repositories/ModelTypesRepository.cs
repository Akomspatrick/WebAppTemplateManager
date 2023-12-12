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



        public async Task<Either<GeneralFailure, List<ModelType>>> GetAllWithIncludes(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _ctx.ModelTypes.Include(model => model.Models).AsNoTracking().ToListAsync(cancellationToken);
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
