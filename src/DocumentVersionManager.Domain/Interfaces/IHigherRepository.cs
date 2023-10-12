
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
    public interface IHigherModelRepository : IGenericRepository<HigherModel>
    {
        Task<Either<GeneralFailures, HigherModel>> GetHigherModel(string modelTypeName);
    }


}
