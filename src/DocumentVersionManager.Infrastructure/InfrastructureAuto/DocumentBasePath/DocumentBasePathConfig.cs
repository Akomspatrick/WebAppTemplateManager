using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.EntitiesConfig
{
    public class DocumentBasePathConfig : IEntityTypeConfiguration<DocumentBasePath>
    {
        public void Configure(EntityTypeBuilder<DocumentBasePath> entity)
        {
            entity.HasKey(e => new { e.DocumentBasePathId });
            entity.Property(e => e.DocumentBasePathId).HasMaxLength(128); 
            entity.Property(e => e.Path).HasMaxLength(128); 
            entity.Property(e => e.Description).HasMaxLength(128); 
        }
    }
}