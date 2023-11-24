using DocumentVersionManager.DomainBase.Base;

namespace DocumentVersionManager.Domain.Entities
{
    public partial class DocumentDocumentType : BaseEntity
    {

        public static DocumentDocumentType Create(Guid documentDocumentTypeGuid, string documentName, int modelVersionId, string modelName, string documentTypeName)
        {
            if ((modelVersionId < 0))
            {
                throw new ArgumentException($"modelVersionId cannot be more than be less that zero ");


            }

            if (string.IsNullOrWhiteSpace(modelName))
            {
                throw new ArgumentNullException(nameof(modelName));

            }



            return new DocumentDocumentType()
            {
                GuidId = documentDocumentTypeGuid,
                DocumentName = documentName,
                ModelName = modelName,
                ModelVersionId = modelVersionId,
                DocumentTypeName = documentTypeName



            };

        }
    }
}




