namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationRequestModelTypeDTO();
    public  record ApplicationRequestModelTypeByGuidDTO(Guid ModelTypeGuid);
    public  record ApplicationRequestModelTypeByIdDTO(string ModelTypeId);
    public  record ApplicationCreateModelTypeDTO();
    public  record ApplicationUpdateModelTypeDTO(Guid ModelTypeGuid);
    public  record ApplicationDeleteModelTypeDTO(Guid ModelTypeGuid);
}