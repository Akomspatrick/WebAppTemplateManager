namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationRequestDocumentBasePathDTO();
    public  record ApplicationRequestDocumentBasePathByGuidDTO(Guid DocumentBasePathGuid);
    public  record ApplicationRequestDocumentBasePathByIdDTO(string DocumentBasePathId);
    public  record ApplicationCreateDocumentBasePathDTO();
    public  record ApplicationUpdateDocumentBasePathDTO(Guid DocumentBasePathGuid);
    public  record ApplicationDeleteDocumentBasePathDTO(Guid DocumentBasePathGuid);
}