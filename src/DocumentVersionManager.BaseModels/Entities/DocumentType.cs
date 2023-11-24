namespace DocumentVersionManager.BaseModels.Entities
{
    public class DocumentType : BaseEntity
    {
        public string DocumentTypeName { get; init; } = string.Empty;// This is the primary key and the id of the document type name
        //public Guid DocumentTypeGuid { get; init; }
        public ICollection<DocumentDocumentType> DocumentDocumentTypes { get; set; }


    }
}
