using AutoMapper;

using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;


namespace DocumentVersionManager.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           // CreateMap<ModelTypeGetRequestDTO, ApplicationModelTypeCreateRequestDTO>().ReverseMap();
           // CreateMap<ModelTypeCreateRequestDTO, ApplicationModelTypeCreateRequestDTO>().ReverseMap();
           // CreateMap<ModelTypeUpdateRequestDTO, ApplicationModelTypeUpdateRequestDTO>().ReverseMap();
           // CreateMap<ModelTypeDeleteRequestDTO, ApplicationModelTypeDeleteRequestDTO>().ReverseMap();
           // CreateMap<ModelTypeGetRequestByGuidDTO, ApplicationModelTypeGetRequestByGuidDTO>().ReverseMap();
           ////==6 CreateMap<ModelTypeGetRequestByIdDTO, ApplicationModelTypeGetRequestByIdDTO>().ReverseMap();
           // CreateMap<ModelTypeResponseDTO, ApplicationModelTypeResponseDTO>().ReverseMap();
           // CreateMap<ModelResponseDTO, ModelResponseDTO>().ReverseMap();









            //CreateMap<Persistence.Repositories.Models.ModelType, Domain.ModelAggregateRoot.Entities.ModelType>();//.ReverseMap();
            //CreateMap< Domain.ModelAggregateRoot.Entities.ModelType, Persistence.Repositories.Models.ModelType>();
            ////CreateMap<Domain.ModelAggregateRoot.Entities.ModelTypes, Domain.ModelAggregateRoot.Entities.ModelTypes>().ReverseMap();


            //CreateMap<Persistence.Repositories.Models.Model, Domain.ModelAggregateRoot.Entities.Model>().ReverseMap();
            //CreateMap<Persistence.Repositories.Models.CapacityDocument, Domain.ModelAggregateRoot.Entities.CapacityDocument>().ReverseMap();
            //CreateMap<Persistence.Repositories.Models.CapacitySpecification, Domain.ModelAggregateRoot.Entities.CapacitySpecification>().ReverseMap();
        }
    }
}
