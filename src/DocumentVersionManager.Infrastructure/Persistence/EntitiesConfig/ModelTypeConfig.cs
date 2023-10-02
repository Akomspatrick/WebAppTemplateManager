using DocumentVersionManager.Domain.Constants;
using DocumentVersionManager.Infrastructure.Persistence.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentVersionManager.Infrastructure.Persistence.EntitiesConfig
{
    public class ModelTypeConfig : IEntityTypeConfiguration<ModelType>
    {
        public void Configure(EntityTypeBuilder<ModelType> entity)
        {
            entity.HasKey(e => e.ModelTypeName);
            entity.Property(e => e.ModelTypeName).IsRequired().HasMaxLength(FixedValues.ModelTypeNameMaxLength);

            entity.HasData(new ModelType() { ModelTypeName = "FIRSTMODELTYPE" },
                           new ModelType() { ModelTypeName = "SECONDMODELTYPE" },
                           new ModelType() { ModelTypeName = "THIRDMODELTYPE" });
        }
    }
}
