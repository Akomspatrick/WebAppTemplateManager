namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationRequestSpecificationDTO();
    public  record ApplicationRequestSpecificationByGuidDTO(Guid SpecificationGuid);
    public  record ApplicationRequestSpecificationByIdDTO(string SpecificationId);
    public  record ApplicationCreateSpecificationDTO();
    public  record ApplicationUpdateSpecificationDTO(Guid SpecificationGuid);
    public  record ApplicationDeleteSpecificationDTO(Guid SpecificationGuid);
}