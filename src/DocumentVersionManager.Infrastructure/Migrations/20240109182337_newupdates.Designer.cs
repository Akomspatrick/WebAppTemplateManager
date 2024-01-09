﻿// <auto-generated />
using System;
using DocumentVersionManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DocumentVersionManager.Infrastructure.Migrations
{
    [DbContext(typeof(DocumentVersionManagerContext))]
    [Migration("20240109182337_newupdates")]
    partial class newupdates
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.Document", b =>
                {
                    b.Property<string>("DocumentName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ModelName")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<int>("ModelVersionId")
                        .HasColumnType("int");

                    b.Property<string>("ChangeOrderPDFPath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContentPDFPath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DocumentBasePathId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DocumentDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("DocumentName", "ModelName", "ModelVersionId");

                    b.HasIndex("ModelName", "ModelVersionId");

                    b.ToTable("Documents");

                    b.HasData(
                        new
                        {
                            DocumentName = "FIRSTMODELNAME ver1 DOc",
                            ModelName = "FIRSTMODELNAME",
                            ModelVersionId = 1,
                            ChangeOrderPDFPath = "CHANGE ORDER PATH",
                            ContentPDFPath = "CONTENT PDF PATH",
                            DocumentBasePathId = "DOCPATHID",
                            DocumentDescription = "SIMPLE DESCRITION OF DOCUMENT",
                            GuidId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"),
                            Timestamp = new DateTime(2024, 1, 9, 18, 23, 36, 548, DateTimeKind.Utc).AddTicks(8117)
                        },
                        new
                        {
                            DocumentName = "FIRSTMODELNAME ver1 DOc A",
                            ModelName = "FIRSTMODELNAME",
                            ModelVersionId = 1,
                            ChangeOrderPDFPath = "CHANGE ORDER PATH",
                            ContentPDFPath = "CONTENT PDF PATH",
                            DocumentBasePathId = "DOCPATHID",
                            DocumentDescription = "SIMPLE DESCRITION OF DOCUMENT",
                            GuidId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"),
                            Timestamp = new DateTime(2024, 1, 9, 18, 23, 36, 548, DateTimeKind.Utc).AddTicks(8191)
                        },
                        new
                        {
                            DocumentName = "FIRSTMODELNAME ver1 DOc B",
                            ModelName = "FIRSTMODELNAME",
                            ModelVersionId = 1,
                            ChangeOrderPDFPath = "CHANGE ORDER PATH",
                            ContentPDFPath = "CONTENT PDF PATH",
                            DocumentBasePathId = "DOCPATHID",
                            DocumentDescription = "SIMPLE DESCRITION OF DOCUMENT",
                            GuidId = new Guid("7808711f-544a-423d-8d99-f00c31e35be5"),
                            Timestamp = new DateTime(2024, 1, 9, 18, 23, 36, 548, DateTimeKind.Utc).AddTicks(8194)
                        },
                        new
                        {
                            DocumentName = "FIRSTMODELNAME ver2 DOc A",
                            ModelName = "FIRSTMODELNAME",
                            ModelVersionId = 2,
                            ChangeOrderPDFPath = "CHANGE ORDER PATH",
                            ContentPDFPath = "CONTENT PDF PATH",
                            DocumentBasePathId = "DOCPATHID",
                            DocumentDescription = "SIMPLE DESCRITION OF DOCUMENT",
                            GuidId = new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"),
                            Timestamp = new DateTime(2024, 1, 9, 18, 23, 36, 548, DateTimeKind.Utc).AddTicks(8196)
                        });
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.DocumentBasePath", b =>
                {
                    b.Property<string>("DocumentBasePathId")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("DocumentBasePathId");

                    b.ToTable("DocumentBasePaths");
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.DocumentDocumentType", b =>
                {
                    b.Property<string>("DocumentName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ModelName")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<int>("ModelVersionId")
                        .HasColumnType("int");

                    b.Property<string>("DocumentTypeName")
                        .HasColumnType("varchar(128)");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("char(36)");

                    b.HasKey("DocumentName", "ModelName", "ModelVersionId", "DocumentTypeName");

                    b.HasIndex("DocumentTypeName");

                    b.ToTable("DocumentDocumentTypes");

                    b.HasData(
                        new
                        {
                            DocumentName = "FIRSTMODELNAME ver1 DOc A",
                            ModelName = "FIRSTMODELNAME",
                            ModelVersionId = 1,
                            DocumentTypeName = "Cabling",
                            GuidId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63")
                        },
                        new
                        {
                            DocumentName = "FIRSTMODELNAME ver1 DOc A",
                            ModelName = "FIRSTMODELNAME",
                            ModelVersionId = 1,
                            DocumentTypeName = "Chroming",
                            GuidId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63")
                        },
                        new
                        {
                            DocumentName = "FIRSTMODELNAME ver1 DOc A",
                            ModelName = "FIRSTMODELNAME",
                            ModelVersionId = 1,
                            DocumentTypeName = "Sealing",
                            GuidId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63")
                        },
                        new
                        {
                            DocumentName = "FIRSTMODELNAME ver1 DOc B",
                            ModelName = "FIRSTMODELNAME",
                            ModelVersionId = 1,
                            DocumentTypeName = "Cabling",
                            GuidId = new Guid("7808711f-544a-423d-8d99-f00c31e35be5")
                        },
                        new
                        {
                            DocumentName = "FIRSTMODELNAME ver1 DOc B",
                            ModelName = "FIRSTMODELNAME",
                            ModelVersionId = 1,
                            DocumentTypeName = "Chroming",
                            GuidId = new Guid("7808711f-544a-423d-8d99-f00c31e35be5")
                        },
                        new
                        {
                            DocumentName = "FIRSTMODELNAME ver1 DOc B",
                            ModelName = "FIRSTMODELNAME",
                            ModelVersionId = 1,
                            DocumentTypeName = "Sealing",
                            GuidId = new Guid("7808711f-544a-423d-8d99-f00c31e35be5")
                        });
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.DocumentType", b =>
                {
                    b.Property<string>("DocumentTypeName")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("char(36)");

                    b.HasKey("DocumentTypeName");

                    b.ToTable("DocumentTypes");

                    b.HasData(
                        new
                        {
                            DocumentTypeName = "Cabling",
                            GuidId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63")
                        },
                        new
                        {
                            DocumentTypeName = "Chroming",
                            GuidId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63")
                        },
                        new
                        {
                            DocumentTypeName = "Sealing",
                            GuidId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63")
                        },
                        new
                        {
                            DocumentTypeName = "Gauging",
                            GuidId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63")
                        },
                        new
                        {
                            DocumentTypeName = "Wiring",
                            GuidId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63")
                        });
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.Model", b =>
                {
                    b.Property<string>("ModelName")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ModelTypeName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("ModelName");

                    b.HasIndex("ModelTypeName");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            ModelName = "FIRSTMODELNAME",
                            GuidId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"),
                            ModelTypeName = "FIRSTMODELTYPE"
                        },
                        new
                        {
                            ModelName = "SECONDMODELNAME",
                            GuidId = new Guid("7808711f-544a-423d-8d99-f00c31e35be5"),
                            ModelTypeName = "FIRSTMODELTYPE"
                        },
                        new
                        {
                            ModelName = "THIRDMODELNAME",
                            GuidId = new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"),
                            ModelTypeName = "SECONDMODELTYPE"
                        });
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.ModelType", b =>
                {
                    b.Property<string>("ModelTypeName")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ModelTypeGroupName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("ModelTypeName");

                    b.HasIndex("ModelTypeGroupName");

                    b.ToTable("ModelTypes");

                    b.HasData(
                        new
                        {
                            ModelTypeName = "FIRSTMODELTYPE",
                            GuidId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"),
                            ModelTypeGroupName = "LOADCELLS_GROUP"
                        },
                        new
                        {
                            ModelTypeName = "SECONDMODELTYPE",
                            GuidId = new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"),
                            ModelTypeGroupName = "TESTLINKS_GROUP"
                        },
                        new
                        {
                            ModelTypeName = "THIRDMODELTYPE",
                            GuidId = new Guid("3c69923e-a68e-4348-b06c-7007f527355d"),
                            ModelTypeGroupName = "SCALES/PAD"
                        });
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.ModelTypeGroup", b =>
                {
                    b.Property<string>("ModelTypeGroupName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("char(36)");

                    b.Property<string>("TestingMode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ModelTypeGroupName");

                    b.ToTable("ModelTypeGroups");

                    b.HasData(
                        new
                        {
                            ModelTypeGroupName = "LOADCELLS_GROUP",
                            Description = "FLOW TYPES FOR LOADCELL",
                            GuidId = new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"),
                            TestingMode = "AUTOMATIC"
                        },
                        new
                        {
                            ModelTypeGroupName = "TESTLINKS_GROUP",
                            Description = "FLOW TYPES FOR TESTLINKS",
                            GuidId = new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"),
                            TestingMode = "MANUAL"
                        },
                        new
                        {
                            ModelTypeGroupName = "SCALES/PAD",
                            Description = "FLOW TYPES FOR SCALES/PAD",
                            GuidId = new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"),
                            TestingMode = "MANUAL"
                        });
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.ModelVersion", b =>
                {
                    b.Property<string>("ModelName")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<int>("ModelVersionId")
                        .HasColumnType("int");

                    b.Property<string>("AccuracyClass")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Alloy")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Application")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CCNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("DefaultCableLength")
                        .HasColumnType("int");

                    b.Property<string>("DefaultTestingMode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("char(36)");

                    b.Property<int>("MinimumDeadLoad")
                        .HasColumnType("int");

                    b.Property<string>("ModelVersionName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NTEPCertificationId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("NTEPCertificationTimestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("NominalOutput")
                        .HasColumnType("double");

                    b.Property<decimal>("NominalOutputPercentage")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("NonlinearityPercentage")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("NumberOfGauges")
                        .HasColumnType("int");

                    b.Property<string>("OIMLCertificationId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("OIMLCertificationTimestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Resistance")
                        .HasColumnType("int");

                    b.Property<int>("SafeLoad")
                        .HasColumnType("int");

                    b.Property<string>("ShellMaterialName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("TemperingHardnessHigh")
                        .HasColumnType("int");

                    b.Property<int>("TemperingHardnessLow")
                        .HasColumnType("int");

                    b.Property<bool>("TestPointDirection")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UltimateLoad")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("VersionDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("nMax")
                        .HasColumnType("int");

                    b.Property<double>("vMin")
                        .HasColumnType("double");

                    b.HasKey("ModelName", "ModelVersionId");

                    b.HasIndex("ShellMaterialName");

                    b.ToTable("ModelVersions");

                    b.HasData(
                        new
                        {
                            ModelName = "FIRSTMODELNAME",
                            ModelVersionId = 1,
                            AccuracyClass = "CLASS",
                            Alloy = true,
                            Application = "APPLICATION",
                            CCNumber = "CCNUMBER",
                            Capacity = 100,
                            DefaultCableLength = 20,
                            DefaultTestingMode = "AUTOMATIC",
                            GuidId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"),
                            MinimumDeadLoad = 1,
                            ModelVersionName = "FIRST_VERSION_FIRSTMODEL_NAME",
                            NTEPCertificationId = "NTEPCERTIFICATIONID",
                            NTEPCertificationTimestamp = new DateTime(2024, 1, 9, 18, 23, 36, 555, DateTimeKind.Utc).AddTicks(4706),
                            NominalOutput = 1.0,
                            NominalOutputPercentage = 1m,
                            NonlinearityPercentage = 1m,
                            NumberOfGauges = 1,
                            OIMLCertificationId = "OIMLCERTIFICATIONID1",
                            OIMLCertificationTimestamp = new DateTime(2024, 1, 9, 18, 23, 36, 555, DateTimeKind.Utc).AddTicks(4707),
                            Resistance = 1,
                            SafeLoad = 1,
                            ShellMaterialName = "SHELLMATERIAL1",
                            TemperingHardnessHigh = 1,
                            TemperingHardnessLow = 1,
                            TestPointDirection = true,
                            Timestamp = new DateTime(2024, 1, 9, 18, 23, 36, 555, DateTimeKind.Utc).AddTicks(4705),
                            UltimateLoad = 1,
                            UserName = "OLADEJI",
                            VersionDescription = "SPECIAL DESIGN",
                            nMax = 1,
                            vMin = 1.0
                        },
                        new
                        {
                            ModelName = "FIRSTMODELNAME",
                            ModelVersionId = 2,
                            AccuracyClass = "CLASS",
                            Alloy = true,
                            Application = "APPLICATION",
                            CCNumber = "CCNUMBER",
                            Capacity = 100,
                            DefaultCableLength = 20,
                            DefaultTestingMode = "MANUAL",
                            GuidId = new Guid("7808711f-544a-423d-8d99-f00c31e35be5"),
                            MinimumDeadLoad = 2,
                            ModelVersionName = "SECOND_VERSION_FIRSTMODELNAME",
                            NTEPCertificationId = "NTEPCERTIFICATIONID",
                            NTEPCertificationTimestamp = new DateTime(2024, 1, 9, 18, 23, 36, 555, DateTimeKind.Utc).AddTicks(4735),
                            NominalOutput = 2.0,
                            NominalOutputPercentage = 2m,
                            NonlinearityPercentage = 2m,
                            NumberOfGauges = 2,
                            OIMLCertificationId = "OIMLCERTIFICATIONID1",
                            OIMLCertificationTimestamp = new DateTime(2024, 1, 9, 18, 23, 36, 555, DateTimeKind.Utc).AddTicks(4735),
                            Resistance = 2,
                            SafeLoad = 2,
                            ShellMaterialName = "SHELLMATERIAL1",
                            TemperingHardnessHigh = 2,
                            TemperingHardnessLow = 2,
                            TestPointDirection = true,
                            Timestamp = new DateTime(2024, 1, 9, 18, 23, 36, 555, DateTimeKind.Utc).AddTicks(4732),
                            UltimateLoad = 2,
                            UserName = "OLADEJI",
                            VersionDescription = "AUTO DESIGN TO COMBAT SPLIILING",
                            nMax = 2,
                            vMin = 2.0
                        },
                        new
                        {
                            ModelName = "SECONDMODELNAME",
                            ModelVersionId = 1,
                            AccuracyClass = "CLASS",
                            Alloy = true,
                            Application = "APPLICATION",
                            CCNumber = "CCNUMBER",
                            Capacity = 100,
                            DefaultCableLength = 20,
                            DefaultTestingMode = "GETVALUESFROMTESTINGFLOWTYPES",
                            GuidId = new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"),
                            MinimumDeadLoad = 1,
                            ModelVersionName = "FIRST_VERSION_SECONDMODELNAME",
                            NTEPCertificationId = "NTEPCERTIFICATIONID",
                            NTEPCertificationTimestamp = new DateTime(2024, 1, 9, 18, 23, 36, 555, DateTimeKind.Utc).AddTicks(4740),
                            NominalOutput = 1.0,
                            NominalOutputPercentage = 1m,
                            NonlinearityPercentage = 1m,
                            NumberOfGauges = 1,
                            OIMLCertificationId = "OIMLCERTIFICATIONID1",
                            OIMLCertificationTimestamp = new DateTime(2024, 1, 9, 18, 23, 36, 555, DateTimeKind.Utc).AddTicks(4741),
                            Resistance = 1,
                            SafeLoad = 1,
                            ShellMaterialName = "SHELLMATERIAL1",
                            TemperingHardnessHigh = 1,
                            TemperingHardnessLow = 1,
                            TestPointDirection = true,
                            Timestamp = new DateTime(2024, 1, 9, 18, 23, 36, 555, DateTimeKind.Utc).AddTicks(4740),
                            UltimateLoad = 1,
                            UserName = "OLADEJI",
                            VersionDescription = "INITIAL DESIGN",
                            nMax = 1,
                            vMin = 1.0
                        });
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BatcNo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CableLength")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("DefaultTestingMode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("char(36)");

                    b.Property<int>("InspectionResult")
                        .HasColumnType("int");

                    b.Property<string>("MachiningPurcharseOrderNo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ModelTypeGroupName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ModelVersionId")
                        .HasColumnType("int");

                    b.Property<string>("SalesOrderId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Stage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SteelPurcharseOrderNo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SubStage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ThermexPurcharseOrderNo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UsedCalibrationMode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ProductId");

                    b.HasIndex("ModelName", "ModelVersionId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.ShellMaterial", b =>
                {
                    b.Property<string>("ShellMaterialName")
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Alloy")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("char(36)");

                    b.HasKey("ShellMaterialName");

                    b.ToTable("ShellMaterials");

                    b.HasData(
                        new
                        {
                            ShellMaterialName = "ShellMaterial1",
                            Alloy = true,
                            GuidId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63")
                        },
                        new
                        {
                            ShellMaterialName = "ShellMaterial2",
                            Alloy = true,
                            GuidId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63")
                        },
                        new
                        {
                            ShellMaterialName = "ShellMaterial3",
                            Alloy = true,
                            GuidId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63")
                        },
                        new
                        {
                            ShellMaterialName = "ShellMaterial4",
                            Alloy = true,
                            GuidId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63")
                        });
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.TestPoint", b =>
                {
                    b.Property<string>("ModelName")
                        .HasColumnType("varchar(128)");

                    b.Property<int>("ModelVersionId")
                        .HasColumnType("int");

                    b.Property<int>("CapacityTestPoint")
                        .HasColumnType("int");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("char(36)");

                    b.HasKey("ModelName", "ModelVersionId", "CapacityTestPoint");

                    b.ToTable("TestPoints");

                    b.HasData(
                        new
                        {
                            ModelName = "FIRSTMODELNAME",
                            ModelVersionId = 1,
                            CapacityTestPoint = 10000,
                            GuidId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63")
                        },
                        new
                        {
                            ModelName = "FIRSTMODELNAME",
                            ModelVersionId = 1,
                            CapacityTestPoint = 2000,
                            GuidId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63")
                        },
                        new
                        {
                            ModelName = "FIRSTMODELNAME",
                            ModelVersionId = 1,
                            CapacityTestPoint = 3000,
                            GuidId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63")
                        },
                        new
                        {
                            ModelName = "FIRSTMODELNAME",
                            ModelVersionId = 1,
                            CapacityTestPoint = 4000,
                            GuidId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63")
                        },
                        new
                        {
                            ModelName = "SECONDMODELNAME",
                            ModelVersionId = 1,
                            CapacityTestPoint = 49,
                            GuidId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63")
                        });
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.Document", b =>
                {
                    b.HasOne("DocumentVersionManager.Domain.Entities.ModelVersion", "ModelVersion")
                        .WithMany("Documents")
                        .HasForeignKey("ModelName", "ModelVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModelVersion");
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.DocumentDocumentType", b =>
                {
                    b.HasOne("DocumentVersionManager.Domain.Entities.DocumentType", "DocumentType")
                        .WithMany("DocumentDocumentTypes")
                        .HasForeignKey("DocumentTypeName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DocumentVersionManager.Domain.Entities.Document", "Document")
                        .WithMany("DocumentDocumentTypes")
                        .HasForeignKey("DocumentName", "ModelName", "ModelVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("DocumentType");
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.Model", b =>
                {
                    b.HasOne("DocumentVersionManager.Domain.Entities.ModelType", "ModelTypes")
                        .WithMany("Models")
                        .HasForeignKey("ModelTypeName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModelTypes");
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.ModelType", b =>
                {
                    b.HasOne("DocumentVersionManager.Domain.Entities.ModelTypeGroup", "ModelTypeGroup")
                        .WithMany("ModelTypes")
                        .HasForeignKey("ModelTypeGroupName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModelTypeGroup");
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.ModelVersion", b =>
                {
                    b.HasOne("DocumentVersionManager.Domain.Entities.Model", "Models")
                        .WithMany("ModelVersions")
                        .HasForeignKey("ModelName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DocumentVersionManager.Domain.Entities.ShellMaterial", "ShellMaterial")
                        .WithMany("ModelVersions")
                        .HasForeignKey("ShellMaterialName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Models");

                    b.Navigation("ShellMaterial");
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.Product", b =>
                {
                    b.HasOne("DocumentVersionManager.Domain.Entities.ModelVersion", "ModelVersion")
                        .WithMany("Products")
                        .HasForeignKey("ModelName", "ModelVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModelVersion");
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.TestPoint", b =>
                {
                    b.HasOne("DocumentVersionManager.Domain.Entities.ModelVersion", "ModelVersion")
                        .WithMany("TestPoints")
                        .HasForeignKey("ModelName", "ModelVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModelVersion");
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.Document", b =>
                {
                    b.Navigation("DocumentDocumentTypes");
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.DocumentType", b =>
                {
                    b.Navigation("DocumentDocumentTypes");
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.Model", b =>
                {
                    b.Navigation("ModelVersions");
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.ModelType", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.ModelTypeGroup", b =>
                {
                    b.Navigation("ModelTypes");
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.ModelVersion", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("Products");

                    b.Navigation("TestPoints");
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.Entities.ShellMaterial", b =>
                {
                    b.Navigation("ModelVersions");
                });
#pragma warning restore 612, 618
        }
    }
}
