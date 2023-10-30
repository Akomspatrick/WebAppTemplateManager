using DocumentVersionManager.Domain.Base;
using DocumentVersionManager.Domain.Constants;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities
{
    public partial class Model : BaseEntity
    {
        //if I am not using domain driven design then i can specify the detail model here eg 
        // public ModelType ModelType { get; set; }
       // public string ModelId { get; init; } = string.Empty;
        public Guid ModelId { get; private set; }

        public string ModelName { get; init; } = string.Empty;

       // [ForeignKey("ModelTypesName")]
        public string ModelTypesName { get; private set; } = string.Empty;
        public ModelTypes? ModelTypes { get; set; }


        public ICollection<ModelVersion> ModelVersions;
        //public string ModelTypesId { get; init; } = string.Empty;

        //if I am not using domain driven design then i can specify the detail model here eg 
        public static Model Create(Guid modelId, string modelName, string modelTypesName)
        {

            if (string.IsNullOrWhiteSpace(modelName))
            {
                throw new ArgumentNullException(nameof(modelName));

            }
            if (modelName.Length > FixedValues.ModelNameMaxLength)
            {
                throw new ArgumentException($"Model Type Name cannot be more than {FixedValues.ModelNameMaxLength} characters {nameof(modelName)} ");
            }

            if (modelName.Length < FixedValues.ModelNameMinLength)
            {
                throw new ArgumentException($"Model Type Name cannot be less than {FixedValues.ModelNameMaxLength}  characters  {nameof(modelName)} ");
            }


            //if (string.IsNullOrWhiteSpace(modelTypesId))
            //{
            //    throw new ArgumentNullException(nameof(modelTypesId));

            //}
            //if (modelTypesId.Length > FixedValues.modelTypesIdMaxLength)
            //{
            //    throw new ArgumentException($"Model Type Name cannot be more than {FixedValues.modelTypesIdMaxLength} characters {nameof(modelTypesId)} ");
            //}

            //if (modelTypesId.Length < FixedValues.modelTypesIdMinLength)
            //{
            //    throw new ArgumentException($"Model Type Name cannot be less than {FixedValues.modelTypesIdMinLength} characters {nameof(modelTypesId)} ");
            //}


            //if (string.IsNullOrWhiteSpace(modelId))
            //{
            //    throw new ArgumentNullException(nameof(modelId));

            //}
            //if (modelId.Length > FixedValues.ModelIdMaxLength)
            //{
            //    throw new ArgumentException($"Model Type Name cannot be more than {FixedValues.ModelIdMaxLength} characters {nameof(modelId)} ");
            //}

            //if (modelId.Length < FixedValues.ModelIdMinLength)
            //{
            //    throw new ArgumentException($"Model Type Name cannot be less than {FixedValues.ModelIdMinLength} characters {nameof(modelId)} ");
            //}

            return new Model() { ModelId = modelId, ModelTypesName = modelTypesName, ModelName = modelName };

        }




    }

}


