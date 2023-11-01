using DocumentVersionManager.Domain.Base;
using DocumentVersionManager.Domain.ModelAggregateRoot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities
{
    public class DocumentDocumentType:BaseEntity
    {
        public string DocumentName { get; init; } = string.Empty;//documents_name
        public string ModelName { get; init; } = string.Empty;//documents_models_name
        public int ModelVersionId { get; init; }
        public string DocumentTypeName { get; init; } = string.Empty;//documentTypes_name
        public Document Document;
        public DocumentType DocumentType;
        //public Guid DocumentDocumentTypeGuid
        //{
        //    get; init;
        //}

        //public ModelVersion ModelVersion;
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




