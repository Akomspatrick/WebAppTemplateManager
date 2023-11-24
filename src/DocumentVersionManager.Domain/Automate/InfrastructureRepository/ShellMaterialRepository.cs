using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.Repositories

{
    public  class  ShellMaterialRepository:GenericRepository<ShellMaterial>, IShellMaterialRepository
    {
        public   ShellMaterialRepository( DocumentVersionManagerContext ctx): base(ctx)
        {}
    }
}