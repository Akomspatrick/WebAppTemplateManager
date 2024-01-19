using WebAppTemplateManager.Domain.Interfaces;
using WebAppTemplateManager.Domain.Entities;
namespace WebAppTemplateManager.Infrastructure.Persistence.Repositories

{
    public  class  ModelTypeGroupRepository:GenericRepository<ModelTypeGroup>, IModelTypeGroupRepository
    {
        public   ModelTypeGroupRepository( WebAppTemplateManagerContext ctx): base(ctx)
        {}
    }
}