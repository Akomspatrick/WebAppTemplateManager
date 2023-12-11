namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationRequestDocumentTypeDTO();
    public  record ApplicationRequestDocumentTypeByGuidDTO(Guid DocumentTypeGuid);
    public  record ApplicationRequestDocumentTypeByIdDTO(string DocumentTypeId);
    public  record ApplicationCreateDocumentTypeDTO();
    public  record ApplicationUpdateDocumentTypeDTO(Guid DocumentTypeGuid);
    public  record ApplicationDeleteDocumentTypeDTO(Guid DocumentTypeGuid);
}