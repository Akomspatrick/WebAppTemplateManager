using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories

{
    public  class  DocumentTypeRepository:GenericRepository<DocumentType>, IDocumentTypeRepository
    {
        public   DocumentTypeRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}