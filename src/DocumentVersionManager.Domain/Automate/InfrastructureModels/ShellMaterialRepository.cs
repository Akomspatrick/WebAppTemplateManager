using DocumentVersionManager.Domain.Interfaces;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public  class  ShellMaterialRepository:GenericRepository<ShellMaterial>, IShellMaterialRepository
    {
        public  class  ShellMaterialRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}