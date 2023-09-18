using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Infrastructure.Persistence.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public class ModelTypesRepository : GenericRepository<ModelTypes>, IModelTypesRepository
    {
        public ModelTypesRepository(DocumentVersionManagerContext ctx) : base(ctx)
        {
        }

        public Task<Domain.ModelAggregateRoot.Entities.ModelTypes> AddAsync(Domain.ModelAggregateRoot.Entities.ModelTypes entity)
        {
           // base.AddAsync(entity);
            return Task.FromResult(entity);
        }

        public Task<Domain.ModelAggregateRoot.Entities.ModelTypes> DeleteAsync(Domain.ModelAggregateRoot.Entities.ModelTypes entity)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.ModelAggregateRoot.Entities.ModelTypes> UpdateAsync(Domain.ModelAggregateRoot.Entities.ModelTypes entity)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<Domain.ModelAggregateRoot.Entities.ModelTypes>> IGenericRepository<Domain.ModelAggregateRoot.Entities.ModelTypes>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
