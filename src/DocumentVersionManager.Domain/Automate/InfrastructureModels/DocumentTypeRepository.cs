using DocumentVersionManager.Domain.Interfaces;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public  class  DocumentTypeRepository:GenericRepository<DocumentType>, IDocumentTypeRepository
    {
        public  class  DocumentTypeRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}