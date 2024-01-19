using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DocumentVersionManager.Domain.Entities;
namespace DocumentVersionManager.Infrastructure.Persistence.EntitiesConfig
{
    public class ModelVersionConfig : IEntityTypeConfiguration<ModelVersion>
    {
        public void Configure(EntityTypeBuilder<ModelVersion> entity)
        {
            entity.HasKey(e => new { e.ModelVersionId,e.ModelName });
            entity.Property(e => e.VersionDescription).HasMaxLength(32); 
            entity.Property(e => e.ModelVersionName).HasMaxLength(32); 
            entity.Property(e => e.ModelName).HasMaxLength(32); 
            entity.Property(e => e.DefaultTestingMode).HasMaxLength(32); 
            entity.Property(e => e.UserName).HasMaxLength(32); 
            entity.Property(e => e.ShellMaterialName).HasMaxLength(32); 
            entity.Property(e => e.CCNumber).HasMaxLength(32); 
            entity.Property(e => e.AccuracyClass).HasMaxLength(32); 
            entity.Property(e => e.Application).HasMaxLength(32); 
            entity.Property(e => e.NTEPCertificationId).HasMaxLength(32); 
            entity.Property(e => e.OIMLCertificationId).HasMaxLength(32); 
        }
    }
}