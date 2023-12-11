namespace DocumentVersionManager.Application.Contracts.RequestDTO
{
    public  record ApplicationRequestModelTypesDTO();
    public  record ApplicationRequestModelTypesByGuidDTO(Guid ModelTypesGuid);
    public  record ApplicationRequestModelTypesByIdDTO(string ModelTypesId);
    public  record ApplicationCreateModelTypesDTO();
    public  record ApplicationUpdateModelTypesDTO(Guid ModelTypesGuid);
    public  record ApplicationDeleteModelTypesDTO(Guid ModelTypesGuid);
}