using WebAppTemplateManager.Domain.Interfaces;
using WebAppTemplateManager.Domain.Entities;
namespace WebAppTemplateManager.Infrastructure.Persistence.Repositories

{
    public  class  ModelTypeRepository:GenericRepository<ModelType>, IModelTypeRepository
    {
        public   ModelTypeRepository( WebAppTemplateManagerContext ctx): base(ctx)
        {}
    }
}