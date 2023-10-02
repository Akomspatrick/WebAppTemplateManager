using DocumentVersionManager.Domain.Base;
using DocumentVersionManager.Domain.Constants;
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

        if (string.IsNullOrWhiteSpace(modelTypeName))
        {
            throw new ArgumentNullException(nameof(modelTypeName));

        }
        if (modelTypeName.Length > FixedValues.ModelTypeNameMaxLength)
        {
            throw new ArgumentException($"Model Type Name cannot be more than {FixedValues.ModelTypeNameMaxLength} characters {nameof(modelTypeName)} ");
        }

        if (modelTypeName.Length < FixedValues.ModelTypeNameMinLength)
        {
            throw new ArgumentException($"Model Type Name cannot be less than {FixedValues.ModelTypeNameMinLength} characters {nameof(modelTypeName)} ");
        }


        return new ModelType() { ModelTypeName = modelTypeName };
        // do some heavy lifting.

    }



}
