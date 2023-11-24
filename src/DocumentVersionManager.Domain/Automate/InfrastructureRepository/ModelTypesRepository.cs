using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories

{
    public  class  ModelTypesRepository:GenericRepository<ModelTypes>, IModelTypesRepository
    {
        public   ModelTypesRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}