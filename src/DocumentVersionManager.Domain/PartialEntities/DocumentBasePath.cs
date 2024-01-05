using DocumentVersionManager.DomainBase;
namespace DocumentVersionManager.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class DocumentBasePath : BaseEntity
    {
        private DocumentBasePath() { }
        public string DocumentBasePathId { get; init; } = string.Empty;
        public string Path { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public Guid GuidId { get; init; }

        public static DocumentBasePath Create(string documentBasePathId, string path, string description, Guid guidId)
        => new()
        {
            DocumentBasePathId = documentBasePathId,
            Path = path,
            Description = description,
            GuidId = guidId,
        };
    }
}