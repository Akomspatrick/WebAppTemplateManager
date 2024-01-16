using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.EntitiesConfig
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(e => new { e.ProductId });
            entity.Property(e => e.ModelName).HasMaxLength(32);
            entity.Property(e => e.SubStage).HasMaxLength(32);
            entity.Property(e => e.SalesOrderId).HasMaxLength(32);
            entity.Property(e => e.DefaultTestingMode).HasMaxLength(32);
            entity.Property(e => e.ModelTypeGroupName).HasMaxLength(32);
            entity.Property(e => e.UsedTestingMode).HasMaxLength(32);
            entity.Property(e => e.ThermexPurcharseOrderNo).HasMaxLength(32);
            entity.Property(e => e.MachiningPurcharseOrderNo).HasMaxLength(32);
            entity.Property(e => e.SteelPurcharseOrderNo).HasMaxLength(32);
            entity.HasOne<ModelVersion>(e => e.ModelVersion).WithMany(ad => ad.Products).HasForeignKey(e => new { e.ModelName, e.ModelVersionId });
        }
    }
}