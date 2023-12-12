using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories

{
    public  class  ProductRepository:GenericRepository<Product>, IProductRepository
    {
        public   ProductRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}