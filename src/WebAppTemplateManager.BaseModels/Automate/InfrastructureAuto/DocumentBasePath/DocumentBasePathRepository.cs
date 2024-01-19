using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories

{
    public  class  DocumentBasePathRepository:GenericRepository<DocumentBasePath>, IDocumentBasePathRepository
    {
        public   DocumentBasePathRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}