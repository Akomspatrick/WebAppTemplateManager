using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories

{
    public  class  RevisionRepository:GenericRepository<Revision>, IRevisionRepository
    {
        public   RevisionRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}