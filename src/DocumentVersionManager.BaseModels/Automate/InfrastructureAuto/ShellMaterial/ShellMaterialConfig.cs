using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.EntitiesConfig
{
    public class ShellMaterialConfig : IEntityTypeConfiguration<ShellMaterial>
    {
        public void Configure(EntityTypeBuilder<ShellMaterial> entity)
        {
            entity.HasKey(e => new { e.ShellMaterialName });
            entity.Property(e => e.ShellMaterialName).HasMaxLength(32); 
            entity.Property(e => e.ShellMaterialName).IsRequired(); 
        }
    }
}