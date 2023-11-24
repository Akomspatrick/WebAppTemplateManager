using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories

{
    public  class  RevisionCapacityIntervalRepository:GenericRepository<RevisionCapacityInterval>, IRevisionCapacityIntervalRepository
    {
        public   RevisionCapacityIntervalRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}