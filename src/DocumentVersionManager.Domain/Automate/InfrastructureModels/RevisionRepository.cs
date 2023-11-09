using DocumentVersionManager.Domain.Interfaces;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public  class  RevisionRepository:GenericRepository<Revision>, IRevisionRepository
    {
        public  class  RevisionRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}