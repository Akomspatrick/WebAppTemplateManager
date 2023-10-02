using DocumentVersionManager.Domain.Constants;
using DocumentVersionManager.Domain.ModelAggregateRoot.Entities;
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

            entity.HasData( ModelType.Create("FIRSTMODELTYPE" ),
                            ModelType.Create("SECONDMODELTYPE" ),
                            ModelType.Create("THIRDMODELTYPE" ));
        }
    }
}
