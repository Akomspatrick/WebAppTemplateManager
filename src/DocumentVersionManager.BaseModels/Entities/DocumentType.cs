namespace DocumentVersionManager.BaseModels.Entities
{
    public class DocumentType : BaseEntity
    {
        public string TypeName { get; init; } = string.Empty;
        //public Guid DocumentTypeGuid { get; init; }
        public ICollection<DocumentDocumentType> DocumentDocumentTypes { get; set; }
      

    }
}
