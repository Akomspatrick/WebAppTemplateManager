using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories

{
    public  class  ModelTypeRepository:GenericRepository<ModelType>, IModelTypeRepository
    {
        public   ModelTypeRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}