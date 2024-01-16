using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.EntitiesConfig
{
    public class DocumentTypeConfig : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> entity)
        {
            entity.HasKey(e => new { e.DocumentTypeName });
            entity.Property(e => e.DocumentTypeName).HasMaxLength(32); 
            entity.Property(e => e.DocumentTypeName).IsRequired(); 
        }
    }
}