using DocumentVersionManager.Domain.Interfaces;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public  class  ModelRepository:GenericRepository<Model>, IModelRepository
    {
        public  class  ModelRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}