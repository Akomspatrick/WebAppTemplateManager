using DocumentVersionManager.Domain.Enumerations;
using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Infrastructure.Persistence.Repositories;
using DocumentVersionManager.Infrastructure.Persistence.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Infrastructure.Persistence
{
    public  class ModelRepository//: GenericRepository<Model> ,IModelRepository<Model>
    {
        public ModelRepository(DocumentVersionManagerContext ctx)
        {
                
        }

    }

}


