using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories

{
    public  class  DocumentDocumentTypeRepository:GenericRepository<DocumentDocumentType>, IDocumentDocumentTypeRepository
    {
        public   DocumentDocumentTypeRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}