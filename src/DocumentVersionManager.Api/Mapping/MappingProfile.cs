using AutoMapper;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.RequestDTO;


namespace DocumentVersionManager.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ModelTypeGetRequestDTO, ApplicationModelTypeCreateRequestDTO>();
            CreateMap<ModelTypeCreateRequestDTO, ApplicationModelTypeCreateRequestDTO>();
            CreateMap<ModelTypeUpdateRequestDTO, ApplicationModelTypeUpdateRequestDTO>();
            CreateMap<ModelTypeDeleteRequestDTO, ApplicationModelTypeDeleteRequestDTO>();
            CreateMap<ModelTypeGetRequestByGuidDTO, ApplicationModelTypeGetRequestByGuidDTO>();
            CreateMap<ModelTypeGetRequestByIdDTO, ApplicationModelTypeGetRequestByIdDTO>();









            //CreateMap<Persistence.Repositories.Models.ModelType, Domain.ModelAggregateRoot.Entities.ModelType>();//.ReverseMap();
            //CreateMap< Domain.ModelAggregateRoot.Entities.ModelType, Persistence.Repositories.Models.ModelType>();
            ////CreateMap<Domain.ModelAggregateRoot.Entities.ModelTypes, Domain.ModelAggregateRoot.Entities.ModelTypes>().ReverseMap();


            //CreateMap<Persistence.Repositories.Models.Model, Domain.ModelAggregateRoot.Entities.Model>().ReverseMap();
            //CreateMap<Persistence.Repositories.Models.CapacityDocument, Domain.ModelAggregateRoot.Entities.CapacityDocument>().ReverseMap();
            //CreateMap<Persistence.Repositories.Models.CapacitySpecification, Domain.ModelAggregateRoot.Entities.CapacitySpecification>().ReverseMap();
        }
    }
}
