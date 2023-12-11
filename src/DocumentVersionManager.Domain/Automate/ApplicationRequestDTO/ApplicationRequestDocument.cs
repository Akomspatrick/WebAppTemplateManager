namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationRequestDocumentDTO();
    public  record ApplicationRequestDocumentByGuidDTO(Guid DocumentGuid);
    public  record ApplicationRequestDocumentByIdDTO(string DocumentId);
    public  record ApplicationCreateDocumentDTO();
    public  record ApplicationUpdateDocumentDTO(Guid DocumentGuid);
    public  record ApplicationDeleteDocumentDTO(Guid DocumentGuid);
}