using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories

{
    public  class  DocumentRepository:GenericRepository<Document>, IDocumentRepository
    {
        public   DocumentRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}