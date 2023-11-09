using DocumentVersionManager.Domain.Interfaces;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public  class  CapacityTestPointRepository:GenericRepository<CapacityTestPoint>, ICapacityTestPointRepository
    {
        public  class  CapacityTestPointRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}