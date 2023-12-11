namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationRequestModelVersionDTO();
    public  record ApplicationRequestModelVersionByGuidDTO(Guid ModelVersionGuid);
    public  record ApplicationRequestModelVersionByIdDTO(string ModelVersionId);
    public  record ApplicationCreateModelVersionDTO();
    public  record ApplicationUpdateModelVersionDTO(Guid ModelVersionGuid);
    public  record ApplicationDeleteModelVersionDTO(Guid ModelVersionGuid);
}