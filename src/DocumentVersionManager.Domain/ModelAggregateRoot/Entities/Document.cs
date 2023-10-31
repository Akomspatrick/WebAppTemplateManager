using DocumentVersionManager.Domain.Base;
using DocumentVersionManager.Domain.Constants;
using LanguageExt.ClassInstances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities
{
    public class Document: BaseEntity
    {
        public string DocumentName { get; init; } = string.Empty;
        public string ModelName { get; init; } = string.Empty;
        public int ModelVersionId { get; init; }
        public Guid DocumentGuid { get; init; }
        public string ContentPDFPath { get; init; } = string.Empty;
        public string ChangeOrderPDFPath { get; init; } = string.Empty;

        public string DocumentDescription { get; init; } = string.Empty;
        public DateTime Timestamp { get; init; }

        public ModelVersion ModelVersion;

        public ICollection<DocumentDocumentType> DocumentDocumentTypes { get; set; }

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
               DocumentGuid = documentGuid,
               ModelName = modelName,
               ModelVersionId = modelVersionId,
               ContentPDFPath = contentPDFPath,
               ChangeOrderPDFPath = changeOrderPDFPath,
               Timestamp = timestamp


            };

        }
    }
}
