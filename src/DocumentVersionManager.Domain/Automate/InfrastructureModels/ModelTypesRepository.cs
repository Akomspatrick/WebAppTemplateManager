using DocumentVersionManager.Domain.Interfaces;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public  class  ModelTypesRepository:GenericRepository<ModelTypes>, IModelTypesRepository
    {
        public  class  ModelTypesRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}