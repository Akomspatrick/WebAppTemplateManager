
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
    public interface IModelTypesRepository : IGenericRepository<ModelTypes>
    {
          Task<Either<GeneralFailures, ModelTypes>> GetModelTypeByGuidId(Guid modelTypesId);
        // Task<Either<GeneralFailures, int>> DeleteByModelTypeById(string modelTypesId, CancellationToken cancellationToken);
    }


}
