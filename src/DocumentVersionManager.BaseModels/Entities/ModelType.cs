namespace DocumentVersionManager.BaseModels.Entities
{

    public class ModelType : BaseEntity
    {
        // public Guid ModelTypeId { get; private set; } 
        public string ModelTypeName { get; private set; } = string.Empty;
        public string ModelTypeGroupName { get; private set; } = string.Empty;
        public ModelTypeGroup ModelTypeGroup { get; init; }
        public ICollection<Model> Models { get; set; } //This is for navigation property.// to be removed if i want  to strictly follow domain driven design

    }
}
