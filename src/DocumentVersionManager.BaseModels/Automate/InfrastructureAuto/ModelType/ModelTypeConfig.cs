using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.EntitiesConfig
{
    public class ModelTypeConfig : IEntityTypeConfiguration<ModelType>
    {
        public void Configure(EntityTypeBuilder<ModelType> entity)
        {
            entity.HasKey(e => new { e.ModelTypeName });
            entity.Property(e => e.ModelTypeName).HasMaxLength(32); 
            entity.Property(e => e.ModelTypeGroupName).HasMaxLength(32); 
            entity.Property(e => e.ModelTypeGroupName).IsRequired(); 
            entity.HasOne<ModelTypeGroup>(e => e.ModelTypeGroup).WithMany(ad => ad.ModelTypes).HasForeignKey(e => new {e.ModelTypeGroupName});
        }
    }
}