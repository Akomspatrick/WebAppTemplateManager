using DocumentVersionManager.Domain.Constants;
using DocumentVersionManager.DomainBase.Base;

namespace DocumentVersionManager.Domain.Entities
{
    public partial class Model : BaseEntity
    {
        //if I am not using domain driven design then i can specify the detail model here eg 
        // public ModelType ModelType { get; set; }
        // public string ModelId { get; init; } = string.Empty;
        // public Guid ModelId { get; private set; }


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




            return new Model() { GuidId = modelId, ModelTypesName = modelTypesName, ModelName = modelName };

        }



    }

}


