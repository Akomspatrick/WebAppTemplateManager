using DocumentVersionManager.Domain.Interfaces;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public  class  ModelVersionRepository:GenericRepository<ModelVersion>, IModelVersionRepository
    {
        public  class  ModelVersionRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}