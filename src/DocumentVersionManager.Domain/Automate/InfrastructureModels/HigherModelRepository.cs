using DocumentVersionManager.Domain.Interfaces;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public  class  HigherModelRepository:GenericRepository<HigherModel>, IHigherModelRepository
    {
        public  class  HigherModelRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}