using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories

{
    public  class  ModelRepository:GenericRepository<Model>, IModelRepository
    {
        public   ModelRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}