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


    public class DocumentTypeConfig : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> entity)
        {
            entity.HasKey(e => e.TypeName);
            entity.Property(e => e.TypeName).IsRequired().HasMaxLength(FixedValues.DocumentTypeMaxLength);

            entity.HasData(DocumentType.Create("Cabling"),
                            DocumentType.Create("Chroming"),
                             DocumentType.Create("Sealing"),
                               DocumentType.Create("Gauging"),
                            DocumentType.Create("Wiring"));
        }
    }
}




