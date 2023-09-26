using AutoMapper;
using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Infrastructure.Persistence.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public class ModelTypesRepository : GenericRepository<ModelType>, IModelTypesRepository
    {
        private readonly IMapper _mapper;
        public ModelTypesRepository(DocumentVersionManagerContext ctx ,  IMapper mapper) : base(ctx)
        {
            _mapper = mapper;
        }

        public Task<Domain.ModelAggregateRoot.Entities.ModelType> AddAsync(Domain.ModelAggregateRoot.Entities.ModelType entity,CancellationToken cancellationToken)
        {
           
            var model =  _mapper.Map<ModelType>(entity);
            base.AddAsync(model,cancellationToken);

            return Task.FromResult(entity);
        }

        public Task<Domain.ModelAggregateRoot.Entities.ModelType> DeleteAsync(Domain.ModelAggregateRoot.Entities.ModelType entity)
        {
            var model = _mapper.Map<ModelType>(entity);
            base.DeleteAsync(model);

            return Task.FromResult(entity);
        }

        public Task<Domain.ModelAggregateRoot.Entities.ModelType> UpdateAsync(Domain.ModelAggregateRoot.Entities.ModelType entity)
        {
            var model = _mapper.Map<ModelType>(entity);
            base.UpdateAsync(model);

            return Task.FromResult(entity);
        }

        Task<IReadOnlyList<Domain.ModelAggregateRoot.Entities.ModelType>> IGenericRepository<Domain.ModelAggregateRoot.Entities.ModelType>.GetAll()
        {
           
            
            var result = base.GetAll();
            var model = _mapper.Map<IReadOnlyList<Domain.ModelAggregateRoot.Entities.ModelType>>(result);
            return Task.FromResult(model);
        }
    }
}
