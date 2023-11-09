namespace DocumentVersionManager.BaseModels.Entities
{

    public class ModelTypes : BaseEntity
    {
       // public Guid ModelTypeId { get; private set; } 
        public string ModelTypesName { get; private set; } = string.Empty;

        public ICollection<Model> Models { get; set; } //This is for navigation property.// to be removed if i want  to strictly follow domain driven design
      



    }
}
