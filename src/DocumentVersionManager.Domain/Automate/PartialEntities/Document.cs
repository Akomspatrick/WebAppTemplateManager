using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class Document  : BaseEntity
    {
        private Document(){}
            public string DocumentName    { get; init; }  = string.Empty; 
            public string ModelName    { get; init; }  = string.Empty; 
            public int ModelVersionId    { get; init; } 
            public string ContentPDFPath    { get; init; }  = string.Empty; 
            public string ChangeOrderPDFPath    { get; init; }  = string.Empty; 
            public string DocumentBasePathId    { get; init; }  = string.Empty; 
            public string DocumentDescription    { get; init; }  = string.Empty; 
            public DateTime Timestamp    { get; init; } 
            public ModelVersion ModelVersion    { get; init; } 
        private  List <DocumentDocumentType> _DocumentDocumentTypes { get;  set;}  = new List<DocumentDocumentType>();
        public  IReadOnlyCollection<DocumentDocumentType> DocumentDocumentTypes => _DocumentDocumentTypes;
            public Guid GuidId    { get; init; } 
        
        public static Document Create(string  documentName, string  modelName, int  modelVersionId, string  contentPDFPath, string  changeOrderPDFPath, string  documentBasePathId, string  documentDescription, DateTime  timestamp, Guid  guidId)
        =>new()
        {
            DocumentName = documentName ,
            ModelName = modelName ,
            ModelVersionId = modelVersionId ,
            ContentPDFPath = contentPDFPath ,
            ChangeOrderPDFPath = changeOrderPDFPath ,
            DocumentBasePathId = documentBasePathId ,
            DocumentDescription = documentDescription ,
            Timestamp = timestamp ,
            GuidId = guidId ,
        };
    }
}