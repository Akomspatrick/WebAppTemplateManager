using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories

{
    public  class  TestFlowTypeRepository:GenericRepository<TestFlowType>, ITestFlowTypeRepository
    {
        public   TestFlowTypeRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}