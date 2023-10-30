using DocumentVersionManager.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities
{
    public class ModelVersion:BaseEntity
    {   public int ModelVersionId { get; init; }
        
        public string VersionDescription { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;


        public Model Models;
        public string ModelName { get; init; } = string.Empty;
        public Guid ModelVersionGUID { get; init; }
   
        
        public DateTime Timestamp { get; init; }

        public string Username { get; init; } = string.Empty;
    }
}
