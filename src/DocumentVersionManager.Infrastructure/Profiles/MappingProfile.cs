using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Infrastructure.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
                CreateMap<Domain.ModelAggregateRoot.Entities.ModelTypes, Domain.ModelAggregateRoot.Entities.ModelTypes> ().ReverseMap();
                CreateMap<Domain.ModelAggregateRoot.Entities.Model, Domain.ModelAggregateRoot.Entities.Model>().ReverseMap();
                CreateMap<Domain.ModelAggregateRoot.Entities.CapacityDocument, Domain.ModelAggregateRoot.Entities.CapacityDocument>().ReverseMap();
                CreateMap<Domain.ModelAggregateRoot.Entities.CapacitySpecification, Domain.ModelAggregateRoot.Entities.CapacitySpecification>().ReverseMap();
        }
    }
}
