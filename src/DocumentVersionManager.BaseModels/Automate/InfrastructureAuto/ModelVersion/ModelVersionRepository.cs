using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories

{
    public  class  ModelVersionRepository:GenericRepository<ModelVersion>, IModelVersionRepository
    {
        public   ModelVersionRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}