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
            entity.HasKey(e => e.ModelTypesName);
            entity.Property(e => e.ModelTypesName).IsRequired().HasMaxLength(FixedValues.modelTypesNameMaxLength);
          
           //
           
             entity.HasData(ModelTypes.Create(Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "FIRSTMODELTYPE"),
                            ModelTypes.Create(Guid.Parse("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), "SECONDMODELTYPE"),
                            ModelTypes.Create(Guid.Parse("3c69923e-a68e-4348-b06c-7007f527355d"), "THIRDMODELTYPE"));
        }
    }
    public class ModelConfig : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> entity)
        {
            entity.HasKey(e => e.ModelName);
            entity.Property(e => e.ModelName).HasMaxLength(FixedValues.ModelNameMaxLength);

            entity.Property(e => e.ModelName).IsRequired().HasMaxLength(FixedValues.ModelNameMaxLength);//This has specified the foreign key
            entity.HasOne<ModelTypes>(e => e.ModelTypes).WithMany(ad => ad.Models).HasForeignKey(e => e.ModelTypesName);
            entity.HasData(Model.Create(Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63"),"FIRSTMODELNAME", "FIRSTMODELTYPE"),
            //                //Model.Create(Guid.Parse("FIRSTMODELID2", "FIRSTMODELNAME2", Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
            //                // Model.Create(Guid.Parse("FIRSTMODELID3", "FIRSTMODELNAME2", Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63")),
                            Model.Create(Guid.Parse("7808711f-544a-423d-8d99-f00c31e35be5"), "SECONDMODELNAME", "FIRSTMODELTYPE"),
                           Model.Create(Guid.Parse("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), "THIRDMODELNAME", "SECONDMODELTYPE"));
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

            entity.HasData(HigherModel.Create("HigherModel1", "HigherModel1", "HigherModel1", 1),
                            HigherModel.Create("HigherModel2", "HigherModel12", "HigherModel12", 12),
                             HigherModel.Create("HigherModel3", "HigherModel13", "HigherModel1", 13),
                               HigherModel.Create("HigherModel4", "HigherModel14", "HigherModel14", 14),
                            HigherModel.Create("HigherModel5", "HigherModel5", "HigherModel5", 5));
        }
    }




}




