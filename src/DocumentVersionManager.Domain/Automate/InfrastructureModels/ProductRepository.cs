using DocumentVersionManager.Domain.Interfaces;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public  class  ProductRepository:GenericRepository<Product>, IProductRepository
    {
        public  class  ProductRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}