using DocumentVersionManager.Domain.Interfaces;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public  class  DocumentDocumentTypeRepository:GenericRepository<DocumentDocumentType>, IDocumentDocumentTypeRepository
    {
        public  class  DocumentDocumentTypeRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}