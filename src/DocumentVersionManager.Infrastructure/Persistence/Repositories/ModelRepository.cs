using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.ModelAggregateRoot.Entities;
using LanguageExt;

namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public class ModelRepository : GenericRepository<Model>, IModelRepository
    {
        public ModelRepository(DocumentVersionManagerContext ctx) : base(ctx)
        {

        }


        //public Task<Model> AddAsync(Model entity, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Model> DeleteAsync(Model entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Model> UpdateAsync(Model entity)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<IReadOnlyList<Model>> IGenericRepository<Model>.GetAll()
        //{
        //    throw new NotImplementedException();
        //}
    }

}


