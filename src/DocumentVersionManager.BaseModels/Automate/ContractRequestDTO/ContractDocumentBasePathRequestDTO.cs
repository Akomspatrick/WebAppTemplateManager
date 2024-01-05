namespace DocumentVersionManager.Contracts.RequestDTO
{
    public  record DocumentBasePathGetRequestByGuidDTO(Guid guid);
    public  record DocumentBasePathGetRequestByIdDTO(Object Value);
    public  record DocumentBasePathGetRequestDTO(Object Value);
    public  record DocumentBasePathCreateRequestDTO(Guid GuidId,Object Value );
    public  record DocumentBasePathUpdateRequestDTO(Object Value);
    public  record DocumentBasePathDeleteRequestDTO(Guid guid);
}