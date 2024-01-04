using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class ModelType : BaseEntity
    {
        private ModelType() { }
        public string ModelTypeName { get; init; } = string.Empty;
        public string ModelTypeGroupName { get; init; } = string.Empty;
        public ModelTypeGroup ModelTypeGroup { get; init; }
        private List<Model> _Models { get; set; } = new List<Model>();
        public IReadOnlyCollection<Model> Models => _Models;
        public Guid GuidId { get; init; }


    }
}