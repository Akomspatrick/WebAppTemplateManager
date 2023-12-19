namespace DocumentVersionManager.Contracts.RequestDTO
{
    public  record TestPointGetRequestByGuidDTO(Guid guid);
    public  record TestPointGetRequestByIdDTO(Object Value);
    public  record TestPointGetRequestDTO(Object Value);
    public  record TestPointCreateRequestDTO(Guid GuidId,Object Value );
    public  record TestPointUpdateRequestDTO(Object Value);
    public  record TestPointDeleteRequestDTO(Guid guid);
}