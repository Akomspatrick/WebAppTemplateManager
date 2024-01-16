using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.EntitiesConfig
{
    public class TestPointConfig : IEntityTypeConfiguration<TestPoint>
    {
        public void Configure(EntityTypeBuilder<TestPoint> entity)
        {
            entity.HasKey(e => new { e.ModelName,e.ModelVersionId,e.CapacityTestPoint });
            entity.Property(e => e.ModelName).HasMaxLength(32); 
            entity.HasOne<ModelVersion>(e => e.ModelVersion).WithMany(ad => ad.TestPoints).HasForeignKey(e => new {e.ModelName,e.ModelVersionId});
        }
    }
}