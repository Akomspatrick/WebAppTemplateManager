using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories

{
    public  class  ModelTypeGroupRepository:GenericRepository<ModelTypeGroup>, IModelTypeGroupRepository
    {
        public   ModelTypeGroupRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}