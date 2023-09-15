using DocumentVersionManager.Domain.Base;
using DocumentVersionManager.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Infrastructure.Persistence.Repositories.Models
{
    public  class Model//:BaseEntity
    {
        public string ModelName { get; init; } = string.Empty;
        public string ModelTypeName { get; init; } = string.Empty;

        public Model()
        {
                
        }

    }

}


