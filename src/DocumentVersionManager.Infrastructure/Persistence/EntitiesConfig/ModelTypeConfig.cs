using DocumentVersionManager.Domain.Constants;
using DocumentVersionManager.Domain.ModelAggregateRoot.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentVersionManager.Infrastructure.Persistence.EntitiesConfig
{
    public class ModelTypeConfig : IEntityTypeConfiguration<ModelTypes>
    {
        public void Configure(EntityTypeBuilder<ModelTypes> entity)
        {
            entity.HasKey(e => e.ModelTypeName);
            entity.Property(e => e.ModelTypeName).IsRequired().HasMaxLength(FixedValues.ModelTypeNameMaxLength);
            entity.HasKey(e => e.ModelTypeId);
            entity.Property(e => e.ModelTypeId).IsRequired().HasMaxLength(FixedValues.ModelTypeIdMaxLength);
            entity.HasData( ModelTypes.Create("FIRSTMODELTYPEID","FIRSTMODELTYPE" ),
                            ModelTypes.Create("SECONDMODELTYPEID" ,"SECONDMODELTYPE" ),
                            ModelTypes.Create("THIRDMODELTYPEID","THIRDMODELTYPE" ));
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

    public class HigherModelConfig : IEntityTypeConfiguration<HigherModel>
    {
        public void Configure(EntityTypeBuilder<HigherModel> entity)
        {
            entity.HasKey(e => e.HigherModelName);
            entity.Property(e => e.HigherModelName).IsRequired().HasMaxLength(FixedValues.DocumentTypeMaxLength);

            entity.HasData(HigherModel.Create("HigherModel1", "HigherModel1", "HigherModel1",1),
                            HigherModel.Create("HigherModel2", "HigherModel12", "HigherModel12", 12),
                             HigherModel.Create("HigherModel3", "HigherModel13", "HigherModel1", 13),
                               HigherModel.Create("HigherModel4", "HigherModel14", "HigherModel14", 14),
                            HigherModel.Create("HigherModel5", "HigherModel5", "HigherModel5", 5));
        }
    }


    
}




