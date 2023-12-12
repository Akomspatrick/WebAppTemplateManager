using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories

{
    public  class  SpecificationRepository:GenericRepository<Specification>, ISpecificationRepository
    {
        public   SpecificationRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}