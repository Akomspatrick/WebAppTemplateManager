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
    [Migration("20231031161602_SEC24")]
    partial class SEC24
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.Document", b =>
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

                    b.Property<string>("DocumentDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("DocumentNameGuid")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("DocumentName", "ModelName", "ModelVersionId");

                    b.HasIndex("ModelName", "ModelVersionId");

                    b.ToTable("Document");

                    b.HasData(
                        new
                        {
                            DocumentName = "FIRSTMODELNAME ver1 DOc",
                            ModelName = "FIRSTMODELNAME",
                            ModelVersionId = 1,
                            ChangeOrderPDFPath = "CHANGE ORDER PATH",
                            ContentPDFPath = "CONTENT PDF PATH",
                            DocumentDescription = "SIMPLE DESCRITION OF DOCUMENT",
                            DocumentNameGuid = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"),
                            Timestamp = new DateTime(2023, 10, 31, 16, 16, 2, 651, DateTimeKind.Utc).AddTicks(5455)
                        },
                        new
                        {
                            DocumentName = "FIRSTMODELNAME ver1 DOc A",
                            ModelName = "FIRSTMODELNAME",
                            ModelVersionId = 1,
                            ChangeOrderPDFPath = "CHANGE ORDER PATH",
                            ContentPDFPath = "CONTENT PDF PATH",
                            DocumentDescription = "SIMPLE DESCRITION OF DOCUMENT",
                            DocumentNameGuid = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"),
                            Timestamp = new DateTime(2023, 10, 31, 16, 16, 2, 651, DateTimeKind.Utc).AddTicks(5464)
                        },
                        new
                        {
                            DocumentName = "FIRSTMODELNAME ver1 DOc B",
                            ModelName = "FIRSTMODELNAME",
                            ModelVersionId = 1,
                            ChangeOrderPDFPath = "CHANGE ORDER PATH",
                            ContentPDFPath = "CONTENT PDF PATH",
                            DocumentDescription = "SIMPLE DESCRITION OF DOCUMENT",
                            DocumentNameGuid = new Guid("7808711f-544a-423d-8d99-f00c31e35be5"),
                            Timestamp = new DateTime(2023, 10, 31, 16, 16, 2, 651, DateTimeKind.Utc).AddTicks(5467)
                        },
                        new
                        {
                            DocumentName = "FIRSTMODELNAME ver2 DOc A",
                            ModelName = "FIRSTMODELNAME",
                            ModelVersionId = 2,
                            ChangeOrderPDFPath = "CHANGE ORDER PATH",
                            ContentPDFPath = "CONTENT PDF PATH",
                            DocumentDescription = "SIMPLE DESCRITION OF DOCUMENT",
                            DocumentNameGuid = new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"),
                            Timestamp = new DateTime(2023, 10, 31, 16, 16, 2, 651, DateTimeKind.Utc).AddTicks(5469)
                        });
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.DocumentType", b =>
                {
                    b.Property<string>("TypeName")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("TypeName");

                    b.ToTable("DocumentType");

                    b.HasData(
                        new
                        {
                            TypeName = "Cabling"
                        },
                        new
                        {
                            TypeName = "Chroming"
                        },
                        new
                        {
                            TypeName = "Sealing"
                        },
                        new
                        {
                            TypeName = "Gauging"
                        },
                        new
                        {
                            TypeName = "Wiring"
                        });
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.HigherModel", b =>
                {
                    b.Property<string>("HigherModelName")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("HigherModelDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Id")
                        .HasColumnType("longtext");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("HigherModelName");

                    b.ToTable("HigherModel");

                    b.HasData(
                        new
                        {
                            HigherModelName = "HigherModel1",
                            Capacity = 1,
                            HigherModelDescription = "HigherModel1",
                            Id = "567ae306-4c5c-437c-871e-012c7816f60b",
                            ProductId = "HigherModel1"
                        },
                        new
                        {
                            HigherModelName = "HigherModel2",
                            Capacity = 12,
                            HigherModelDescription = "HigherModel12",
                            Id = "0365eb1f-a181-4dd0-b95f-5313ec51a885",
                            ProductId = "HigherModel12"
                        },
                        new
                        {
                            HigherModelName = "HigherModel3",
                            Capacity = 13,
                            HigherModelDescription = "HigherModel1",
                            Id = "d83447c4-f6f5-4e95-bae0-d73b5221cdec",
                            ProductId = "HigherModel13"
                        },
                        new
                        {
                            HigherModelName = "HigherModel4",
                            Capacity = 14,
                            HigherModelDescription = "HigherModel14",
                            Id = "bc46a5b8-c975-490d-b769-eac3ba435869",
                            ProductId = "HigherModel14"
                        },
                        new
                        {
                            HigherModelName = "HigherModel5",
                            Capacity = 5,
                            HigherModelDescription = "HigherModel5",
                            Id = "ad8c9743-168d-412e-965e-0a514937c539",
                            ProductId = "HigherModel5"
                        });
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.Model", b =>
                {
                    b.Property<string>("ModelName")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ModelTypesName")
                        .IsRequired()
                        .HasColumnType("varchar(128)");

                    b.HasKey("ModelName");

                    b.HasIndex("ModelTypesName");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            ModelName = "FIRSTMODELNAME",
                            ModelId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"),
                            ModelTypesName = "FIRSTMODELTYPE"
                        },
                        new
                        {
                            ModelName = "SECONDMODELNAME",
                            ModelId = new Guid("7808711f-544a-423d-8d99-f00c31e35be5"),
                            ModelTypesName = "FIRSTMODELTYPE"
                        },
                        new
                        {
                            ModelName = "THIRDMODELNAME",
                            ModelId = new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"),
                            ModelTypesName = "SECONDMODELTYPE"
                        });
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.ModelTypes", b =>
                {
                    b.Property<string>("ModelTypesName")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<Guid>("ModelTypesId")
                        .HasColumnType("char(36)");

                    b.HasKey("ModelTypesName");

                    b.ToTable("ModelType");

                    b.HasData(
                        new
                        {
                            ModelTypesName = "FIRSTMODELTYPE",
                            ModelTypesId = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63")
                        },
                        new
                        {
                            ModelTypesName = "SECONDMODELTYPE",
                            ModelTypesId = new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b")
                        },
                        new
                        {
                            ModelTypesName = "THIRDMODELTYPE",
                            ModelTypesId = new Guid("3c69923e-a68e-4348-b06c-7007f527355d")
                        });
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.ModelVersion", b =>
                {
                    b.Property<string>("ModelName")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<int>("ModelVersionId")
                        .HasColumnType("int");

                    b.Property<Guid>("ModelVersionGuid")
                        .HasColumnType("char(36)");

                    b.Property<string>("ModelVersionName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("VersionDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ModelName", "ModelVersionId");

                    b.ToTable("ModelVersion");

                    b.HasData(
                        new
                        {
                            ModelName = "FIRSTMODELNAME",
                            ModelVersionId = 1,
                            ModelVersionGuid = new Guid("b27c2c19-522b-49d1-83bf-e80d4dde8c63"),
                            ModelVersionName = "FIRST_VERSION_FIRSTMODEL_NAME",
                            Timestamp = new DateTime(2023, 10, 31, 16, 16, 2, 653, DateTimeKind.Utc).AddTicks(6268),
                            Username = "OLADEJI",
                            VersionDescription = "SPECIAL DESIGN"
                        },
                        new
                        {
                            ModelName = "FIRSTMODELNAME",
                            ModelVersionId = 2,
                            ModelVersionGuid = new Guid("7808711f-544a-423d-8d99-f00c31e35be5"),
                            ModelVersionName = "SECOND_VERSION_FIRSTMODELNAME",
                            Timestamp = new DateTime(2023, 10, 31, 16, 16, 2, 653, DateTimeKind.Utc).AddTicks(6285),
                            Username = "OLADEJI",
                            VersionDescription = "AUTO DESIGN TO COMBAT SPLIILING"
                        },
                        new
                        {
                            ModelName = "SECONDMODELNAME",
                            ModelVersionId = 1,
                            ModelVersionGuid = new Guid("58dcf5c5-5a00-4ffa-bb37-9374a8d3c69b"),
                            ModelVersionName = "FIRST_VERSION_SECONDMODELNAME",
                            Timestamp = new DateTime(2023, 10, 31, 16, 16, 2, 653, DateTimeKind.Utc).AddTicks(6287),
                            Username = "OLADEJI",
                            VersionDescription = "INITIAL DESIGN"
                        });
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.Document", b =>
                {
                    b.HasOne("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.ModelVersion", "ModelVersion")
                        .WithMany("Documents")
                        .HasForeignKey("ModelName", "ModelVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModelVersion");
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.Model", b =>
                {
                    b.HasOne("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.ModelTypes", "ModelTypes")
                        .WithMany("Models")
                        .HasForeignKey("ModelTypesName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModelTypes");
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.ModelVersion", b =>
                {
                    b.HasOne("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.Model", "Models")
                        .WithMany("ModelVersions")
                        .HasForeignKey("ModelName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Models");
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.Model", b =>
                {
                    b.Navigation("ModelVersions");
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.ModelTypes", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("DocumentVersionManager.Domain.ModelAggregateRoot.Entities.ModelVersion", b =>
                {
                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
