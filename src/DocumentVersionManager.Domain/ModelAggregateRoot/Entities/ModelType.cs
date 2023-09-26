using DocumentVersionManager.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities;

public class ModelType : BaseEntity<string>
{
    public string ModelTypeName { get; private set; } = string.Empty;
    // public required string ModelTypeName { get; init; }

    public static ModelType Create(string modelTypeName)
    {
        var modelType = new ModelType() { ModelTypeName = modelTypeName };
        // do some heavy lifting.
        return modelType;
    }
}
