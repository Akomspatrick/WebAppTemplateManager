using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.ModelAggregateRoot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public class ShellMaterialRepository : GenericRepository<ShellMaterial>, IShellMaterialRepository
    {
        public ShellMaterialRepository(DocumentVersionManagerContext ctx) : base(ctx)
        {
        }
    }
}
