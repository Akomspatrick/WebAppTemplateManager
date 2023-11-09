using DocumentVersionManager.Domain.Interfaces;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public  class  DocumentRepository:GenericRepository<Document>, IDocumentRepository
    {
        public  class  DocumentRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}