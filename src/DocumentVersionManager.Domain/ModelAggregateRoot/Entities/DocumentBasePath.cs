using DocumentVersionManager.DomainBase.Base;
namespace DocumentVersionManager.Domain.Entities
{
    public partial class DocumentBasePath : BaseEntity
    {
        private DocumentBasePath() { }

        public static DocumentBasePath Create(string documentBasePathId, string path, string description, Guid guidId)
        {
            return new DocumentBasePath()
            {
                DocumentBasePathId = documentBasePathId,
                Path = path,
                Description = description,
                GuidId = guidId,
            };
        }
    }
}