using DocumentVersionManager.Domain.Constants;
using DocumentVersionManager.Domain.ModelAggregateRoot.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Extensions;
using MySql.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

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


    public class ModelVersionConfig : IEntityTypeConfiguration<ModelVersion>
    {
        public void Configure(EntityTypeBuilder<ModelVersion> entity)
        {
            entity.HasKey(e =>new { e.ModelName,e.ModelVersionId });
            entity.Property(e => e.ModelName).HasMaxLength(FixedValues.ModelNameMaxLength);

            //entity.Property(e => e.ModelName).IsRequired().HasMaxLength(FixedValues.ModelNameMaxLength);//This has specified the foreign key
            entity.HasOne<Model>(e => e.Models).WithMany(ad => ad.ModelVersions).HasForeignKey(e => e.ModelName);
            entity.HasData(ModelVersion.Create(Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "FIRST_VERSION_FIRSTMODEL_NAME", 1, "SPECIAL DESIGN", "FIRSTMODELNAME", "OLADEJI", DateTime.UtcNow),
                  ModelVersion.Create(Guid.Parse("7808711f-544a-423d-8d99-f00c31e35be5"), "SECOND_VERSION_FIRSTMODELNAME", 2, "AUTO DESIGN TO COMBAT SPLIILING", "FIRSTMODELNAME", "OLADEJI", DateTime.UtcNow),
                  ModelVersion.Create(Guid.Parse("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), "FIRST_VERSION_SECONDMODELNAME", 1, "INITIAL DESIGN", "SECONDMODELNAME", "OLADEJI", DateTime.UtcNow));


        }
    }


    public class DocumentConfig : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> entity)
        {
            entity.HasKey(e => new {e.DocumentName, e.ModelName, e.ModelVersionId });
            entity.Property(e => e.ModelName).HasMaxLength(FixedValues.ModelNameMaxLength);

            //entity.Property(e => e.ModelName).IsRequired().HasMaxLength(FixedValues.ModelNameMaxLength);//This has specified the foreign key
            entity.HasOne<ModelVersion>(e => e.ModelVersion).WithMany(e => e.Documents).HasForeignKey(e => new { e.ModelName, e.ModelVersionId } );
            entity.HasData(Document.Create(Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "FIRSTMODELNAME ver1 DOc", 1, "FIRSTMODELNAME", "CONTENT PDF PATH", "CHANGE ORDER PATH", "SIMPLE DESCRITION OF DOCUMENT", DateTime.UtcNow),
                Document.Create(Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "FIRSTMODELNAME ver1 DOc A", 1, "FIRSTMODELNAME", "CONTENT PDF PATH", "CHANGE ORDER PATH", "SIMPLE DESCRITION OF DOCUMENT", DateTime.UtcNow),
                Document.Create(Guid.Parse("7808711f-544a-423d-8d99-f00c31e35be5"), "FIRSTMODELNAME ver1 DOc B", 1, "FIRSTMODELNAME", "CONTENT PDF PATH", "CHANGE ORDER PATH", "SIMPLE DESCRITION OF DOCUMENT", DateTime.UtcNow),
                Document.Create(Guid.Parse("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), "FIRSTMODELNAME ver2 DOc A", 2, "FIRSTMODELNAME", "CONTENT PDF PATH", "CHANGE ORDER PATH", "SIMPLE DESCRITION OF DOCUMENT", DateTime.UtcNow));




        }
    }




    public class DocumentTypeConfig : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> entity)
        {
            entity.HasKey(e => e.TypeName);
            entity.Property(e => e.TypeName).IsRequired().HasMaxLength(FixedValues.DocumentTypeMaxLength);
                     entity.HasData(DocumentType.Create(Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63"),"Cabling"),
                            DocumentType.Create(Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "Chroming"),
                             DocumentType.Create(Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "Sealing"),
                               DocumentType.Create(Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63"),"Gauging"),
                            DocumentType.Create(Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "Wiring"));
        }
    }


    public class CapacitySpecificationConfig : IEntityTypeConfiguration<CapacitySpecification>
    {
        public void Configure(EntityTypeBuilder<CapacitySpecification> entity)
        {
            entity.HasKey(e => new { e.Capacity, e.ModelName, e.ModelVersionId });
            entity.Property(e => e.Capacity).IsRequired();


            entity.HasOne<ShellMaterial>(e => e.ShellMaterial).WithMany(e => e.CapacitySpecifications)
                .HasForeignKey(e => new { e.ShellMaterialName });
            entity.HasOne<ModelVersion>(e => e.ModelVersion).WithMany(e=>e.CapacitySpecifications)
                .HasForeignKey(e => new { e.ModelName, e.ModelVersionId });
           
            entity.HasData(
                CapacitySpecification.Create(Guid.Parse("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"),  "FIRSTMODELNAME", 1,
                100,DateTime.UtcNow,"OLADEJI",1,1,1,1,1,1,1,1,"SHELLMATERIAL1",true,20,1,1,1,1,"CCNUMBER","CLASS","APPLICATION",1,1,1
                ,1,1,1,1,1,1,true,"NTEPCERTIFICATIONID",DateTime.UtcNow,"OIMLCERTIFICATIONID1",DateTime.UtcNow),

                      CapacitySpecification.Create(Guid.Parse("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), "FIRSTMODELNAME", 1,
                101, DateTime.UtcNow, "OLADEJI", 1, 1, 1, 1, 1, 1, 1, 1, "SHELLMATERIAL2", true, 20, 1, 1, 1, 1, "CCNUMBER", "CLASS", "APPLICATION", 1, 1, 1
                , 1, 1, 1, 1, 1, 1, true, "NTEPCERTIFICATIONID", DateTime.UtcNow, "OIMLCERTIFICATIONID2", DateTime.UtcNow),

                      CapacitySpecification.Create(Guid.Parse("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), "FIRSTMODELNAME", 1,
                102, DateTime.UtcNow, "OLADEJI", 1, 1, 1, 1, 1, 1, 1, 1, "SHELLMATERIAL2", true, 20, 1, 1, 1, 1, "CCNUMBER", "CLASS", "APPLICATION", 1, 1, 1
                , 1, 1, 1, 1, 1, 1, true, "NTEPCERTIFICATIONID", DateTime.UtcNow, "OIMLCERTIFICATIONID2", DateTime.UtcNow),

                      CapacitySpecification.Create(Guid.Parse("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), "FIRSTMODELNAME", 2,
                100, DateTime.UtcNow, "OLADEJI", 1, 1, 1, 1, 1, 1, 1, 1, "SHELLMATERIAL2", true, 20, 1, 1, 1, 1, "CCNUMBER", "CLASS", "APPLICATION", 1, 1, 1
                , 1, 1, 1, 1, 1, 1, true, "NTEPCERTIFICATIONID", DateTime.UtcNow, "OIMLCERTIFICATIONID2", DateTime.UtcNow),


                CapacitySpecification.Create(Guid.Parse("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"), "SECONDMODELNAME", 1,
                100, DateTime.UtcNow, "OLADEJI", 1, 1, 1, 1, 1, 1, 1, 1, "SHELLMATERIAL3", true, 20, 1, 1, 1, 1, "CCNUMBER", "CLASS", "APPLICATION", 1, 1, 1
                , 1, 1, 1, 1, 1, 1, true, "NTEPCERTIFICATIONID", DateTime.UtcNow, "OIMLCERTIFICATIONID3", DateTime.UtcNow)                  );
        }
    }





    public class DocumentDocumentTypeConfig : IEntityTypeConfiguration<DocumentDocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentDocumentType> entity)
        {
            entity.HasKey(e => new { e.DocumentName, e.ModelName, e.ModelVersionId, e.DocumentTypeName });
            entity.Property(e => e.ModelName).HasMaxLength(FixedValues.ModelNameMaxLength);
            entity.HasOne<DocumentType>(e => e.DocumentType).WithMany(e => e.DocumentDocumentTypes);
            entity.HasOne<Document>(e => e.Document).WithMany(e => e.DocumentDocumentTypes).HasForeignKey(e => new { e.DocumentName, e.ModelName, e.ModelVersionId });
            entity.HasData(
                       DocumentDocumentType.Create(Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "FIRSTMODELNAME ver1 DOc A", 1, "FIRSTMODELNAME", "Cabling"),
                       DocumentDocumentType.Create(Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "FIRSTMODELNAME ver1 DOc A", 1, "FIRSTMODELNAME", "Chroming"),
                       DocumentDocumentType.Create(Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "FIRSTMODELNAME ver1 DOc A", 1, "FIRSTMODELNAME", "Sealing"),
                       DocumentDocumentType.Create(Guid.Parse("7808711f-544a-423d-8d99-f00c31e35be5"), "FIRSTMODELNAME ver1 DOc B", 1, "FIRSTMODELNAME", "Cabling"),
                       DocumentDocumentType.Create(Guid.Parse("7808711f-544a-423d-8d99-f00c31e35be5"), "FIRSTMODELNAME ver1 DOc B", 1, "FIRSTMODELNAME", "Chroming"),
                       DocumentDocumentType.Create(Guid.Parse("7808711f-544a-423d-8d99-f00c31e35be5"), "FIRSTMODELNAME ver1 DOc B", 1, "FIRSTMODELNAME", "Sealing")

                );



        }
    }

    public class CapacityTestPointConfig : IEntityTypeConfiguration<CapacityTestPoint>
    {
        public void Configure(EntityTypeBuilder<CapacityTestPoint> entity)
        {
            /// below comments to be removed not needed anymore
            /// Add thito the migration query after creating the migration EVERYTIME YOU CREATE A NEW MIGRATION
            /// BEFORE UPDATE
            /// 
            /*
             * 
            migrationBuilder.Sql("ALTER TABLE `CapacityTestPoint` DROP COLUMN `TestId`");
            migrationBuilder.Sql("ALTER TABLE `CapacityTestPoint` ADD `TestId` int AUTO_INCREMENT UNIQUE;");
            migrationBuilder.Sql("ALTER TABLE `CapacityTestPoint` ADD  PRIMARY KEY(ModelVersionId, ModelName, TestId);");
           
             */
            /// THIS IS THE WORK AROUND TO CREATE IDENTITY FIELD FOR TESTID, MAY BE FIXED IN THE FUTURE

          
            entity.HasKey(e => new { e.TestId });
            entity.Property(e => e.TestId)
             .HasAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            entity.HasOne<CapacitySpecification>(e=>e.CapacitySpecification).WithMany(e=>e.CapacityTestPoints)
                .HasForeignKey(e=>new { e.Capacity, e.ModelName, e.ModelVersionId });

            entity.HasData( CapacityTestPoint.Create(Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "FIRSTMODELNAME",1, 100,1,1),
                 CapacityTestPoint.Create(Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "FIRSTMODELNAME",1,101,9,1),
                 CapacityTestPoint.Create(Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "FIRSTMODELNAME", 1, 102, 39, 1),
                 CapacityTestPoint.Create(Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "SECONDMODELNAME",1, 100,49,1));

  
        }
    }
    public class ShellMaterialConfig : IEntityTypeConfiguration<ShellMaterial>
    {
        public void Configure(EntityTypeBuilder<ShellMaterial> entity)
        {
            entity.HasKey(e => new { e.ShellMaterialName });
            entity.HasData(ShellMaterial.Create(Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "ShellMaterial1", 1),
                            ShellMaterial.Create(Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "ShellMaterial2", 2),
                             ShellMaterial.Create(Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "ShellMaterial3", 1),
                               ShellMaterial.Create(Guid.Parse("b27c2c19-522b-49d1-83bf-e80d4dde8c63"), "ShellMaterial4", 2));


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




