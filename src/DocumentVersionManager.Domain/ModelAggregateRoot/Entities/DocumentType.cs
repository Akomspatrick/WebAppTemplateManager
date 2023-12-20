using DocumentVersionManager.DomainBase.Base;
using DocumentVersionManager.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.Entities
{
    public partial class DocumentType : BaseEntity
    {
        //private DocumentType() { }
        //public static DocumentType Create(Guid documentGuid, string documentTypeName)
        //{

        //    if (string.IsNullOrWhiteSpace(documentTypeName))
        //    {
        //        throw new ArgumentNullException(nameof(documentTypeName));

        //    }
        //    if (documentTypeName.Length > FixedValues.DocumentTypeMaxLength)
        //    {
        //        throw new ArgumentException($"Model Type Name cannot be more than {FixedValues.DocumentTypeMaxLength} characters {nameof(documentTypeName)} ");
        //    }

        //    if (documentTypeName.Length < FixedValues.DocumentTypeMinLength)
        //    {
        //        throw new ArgumentException($"Model Type Name cannot be less than {FixedValues.DocumentTypeMinLength} characters {nameof(documentTypeName)} ");
        //    }


        //    return new DocumentType()
        //    {
        //        GuidId = documentGuid,
        //        DocumentTypeName = documentTypeName
        //    };
        //    // do some heavy lifting.

        //}

    }
}
