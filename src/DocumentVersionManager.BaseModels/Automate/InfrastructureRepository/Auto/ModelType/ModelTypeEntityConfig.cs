using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.EntitiesConfig
{
    public class ModelTypeConfig : IEntityTypeConfiguration<ModelType>
    {
        public void Configure(EntityTypeBuilder<ModelType> entity)
        {
            entity.HasKey(e => new { e.ModelTypeName,e.ModelTypeGroupName });
            entity.Property(e => e.ModelTypeGroupName).HasMaxLength(30); entity.Property(e => e.ModelTypeGroupName).HasMinLength(2);
            entity.Property(e => e.ModelTypeGroupName).IsRequired()); 
            entity.HasIndex(e => new { e.ModelTypeName,e.ModelTypeGroupName }).IsUnique();
        }
    }
}