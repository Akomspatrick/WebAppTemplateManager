using DocumentVersionManager.Domain.Entities;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;

using LanguageExt;
using Microsoft.EntityFrameworkCore;


namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public class ModelRepository : GenericRepository<Model>, IModelRepository
    {
        DocumentVersionManagerContext _ctx;
        public ModelRepository(DocumentVersionManagerContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<Either<GeneralFailures, List<Model>>> GetAllWithIncludes(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _ctx.Models.Include(model => model.ModelVersions).AsNoTracking().ToListAsync(cancellationToken);
                return result;

            }
            catch (Exception)
            {
                return GeneralFailures.ErrorRetrievingListDataFromRepository;
            }
        }


    }

}


