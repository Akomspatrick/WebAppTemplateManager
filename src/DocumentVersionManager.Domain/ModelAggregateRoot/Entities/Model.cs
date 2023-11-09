 using DocumentVersionManager.DomainBase.Base;

namespace DocumentVersionManager.Domain.ModelAggregateRoot.Entities
{
    public partial class Model : BaseEntity
    {
        //if I am not using domain driven design then i can specify the detail model here eg 
        // public ModelType ModelType { get; set; }
       // public string ModelId { get; init; } = string.Empty;
       // public Guid ModelId { get; private set; }

        public string ModelName { get; init; } = string.Empty;

       // [ForeignKey("ModelTypesName")]
        public string ModelTypesName { get; private set; } = string.Empty;
        public ModelTypes? ModelTypes { get; set; }


        public ICollection<ModelVersion> ModelVersions;




    }

}


