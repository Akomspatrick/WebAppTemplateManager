using DocumentVersionManager.Domain.Base;
using DocumentVersionManager.Domain.Constants;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities;

public class ModelTypes : BaseEntity
{
    public string ModelTypeId { get; private set; } = string.Empty;
    public string ModelTypeName { get; private set; } = string.Empty;
    // public required string ModelTypeName { get; init; }

    public static ModelTypes Create(string modelTypeId, string modelTypeName)
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

        if (string.IsNullOrWhiteSpace(modelTypeId))
        {
            throw new ArgumentNullException(nameof(modelTypeId));

        }
        if (modelTypeId.Length > FixedValues.ModelTypeIdMaxLength)
        {
            throw new ArgumentException($"Model Type Name cannot be more than {FixedValues.ModelTypeIdMaxLength} characters {nameof(modelTypeId)} ");
        }

        if (modelTypeId.Length < FixedValues.ModelTypeIdMinLength)
        {
            throw new ArgumentException($"Model Type Name cannot be less than {FixedValues.ModelTypeIdMinLength} characters {nameof(modelTypeId)} ");
        }


        return new ModelTypes() { ModelTypeId = modelTypeId, ModelTypeName = modelTypeName };




       
        // do some heavy lifting.

    }


    //public void saveModelType()
    //{
    //    // do some heavy lifting.
    //    // use IModelTypesRepository to save the model type.
    //    if (ModelTypeName == null) {
    //        ModelType aggregateRoot =  ModelType.Create(ModelTypeName);
    //        aggregateRoot.save();

    //    }

    //}



}
