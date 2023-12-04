using DocumentVersionManager.DomainBase.Base;
using DocumentVersionManager.Domain.Constants;

namespace DocumentVersionManager.Domain.Entities
{
    public partial class Document : BaseEntity
    {


        public static Document Create(Guid documentGuid, string documentName, int modelVersionId, string modelName, string contentPDFPath, string changeOrderPDFPath, string documentDescription, DateTime timestamp)
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



            return new Document()
            {
                DocumentDescription = documentDescription,
                DocumentName = documentName,
                GuidId = documentGuid,
                ModelName = modelName,
                ModelVersionId = modelVersionId,
                ContentPDFPath = contentPDFPath,
                ChangeOrderPDFPath = changeOrderPDFPath,
                Timestamp = timestamp,
                DocumentBasePathId = "001"





            };

        }
    }
}
