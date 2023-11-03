using DocumentVersionManager.Domain.Base;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.ModelAggregateRoot.Entities;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.Interfaces
{
    public interface IModelRepository : IGenericRepository<Model>
    {
        // Task<Either<ModelFailures, ModelType>> GetModelType(string modelTypesName);
       
       Task<Either<GeneralFailures, List<Model>>> GetAllWithIncludes(CancellationToken cancellationToken);
    }
}
