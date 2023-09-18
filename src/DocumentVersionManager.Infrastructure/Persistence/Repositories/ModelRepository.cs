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
    public  class ModelRepository: GenericRepository<Model> ,IModelRepository
    {
        public ModelRepository(DocumentVersionManagerContext ctx):base(ctx)
        {
                
        }

        public Task<Domain.ModelAggregateRoot.Entities.Model> AddAsync(Domain.ModelAggregateRoot.Entities.Model entity)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.ModelAggregateRoot.Entities.Model> DeleteAsync(Domain.ModelAggregateRoot.Entities.Model entity)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.ModelAggregateRoot.Entities.Model> UpdateAsync(Domain.ModelAggregateRoot.Entities.Model entity)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<Domain.ModelAggregateRoot.Entities.Model>> IGenericRepository<Domain.ModelAggregateRoot.Entities.Model>.GetAll()
        {
            throw new NotImplementedException();
        }
    }

}


