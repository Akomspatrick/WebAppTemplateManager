using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.ModelAggregateRoot.Entities;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Infrastructure.Persistence.Repositories
{
    public class HigherModelRepository : GenericRepository<HigherModel>, IHigherModelRepository
    {
        public HigherModelRepository(DocumentVersionManagerContext ctx) : base(ctx)
        {
        }

        public Task<Either<GeneralFailures, HigherModel>> GetHigherModel(string modelTypeName)
        {
            throw new NotImplementedException();
        }
    }
}
