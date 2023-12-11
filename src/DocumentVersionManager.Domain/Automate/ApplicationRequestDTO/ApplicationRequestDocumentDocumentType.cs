namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationRequestDocumentDocumentTypeDTO();
    public  record ApplicationRequestDocumentDocumentTypeByGuidDTO(Guid DocumentDocumentTypeGuid);
    public  record ApplicationRequestDocumentDocumentTypeByIdDTO(string DocumentDocumentTypeId);
    public  record ApplicationCreateDocumentDocumentTypeDTO();
    public  record ApplicationUpdateDocumentDocumentTypeDTO(Guid DocumentDocumentTypeGuid);
    public  record ApplicationDeleteDocumentDocumentTypeDTO(Guid DocumentDocumentTypeGuid);
}