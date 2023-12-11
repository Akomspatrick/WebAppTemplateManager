namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationRequestModelDTO();
    public  record ApplicationRequestModelByGuidDTO(Guid ModelGuid);
    public  record ApplicationRequestModelByIdDTO(string ModelId);
    public  record ApplicationCreateModelDTO();
    public  record ApplicationUpdateModelDTO(Guid ModelGuid);
    public  record ApplicationDeleteModelDTO(Guid ModelGuid);
}