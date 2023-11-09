using DocumentVersionManager.Domain.Interfaces;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public  class  RevisionCapacityIntervalRepository:GenericRepository<RevisionCapacityInterval>, IRevisionCapacityIntervalRepository
    {
        public  class  RevisionCapacityIntervalRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}