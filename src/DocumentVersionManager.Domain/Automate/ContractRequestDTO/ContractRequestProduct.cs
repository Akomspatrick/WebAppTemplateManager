namespace DocumentVersionManager.Contracts.RequestDTO
{
    public  record ProductGetRequestByGuidDTO(Guid guid);
    public  record ProductGetRequestByIdDTO(Object Value);
    public  record ProductGetRequestDTO(Object Value);
    public  record ProductCreateRequestDTO(Guid GuidId,Object Value );
    public  record ProductUpdateRequestDTO(Object Value);
    public  record ProductDeleteRequestDTO(Guid guid);
}