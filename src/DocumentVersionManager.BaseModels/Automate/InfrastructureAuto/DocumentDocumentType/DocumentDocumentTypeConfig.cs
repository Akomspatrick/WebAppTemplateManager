using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.EntitiesConfig
{
    public class DocumentDocumentTypeConfig : IEntityTypeConfiguration<DocumentDocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentDocumentType> entity)
        {
            entity.HasKey(e => new { e.DocumentName,e.ModelName,e.ModelVersionId,e.DocumentTypeName });
            entity.Property(e => e.DocumentName).HasMaxLength(32); 
            entity.Property(e => e.ModelName).HasMaxLength(32); 
            entity.Property(e => e.DocumentTypeName).HasMaxLength(32); 
            entity.Property(e => e.ModelName).IsRequired(); 
        }
    }
}