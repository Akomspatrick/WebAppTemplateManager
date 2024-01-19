using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.EntitiesConfig
{
    public class ModelTypeGroupConfig : IEntityTypeConfiguration<ModelTypeGroup>
    {
        public void Configure(EntityTypeBuilder<ModelTypeGroup> entity)
        {
            entity.HasKey(e => new { e.ModelTypeGroupName });
            entity.Property(e => e.ModelTypeGroupName).HasMaxLength(32); 
            entity.Property(e => e.TestingMode).HasMaxLength(32); 
            entity.Property(e => e.Description).HasMaxLength(64); 
            entity.Property(e => e.ModelTypeGroupName).IsRequired(); 
        }
    }
}