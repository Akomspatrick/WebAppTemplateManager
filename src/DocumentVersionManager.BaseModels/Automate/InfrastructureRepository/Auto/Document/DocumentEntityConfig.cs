using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.EntitiesConfig
{
    public class DocumentConfig : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> entity)
        {
            entity.HasKey(e => new { e.DocumentName,e.ModelName });
            entity.Property(e => e.ModelName).HasMaxLength(30); entity.Property(e => e.ModelName).HasMinLength(2);
            entity.Property(e => e.ModelName).IsRequired()); 
            entity.HasIndex(e => new { e.DocumentName,e.ModelName }).IsUnique();
        }
    }
}