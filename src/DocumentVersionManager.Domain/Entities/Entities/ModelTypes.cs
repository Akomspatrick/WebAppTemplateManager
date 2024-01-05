using DocumentVersionManager.Domain.Constants;
using DocumentVersionManager.DomainBase;

namespace DocumentVersionManager.Domain.Entities
{

    public partial class ModelType : BaseEntity
    {
        //private ModelType()
        //{
        //}
        //public static ModelType Create(Guid modelTypesId, string modelTypesName)
        //{

        //    if (string.IsNullOrWhiteSpace(modelTypesName))
        //    {
        //        throw new ArgumentNullException(nameof(modelTypesName));

        //    }
        //    if (modelTypesName.Length > FixedValues.modelTypesNameMaxLength)
        //    {
        //        throw new ArgumentException($"Model Type Name cannot be more than {FixedValues.modelTypesNameMaxLength} characters {nameof(modelTypesName)} but it is  {modelTypesName.Length}");
        //    }

        //    if (modelTypesName.Length < FixedValues.modelTypesNameMinLength)
        //    {
        //        throw new ArgumentException($"Model Type Name cannot be less than {FixedValues.modelTypesNameMinLength} characters {nameof(modelTypesName)} but it is {modelTypesName.Length}");
        //    }


        //    return new ModelType() { GuidId = modelTypesId, ModelTypeName = modelTypesName };

        //}


        //public void saveModelType()
        //{
        //    // do some heavy lifting.
        //    // use IModelTypesRepository to save the model type.
        //    if (modelTypesName == null)
        //    {
        //        ModelType aggregateRoot = ModelType.Create(modelTypesName);


        //    }

        //}
        //        public static ModelType Create(string modelTypeName, string modelTypeGroupName, Guid guidId)
        //=> new()
        //{
        //    ModelTypeName = modelTypeName,
        //    ModelTypeGroupName = modelTypeGroupName,
        //    GuidId = guidId,
        //};
        public static ModelType Create(string modelTypeName, string modelTypeGroupName, Guid guidId)
        {
            if (string.IsNullOrWhiteSpace(modelTypeName))
            {
                throw new ArgumentNullException(nameof(modelTypeName));

            }
            if (modelTypeName.Length > FixedValues.modelTypesNameMaxLength)
            {
                throw new ArgumentException($"Model Type Name cannot be more than {FixedValues.modelTypesNameMaxLength} characters {nameof(modelTypeName)} but it is  {modelTypeName.Length}");
            }
            if (modelTypeName.Length < FixedValues.modelTypesNameMinLength)
            {
                throw new ArgumentException($"Model Type Name cannot be less than {FixedValues.modelTypesNameMinLength} characters {nameof(modelTypeName)} but it is {modelTypeName.Length}");
            }
            if (guidId == Guid.Empty)
            {
                var x = new ArgumentException($"ModelType Guid Value cannot be empty {nameof(guidId)}");
                throw x;
            }
            return new ModelType() { GuidId = guidId, ModelTypeName = modelTypeName, ModelTypeGroupName = modelTypeGroupName };
        }


    }
}
