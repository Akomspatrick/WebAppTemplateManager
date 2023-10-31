﻿using DocumentVersionManager.Domain.Base;
using DocumentVersionManager.Domain.Constants;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities
{

    public class ModelTypes : BaseEntity
    {
        public Guid ModelTypesId { get; private set; } 
        public string ModelTypesName { get; private set; } = string.Empty;

        public ICollection<Model> Models { get; set; } //This is for navigation property.// to be removed if i want  to strictly follow domain driven design
        public static ModelTypes Create(Guid modelTypesId, string modelTypesName)
        {

            if (string.IsNullOrWhiteSpace(modelTypesName))
            {
                throw new ArgumentNullException(nameof(modelTypesName));

            }
            if (modelTypesName.Length > FixedValues.modelTypesNameMaxLength)
            {
                throw new ArgumentException($"Model Type Name cannot be more than {FixedValues.modelTypesNameMaxLength} characters {nameof(modelTypesName)} but it is  {modelTypesName.Length}");
            }

            if (modelTypesName.Length < FixedValues.modelTypesNameMinLength)
            {
                throw new ArgumentException($"Model Type Name cannot be less than {FixedValues.modelTypesNameMinLength} characters {nameof(modelTypesName)} but it is {modelTypesName.Length}");
            }

            //if (string.IsNullOrWhiteSpace(modelTypesId))
            //{
            //    throw new ArgumentNullException(nameof(modelTypesId));

            //}
            //if (modelTypesId.Length > FixedValues.modelTypesIdMaxLength)
            //{
            //    throw new ArgumentException($"Model Type Id cannot be more than {FixedValues.modelTypesIdMaxLength} characters {nameof(modelTypesId)} but it is {modelTypesId.Length}");
            //}

            //if (modelTypesId.Length < FixedValues.modelTypesIdMinLength)
            //{
            //    throw new ArgumentException($"Model Type Id cannot be less than {FixedValues.modelTypesIdMinLength} characters {nameof(modelTypesId)}  but it is {modelTypesId.Length}");
            //}

            return new ModelTypes() { ModelTypesId = modelTypesId, ModelTypesName = modelTypesName };

        }


        //public void saveModelType()
        //{
        //    // do some heavy lifting.
        //    // use IModelTypesRepository to save the model type.
        //    if (modelTypesName == null) {
        //        ModelType aggregateRoot =  ModelType.Create(modelTypesName);
        //        aggregateRoot.save();

        //    }

        //}



    }
}