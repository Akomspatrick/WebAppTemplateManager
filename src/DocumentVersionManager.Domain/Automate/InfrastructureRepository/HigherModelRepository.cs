using DocumentVersionManager.Domain.Interfaces;
using ProductionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories

{
    public  class  HigherModelRepository:GenericRepository<HigherModel>, IHigherModelRepository
    {
        public   HigherModelRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}