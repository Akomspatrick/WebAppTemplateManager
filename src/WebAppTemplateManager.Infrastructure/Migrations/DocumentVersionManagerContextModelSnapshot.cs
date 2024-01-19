﻿// <auto-generated />
using System;
using WebAppTemplateManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebAppTemplateManager.Infrastructure.Migrations
{
    [DbContext(typeof(WebAppTemplateManagerContext))]
    partial class WebAppTemplateManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.Document", b =>
                {
                    b.Property<string>("DocumentName")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("ModelName")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<int>("ModelVersionId")
                        .HasColumnType("int");

                    b.Property<string>("ChangeOrderPDFPath")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("ContentPDFPath")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("DocumentBasePathId")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("DocumentDescription")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("DocumentName", "ModelName", "ModelVersionId");

                    b.HasIndex("ModelName", "ModelVersionId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.DocumentBasePath", b =>
                {
                    b.Property<string>("DocumentBasePathId")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("DocumentBasePathId");

                    b.ToTable("DocumentBasePaths");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.DocumentDocumentType", b =>
                {
                    b.Property<string>("DocumentName")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("ModelName")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<int>("ModelVersionId")
                        .HasColumnType("int");

                    b.Property<string>("DocumentTypeName")
                        .HasColumnType("varchar(32)");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("char(36)");

                    b.HasKey("DocumentName", "ModelName", "ModelVersionId", "DocumentTypeName");

                    b.HasIndex("DocumentTypeName");

                    b.ToTable("DocumentDocumentTypes");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.DocumentType", b =>
                {
                    b.Property<string>("DocumentTypeName")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("char(36)");

                    b.HasKey("DocumentTypeName");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.Model", b =>
                {
                    b.Property<string>("ModelName")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ModelTypeName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("ModelName");

                    b.HasIndex("ModelTypeName");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.ModelType", b =>
                {
                    b.Property<string>("ModelTypeName")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ModelTypeGroupName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("ModelTypeName");

                    b.HasIndex("ModelTypeGroupName");

                    b.ToTable("ModelTypes");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.ModelTypeGroup", b =>
                {
                    b.Property<string>("ModelTypeGroupName")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("char(36)");

                    b.Property<string>("TestingMode")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("ModelTypeGroupName");

                    b.ToTable("ModelTypeGroups");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.ModelVersion", b =>
                {
                    b.Property<string>("ModelName")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<int>("ModelVersionId")
                        .HasColumnType("int");

                    b.Property<string>("AccuracyClass")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<bool>("Alloy")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Application")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("CCNumber")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("DefaultCableLength")
                        .HasColumnType("int");

                    b.Property<string>("DefaultTestingMode")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("char(36)");

                    b.Property<int>("MinimumDeadLoad")
                        .HasColumnType("int");

                    b.Property<string>("ModelVersionName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("NTEPCertificationId")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

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
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime>("OIMLCertificationTimestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Resistance")
                        .HasColumnType("int");

                    b.Property<int>("SafeLoad")
                        .HasColumnType("int");

                    b.Property<string>("ShellMaterialName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

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
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("VersionDescription")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<int>("nMax")
                        .HasColumnType("int");

                    b.Property<double>("vMin")
                        .HasColumnType("double");

                    b.HasKey("ModelName", "ModelVersionId");

                    b.HasIndex("ShellMaterialName");

                    b.ToTable("ModelVersions");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BatcNo")
                        .HasColumnType("int");

                    b.Property<int>("CableLength")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("DefaultTestingMode")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("char(36)");

                    b.Property<int>("InspectionResult")
                        .HasColumnType("int");

                    b.Property<string>("MachiningPurcharseOrderNo")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("ModelTypeGroupName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<int>("ModelVersionId")
                        .HasColumnType("int");

                    b.Property<string>("SalesOrderId")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Stage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SteelPurcharseOrderNo")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("SubStage")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("ThermexPurcharseOrderNo")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UsedTestingMode")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("ProductId");

                    b.HasIndex("ModelName", "ModelVersionId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.ShellMaterial", b =>
                {
                    b.Property<string>("ShellMaterialName")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<bool>("Alloy")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("char(36)");

                    b.HasKey("ShellMaterialName");

                    b.ToTable("ShellMaterials");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.TestPoint", b =>
                {
                    b.Property<string>("ModelName")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<int>("ModelVersionId")
                        .HasColumnType("int");

                    b.Property<int>("CapacityTestPoint")
                        .HasColumnType("int");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("char(36)");

                    b.HasKey("ModelName", "ModelVersionId", "CapacityTestPoint");

                    b.ToTable("TestPoints");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.Document", b =>
                {
                    b.HasOne("WebAppTemplateManager.Domain.Entities.ModelVersion", "ModelVersion")
                        .WithMany("Documents")
                        .HasForeignKey("ModelName", "ModelVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModelVersion");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.DocumentDocumentType", b =>
                {
                    b.HasOne("WebAppTemplateManager.Domain.Entities.DocumentType", "DocumentType")
                        .WithMany("DocumentDocumentTypes")
                        .HasForeignKey("DocumentTypeName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAppTemplateManager.Domain.Entities.Document", "Document")
                        .WithMany("DocumentDocumentTypes")
                        .HasForeignKey("DocumentName", "ModelName", "ModelVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("DocumentType");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.Model", b =>
                {
                    b.HasOne("WebAppTemplateManager.Domain.Entities.ModelType", "ModelType")
                        .WithMany("Models")
                        .HasForeignKey("ModelTypeName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModelType");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.ModelType", b =>
                {
                    b.HasOne("WebAppTemplateManager.Domain.Entities.ModelTypeGroup", "ModelTypeGroup")
                        .WithMany("ModelTypes")
                        .HasForeignKey("ModelTypeGroupName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModelTypeGroup");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.ModelVersion", b =>
                {
                    b.HasOne("WebAppTemplateManager.Domain.Entities.Model", "Models")
                        .WithMany("ModelVersions")
                        .HasForeignKey("ModelName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAppTemplateManager.Domain.Entities.ShellMaterial", "ShellMaterial")
                        .WithMany("ModelVersions")
                        .HasForeignKey("ShellMaterialName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Models");

                    b.Navigation("ShellMaterial");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.Product", b =>
                {
                    b.HasOne("WebAppTemplateManager.Domain.Entities.ModelVersion", "ModelVersion")
                        .WithMany("Products")
                        .HasForeignKey("ModelName", "ModelVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModelVersion");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.TestPoint", b =>
                {
                    b.HasOne("WebAppTemplateManager.Domain.Entities.ModelVersion", "ModelVersion")
                        .WithMany("TestPoints")
                        .HasForeignKey("ModelName", "ModelVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModelVersion");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.Document", b =>
                {
                    b.Navigation("DocumentDocumentTypes");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.DocumentType", b =>
                {
                    b.Navigation("DocumentDocumentTypes");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.Model", b =>
                {
                    b.Navigation("ModelVersions");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.ModelType", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.ModelTypeGroup", b =>
                {
                    b.Navigation("ModelTypes");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.ModelVersion", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("Products");

                    b.Navigation("TestPoints");
                });

            modelBuilder.Entity("WebAppTemplateManager.Domain.Entities.ShellMaterial", b =>
                {
                    b.Navigation("ModelVersions");
                });
#pragma warning restore 612, 618
        }
    }
}