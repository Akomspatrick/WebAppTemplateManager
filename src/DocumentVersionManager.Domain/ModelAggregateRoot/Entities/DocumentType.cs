using DocumentVersionManager.Domain.Base;
using DocumentVersionManager.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities
{
    public class DocumentType : BaseEntity
    {
        public string TypeName { get; init; } = string.Empty;
        public Guid DocumentTypeGuid { get; init; }
        public ICollection<DocumentDocumentType> DocumentDocumentTypes { get; set; }
        public static DocumentType Create(string documentTypeName)
        {

            if (string.IsNullOrWhiteSpace(documentTypeName))
            {
                throw new ArgumentNullException(nameof(documentTypeName));

            }
            if (documentTypeName.Length > FixedValues.DocumentTypeMaxLength)
            {
                throw new ArgumentException($"Model Type Name cannot be more than {FixedValues.DocumentTypeMaxLength} characters {nameof(documentTypeName)} ");
            }

            if (documentTypeName.Length < FixedValues.DocumentTypeMinLength)
            {
                throw new ArgumentException($"Model Type Name cannot be less than {FixedValues.DocumentTypeMinLength} characters {nameof(documentTypeName)} ");
            }


            return new DocumentType() { TypeName = documentTypeName };
            // do some heavy lifting.

        }

    }
}
