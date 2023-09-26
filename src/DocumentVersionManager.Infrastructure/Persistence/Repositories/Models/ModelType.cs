using DocumentVersionManager.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Infrastructure.Persistence.Repositories.Models;

    public class ModelType:BaseEntity
    {
        public required string ModelTypeName { get; init; }
    }
