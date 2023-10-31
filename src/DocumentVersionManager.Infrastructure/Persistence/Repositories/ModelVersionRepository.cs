using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Infrastructure.Persistence.Repositories;
using DocumentVersionManager.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentVersionManager.Domain.ModelAggregateRoot.Entities;

namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public class ModelVersionRepository : GenericRepository<ModelVersion>, IModelVersion
    {
        public ModelVersionRepository(DocumentVersionManagerContext ctx) : base(ctx)
        {
        }
    }
}


