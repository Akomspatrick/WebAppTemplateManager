using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories

{
    public  class  CapacityTestPointRepository:GenericRepository<CapacityTestPoint>, ICapacityTestPointRepository
    {
        public   CapacityTestPointRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}