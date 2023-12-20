using DocumentVersionManager.Domain.Constants;
using DocumentVersionManager.DomainBase.Base;

namespace DocumentVersionManager.Domain.Entities
{
    public partial class Model : BaseEntity
    {


        //private Model()
        //{
        //}
        //public static Model Create(Guid modelId, string modelName, string modelTypesName)
        //{

        //    if (string.IsNullOrWhiteSpace(modelName))
        //    {
        //        throw new ArgumentNullException(nameof(modelName));

        //    }
        //    if (modelName.Length > FixedValues.ModelNameMaxLength)
        //    {
        //        throw new ArgumentException($"Model Type Name cannot be more than {FixedValues.ModelNameMaxLength} characters {nameof(modelName)} ");
        //    }

        //    if (modelName.Length < FixedValues.ModelNameMinLength)
        //    {
        //        throw new ArgumentException($"Model Type Name cannot be less than {FixedValues.ModelNameMaxLength}  characters  {nameof(modelName)} ");
        //    }




        //    return new Model() { GuidId = modelId, ModelTypeName = modelTypesName, ModelName = modelName };

        //}



    }

}


