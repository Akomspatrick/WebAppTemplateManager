using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories

{
    public  class  TestPointRepository:GenericRepository<TestPoint>, ITestPointRepository
    {
        public   TestPointRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}