using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Infrastructure.Maps
{
    public static class Mapper
    {
        public static Persistence.Repositories.Models.ModelType ToModel(this Domain.ModelAggregateRoot.Entities.ModelType entity)
           =>
           new Persistence.Repositories.Models.ModelType { ModelTypeName= entity.ModelTypeName};
        

        public static Domain.ModelAggregateRoot.Entities.ModelType ToEntity(this DocumentVersionManager.Infrastructure.Persistence.Repositories.Models.ModelType model)
        
            => Domain.ModelAggregateRoot.Entities.ModelType.Create(model.ModelTypeName);
        


        //  CreateMap<Persistence.Repositories.Models.ModelType, Domain.ModelAggregateRoot.Entities.ModelType>();//.ReverseMap();
    }
}
