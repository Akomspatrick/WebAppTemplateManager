using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories

{
    public  class  CapacitySpecificationRepository:GenericRepository<CapacitySpecification>, ICapacitySpecificationRepository
    {
        public   CapacitySpecificationRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}