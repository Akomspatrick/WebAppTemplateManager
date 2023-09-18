using DocumentVersionManager.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities;

    public class ModelTypes : BaseEntity<string>
{
        public required string ModelName { get; init; }
    }
