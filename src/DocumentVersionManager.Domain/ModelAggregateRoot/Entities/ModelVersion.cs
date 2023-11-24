using DocumentVersionManager.Domain.Constants;
using DocumentVersionManager.DomainBase.Base;

namespace DocumentVersionManager.Domain.Entities
{
    public partial class ModelVersion : BaseEntity
    {

        public static ModelVersion Create(Guid modelVersionGUID, string modelVersionName, int modelVersionId, string versionDescription, string modelName, string username, DateTime timestamp)
        {
            if ((modelVersionId < 0))
            {
                throw new ArgumentException($"modelVersionId cannot be more than be less that zero ");


            }

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



            return new ModelVersion()
            {
                GuidId = modelVersionGUID,
                ModelVersionName = modelVersionName,
                ModelVersionId = modelVersionId,
                VersionDescription = versionDescription,
                ModelName = modelName,
                UserName = username,
                Timestamp = timestamp

            };

        }
    }
}
