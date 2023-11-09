using DocumentVersionManager.Domain.Interfaces;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public  class  CapacitySpecificationRepository:GenericRepository<CapacitySpecification>, ICapacitySpecificationRepository
    {
        public  class  CapacitySpecificationRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}